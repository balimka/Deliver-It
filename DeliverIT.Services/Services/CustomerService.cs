﻿using DeliverIT.Models;
using DeliverIT.Services.Contracts;
using DeliverIT.Services.DTOMappers;
using DeliverIT.Services.DTOs;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DeliverIT.Services.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly DeliverITDBContext db;

        public CustomerService(DeliverITDBContext db)
        {
            this.db = db;
        }

        public async Task<CustomerDTO> DeleteAsync(int id)
        {
            var customer = await db.Customers.Include(x => x.Address).FirstOrDefaultAsync(x => x.Id == id);
            var customerDTO = customer.GetDTO();

            customer.DeletedOn = DateTime.Now;
            db.Customers.Remove(customer);
            await db.SaveChangesAsync();
            return customerDTO;
        }

        public async Task<IEnumerable<CustomerDTO>> GetAsync()
        {
            return await db.Customers.Include(x => x.Address)
                .Select(x => x.GetDTO())
                .ToListAsync();
        }

        public async Task<IEnumerable<CustomerDTO>> GetCustomerByNameAsync(string name)
        {
            var customers = await db.Customers.Include(x => x.Parcels)
                .ThenInclude(x => x.Category)
                .Include(x => x.Parcels).ThenInclude(x => x.Shipment).ThenInclude(x => x.Status)
                .Include(x => x.Address)
                .Where(x => x.FirstName == name || x.LastName == name)
                .Select(x => x.GetDTO())
                .ToListAsync();
            return customers;
        }

        public async Task<CustomerDTO> PostAsync(CustomerDTO obj) //ToDo: bug if there is already existing customer and not soft deleted
        {
            var newCustomer = obj.GetEntity();
            var deletedCustomer = await db.Customers.IgnoreQueryFilters()
                .FirstOrDefaultAsync(x => x.FirstName == obj.FirstName && x.LastName == obj.LastName && x.IsDeleted == true);

            if (deletedCustomer == null)
            {
                await db.Customers.AddAsync(newCustomer);
            }
            else
            {
                deletedCustomer.DeletedOn = null;
                deletedCustomer.IsDeleted = false;
            }

            await db.SaveChangesAsync();
            obj.Id = deletedCustomer.Id;

            return obj;
        }

        public async Task<CustomerDTO> UpdateAsync(int id, CustomerDTO obj)
        {
            var model = await db.Customers.Include(c => c.Address).FirstOrDefaultAsync(x => x.Id == id);

            model.FirstName = obj.FirstName;
            model.LastName = obj.LastName;
            model.AddressId = obj.AddressId;

            await db.SaveChangesAsync();

            return model.GetDTO();
        }

        public async Task<int> UserCountAsync()
        {
            return await db.Customers.CountAsync();
        }

        public async Task<IEnumerable<CustomerDTO>> GetCustomersByEmailAsync(string part)
        {
            return await db.Customers.Where(x => x.Email.Contains(part)).Include(c => c.Address).Select(x => x.GetDTO()).ToListAsync();
        }

        public async Task<CustomerDTO> GetCustomerByIDAsync(int id)
        {
            return CustomerDTOMapperExtension.GetDTO(await db.Customers.Include(x => x.Address).FirstOrDefaultAsync(x => x.Id == id));
        }
    }
}
