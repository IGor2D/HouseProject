using System;
using System.Threading.Tasks;
using System.IO;
using Microsoft.AspNetCore.Hosting;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using HouseProject.Core.ServiceInterface;
using HouseProject.Data;
using HouseProject.Core.Domain;
using HouseProject.Core.Dtos;

namespace HouseProject.ApplicationServices.Services
{
    public class HouseServices : IHouseService
    {
        private readonly HouseDbcontext _context;

        public HouseServices
            (
            HouseDbcontext context

            )
        {
            _context = context;

        }


        public async Task<House> Add(HouseDto dto)
        {
            House house = new House();


            house.Id = Guid.NewGuid();
            house.City = dto.City;
            house.Street = dto.Street;
            house.Entrance = dto.Entrance;
            house.Number = dto.Number;
            house.Floor = dto.Floor;
            house.Area = dto.Area;
            house.CreatedAt = DateTime.Now;
            house.ModifieAt = DateTime.Now;

            await _context.House.AddAsync(house);
            await _context.SaveChangesAsync();

            return house;
        }


        public async Task<House> Delete(Guid id)
        {
            var houseId = await _context.House
                .FirstOrDefaultAsync(x => x.Id == id);

            _context.House.Remove(houseId);
            await _context.SaveChangesAsync();
            return houseId;
        }


        public async Task<House> Update(HouseDto dto)
        {
            House house = new House();

            house.Id = dto.Id;
            house.City = dto.City;
            house.Street = dto.Street;
            house.Entrance = dto.Entrance;
            house.Number = dto.Number;
            house.Floor = dto.Floor;
            house.Area = dto.Area;
            house.CreatedAt = DateTime.Now;
            house.ModifieAt = DateTime.Now;

            _context.House.Update(house);
            await _context.SaveChangesAsync();
            return house;
        }


        public async Task<House> GetAsync(Guid id)
        {
            var result = await _context.House
                .FirstOrDefaultAsync(x => x.Id == id);

            return result;
        }
    }
}




