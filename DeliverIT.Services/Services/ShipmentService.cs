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
    public class ShipmentService : IShipmentService
    {
        private readonly DeliverITDBContext db;

        public ShipmentService(DeliverITDBContext db)
        {
            this.db = db;
        }

        public async Task<ShipmentDTO> DeleteAsync(int id)
        {
            var shipment = await db.Shipments.Include(x => x.Status).FirstOrDefaultAsync(x => x.Id == id);
            var shipmentDTO = shipment.GetDTO();

            shipment.DeletedOn = DateTime.Now;
            db.Shipments.Remove(shipment);
            await db.SaveChangesAsync();
            return shipmentDTO;
        }

        public async Task<IEnumerable<ShipmentDTO>> GetAsync()
        {
            return await db.Shipments.Include(x => x.Status).Select(x => x.GetDTO()).ToListAsync();
        }

        public async Task<ShipmentDTO> PostAsync(ShipmentDTO obj)
        {
            ShipmentDTO result = null;

            var newShipment = obj.GetEntity();
            var deleteShipment = await db.Shipments.IgnoreQueryFilters().Include(x => x.Status)
                .FirstOrDefaultAsync(x => x == newShipment && x.IsDeleted == true);
            if (deleteShipment == null)
            {
                await db.Shipments.AddAsync(newShipment);
                await db.SaveChangesAsync();
                newShipment = await db.Shipments.Include(x => x.Status).FirstOrDefaultAsync(x => x.Id == newShipment.Id);
                result = newShipment.GetDTO();
            }
            else
            {
                deleteShipment.DeletedOn = null;
                deleteShipment.IsDeleted = false;
                await db.SaveChangesAsync();
                result = deleteShipment.GetDTO();
            }

            return result;
        }

        public async Task<ShipmentDTO> UpdateAsync(int id, ShipmentDTO obj)
        {
            var shipment = await db.Shipments.Include(x => x.Status).FirstOrDefaultAsync(x => x.Id == id);

            shipment.ArrivalDate = obj.ArrivalDate;
            shipment.DepartureDate = obj.DepartureDate;
            shipment.DestinationWareHouseId = obj.DestinationWareHouseId;
            shipment.StatusId = obj.StatusId;
            var shipmentDTO = shipment.GetDTO();
            await db.SaveChangesAsync();
            return shipmentDTO;
        }
        public async Task<bool> ShipmentExistsAsync(int id)
        {
            var shipment = await db.Shipments.Include(x => x.Status).FirstOrDefaultAsync(x => x.Id == id);
            return shipment is null ? false : true;
        }

        public async Task<ShipmentDTO> GetShipmentByIdAsync(int id)
        {
            var shipment = await db.Shipments.Include(x => x.Status).FirstOrDefaultAsync(x => x.Id == id);

            return shipment.GetDTO();
        }
    }
}
