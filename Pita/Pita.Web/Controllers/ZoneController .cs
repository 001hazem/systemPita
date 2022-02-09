using Microsoft.AspNetCore.Mvc;
using Pita.Core.Constants;
using Pita.Core.Dto;
using Pita.Core.Dtos;
using Pita.Infrastructure.Services.Category;
using Pita.Infrastructure.Services.Zone;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pita.Web.Controllers
{
    public class ZoneController : Controller
    {
        private readonly IZoneServices _zoneServices;
        public ZoneController(IZoneServices zoneServices)
        {
            _zoneServices = zoneServices;
        }


        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        public async Task<JsonResult> GetZoneData(Pagination pagination, Query query)
        {
            var result = await _zoneServices.GetAll(pagination, query);
            return Json(result);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateZoneDto dto)
        {
            if (ModelState.IsValid)
            {
                await _zoneServices.Create(dto);
                return Ok(Results.AddSuccessResult());
            }
            return View(dto);
        }

        [HttpGet]
        public async Task<IActionResult> Update(int id)
        {
            var zone = await _zoneServices.Get(id);
            return View(zone);
        }

        [HttpPost]
        public async Task<IActionResult> Update(UpdateZoneDto dto)
        {
            if (ModelState.IsValid)
            {
                await _zoneServices.Update(dto);
                return Ok(Results.EditSuccessResult());
            }
            return View(dto);
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            await _zoneServices.Delete(id);
            return Ok(Results.DeleteSuccessResult());
        }
    }
}
