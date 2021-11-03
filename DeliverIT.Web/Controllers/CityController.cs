﻿using DeliverIT.Services.Contracts;
using DeliverIT.Services.Helpers;
using DeliverIT.Web.Attributes;
using DeliverIT.Web.Extensions;
using DeliverIT.Web.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DeliverIT.Web.Controllers
{
    [Authorize(Roles = Constants.ROLE_EMPLOYEE)]
    public class CityController : Controller
    {
        private readonly ICityService _cityservice;
        private readonly ICountryService _countryservice;

        public CityController(ICityService cs, ICountryService cos)
        {
            this._cityservice = cs;
            this._countryservice = cos;
        }

        public async Task<IActionResult> Index()
        {
            var cities = await _cityservice.GetAsync();
            return View(cities);
        }

        public async Task<IActionResult> Create()
        {
            var countries = await this._countryservice.GetAsync();

            var model = new CityViewModel();

            foreach (var country in countries)
            {
                model.Countries.Add(new SelectListItem() { Text = country.Name, Value = country.Id.ToString()});
            }

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CityViewModel model)
         {
            var country = await _countryservice.GetCountryByIdAsync(model.CountryId);

            if (await _cityservice.CityExists(model.Name, country.Id))
            {
                this.ModelState.AddModelError("Name", "This city already exists!");
                return Json(new { isValid = false, html = await Helper.RenderViewAsync(this, "Create", model, false) });
            }

            if (!this.ModelState.IsValid)
            {
                return Json(new { isValid = false, html = await Helper.RenderViewAsync(this, "Create", model, false) });
            }

            await _cityservice.PostAsync(new Services.DTOs.CityDTO 
            { 
                CountryId = country.Id,
                CountryName = country.Name,
                Name = model.Name
            });

            return Json(new { isValid = true, html = await Helper.RenderViewAsync(this, "_Table", await _cityservice.GetAsync(), true) });
        }

    }
}
