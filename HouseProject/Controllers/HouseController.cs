using HouseProject.Core.Dtos;
using HouseProject.Core.ServiceInterface;
using HouseProject.Data;
using HouseProject.Models.House;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace HouseProject.Controllers
{
    public class HouseController : Controller
    {
        private readonly HouseDbcontext _context;
        private readonly IHouseService _houseService;

        public HouseController
            (
            HouseDbcontext context,
            IHouseService houseService
            )
        {
            _context = context;
            _houseService = houseService;
        }


        [HttpGet]
        public IActionResult Index()
        {
            var result = _context.House
                .OrderByDescending(y => y.CreatedAt)
                .Select(x => new HouseListItem
                {
                    Id = x.Id,
                    City = x.City,
                    Street = x.Street,
                    Entrance = x.Entrance,
                    Number = x.Number,
                    Floor = x.Floor,
                    Area = x.Area,
                });

            return View(result);
        }


        [HttpGet]
        public IActionResult Add()
        {
            HouseViewModel model = new HouseViewModel();
            return View("Edit", model);
        }


        [HttpPost]
        public async Task<IActionResult> Add(HouseViewModel model)
        {
            var dto = new HouseDto()
            {
                Id = model.Id,
                City = model.City,
                Street = model.Street,
                Entrance = model.Entrance,
                Number = model.Number,
                Floor = model.Floor,
                Area = model.Area,
                CreatedAt = model.CreatedAt,
                ModifieAt = model.ModifieAt,

            };

            var result = await _houseService.Add(dto);
            if (result == null)
            {
                return RedirectToAction(nameof(Index));
            }

            return RedirectToAction("Index", model);
        }


        [HttpPost]
        public async Task<IActionResult> Delete(Guid id)
        {
            var house = await _houseService.Delete(id);
            if (house == null)
            {
                return RedirectToAction(nameof(Index));
            }
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> Edit(Guid id)
        {
            var house = await _houseService.GetAsync(id);
            if (house == null)
            {
                return View(null);
            }

            var model = new HouseViewModel();
            model.Id = house.Id;
            model.City = house.City;
            model.Street = house.Street;
            model.Entrance = house.Entrance;
            model.Number = house.Number;
            model.Floor = house.Floor;
            model.Area = house.Area;
            model.CreatedAt = house.CreatedAt;
            model.ModifieAt = house.ModifieAt;

            return View(model);
        }


        [HttpPost]
        public async Task<IActionResult> Edit(HouseViewModel model)
        {
            var dto = new HouseDto()
            {
                Id = model.Id,
                City = model.City,
                Street = model.Street,
                Entrance = model.Entrance,
                Number = model.Number,
                Floor = model.Floor,
                Area = model.Area,
                CreatedAt = model.CreatedAt,
                ModifieAt = model.ModifieAt,
            };

            var result = await _houseService.Update(dto);

            if (result == null)
            {
                return RedirectToAction(nameof(Index));
            }
            return RedirectToAction(nameof(Index), model);
        }

    }
}
