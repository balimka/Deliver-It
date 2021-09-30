﻿using DeliverIT.Models;
using DeliverIT.Models.DatabaseModels;
using DeliverIT.Services.Contracts;
using DeliverIT.Services.DTOs;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DeliverIT.Services.DTOMappers;
namespace DeliverIT.Services.Services
{
    public class WareHouseService : IWareHouseService
    {
        private readonly DeliverITDBContext db;

        public WareHouseService(DeliverITDBContext db)
        {
            this.db = db;
        }

        public async Task<WareHouseDTO> Delete(int id)
        {
            var model = await this.db.WareHouses
                                    .Include(x => x.Parcels)
                                    .Include(w => w.Address)
                                        .ThenInclude(a => a.City)
                                            .ThenInclude(c => c.Country)
                                    .FirstOrDefaultAsync(x => x.Id == id);
            var modelGTO = model.GetDTO();
            this.db.WareHouses.Remove(model);
            await db.SaveChangesAsync();

            return modelGTO;
        }

        public async Task<IEnumerable<WareHouseDTO>> Get()
        {
            var WareHousesDTO = await db.WareHouses
                .Include(x => x.Parcels)
                .Include(w => w.Address)
                    .ThenInclude(a => a.City)
                        .ThenInclude(c => c.Country)
                .Select(x => new WareHouseDTO
                {
                    Id = x.Id,
                    AddressId = x.AddressId,
                    StreetName = x.Address.StreetName,
                    City = x.Address.City.Name,
                    Country = x.Address.City.Country.Name,
                    Parcels = x.Parcels.Select(y => $"Id: {y.Id}; CustomerId {y.CustomerId}; ShipmentId {y.ShipmentId}").ToList()
                })
                .ToListAsync();

            return WareHousesDTO;
        }

        public async Task<WareHouseDTO> GetWareHouseById(int id)
        {
            var model = await this.db.WareHouses
                .Include(x => x.Parcels)
                .Include(w => w.Address)
                    .ThenInclude(a => a.City)
                        .ThenInclude(c => c.Country)
                        .FirstOrDefaultAsync(x => x.Id == id);

            var result = model.GetDTO();
            return result;
        }

        public async Task<WareHouseDTO> Post(WareHouseDTO obj)
        {
            var model = obj.GetEntity();

            var newWareHouse = await db.WareHouses.AddAsync(model);
            await db.SaveChangesAsync();
            //obj.Id = 
            var result = await db.WareHouses.Include(x => x.Parcels)
                .Include(w => w.Address)
                    .ThenInclude(a => a.City)
                        .ThenInclude(c => c.Country)
                        .Where(x => x.AddressId == model.AddressId)
                        .FirstOrDefaultAsync();
            return result.GetDTO();
        }

        public async Task<WareHouseDTO> Update(int id, WareHouseDTO obj)
        {
            var model = await this.db.WareHouses
                .Include(x => x.Parcels)
                .Include(w => w.Address)
                    .ThenInclude(a => a.City)
                        .ThenInclude(c => c.Country)
                        .FirstOrDefaultAsync(x => x.Id == id);

            model.AddressId = obj.AddressId;
            var result = model.GetDTO();

            await db.SaveChangesAsync();

            return result;
        }

        public async Task<bool> WareHouseExists(int id)
        {
            var model = await db.WareHouses.FirstOrDefaultAsync(x => x.Id == id);
            return model is null ? false : true;
        }
        /*private async Task<int> GetAddresId(WareHouseDTO obj)
        {
            var address = await db.Addresses.FirstOrDefaultAsync(x => x.StreetName == obj.StreetName);
            var city = await db.Cities.FirstOrDefaultAsync(x => x.Name == obj.City);
            var country = await db.Countries.FirstOrDefaultAsync(x => x.Name == obj.Country);

            if (country is null)
            {
                await this.db.Countries.AddAsync(new Country { Name = obj.Country });
                await db.SaveChangesAsync();

            }
            if (city is null)
            {
                await this.db.Cities.AddAsync(new City
                {
                    CountryId = await db.Countries.Where(x => x.Name == obj.Country).Select(x => x.Id).FirstOrDefaultAsync(),
                    Name = obj.City
                });
                await db.SaveChangesAsync();

            }

            if (address is null)
            {
                address = new Address
                {
                    CityId = await db.Cities.Where(x => x.Name == obj.City).Select(x => x.Id).FirstOrDefaultAsync(),
                    StreetName = obj.StreetName
                };
                await this.db.Addresses.AddAsync(address);
                await db.SaveChangesAsync();
            }

            return address.Id;
        }*/
    }
}
