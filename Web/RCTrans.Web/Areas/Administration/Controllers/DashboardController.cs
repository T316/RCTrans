﻿namespace RCTrans.Web.Areas.Administration.Controllers
{
    using Microsoft.AspNetCore.Mvc;

    using RCTrans.Services.Data;
    using RCTrans.Web.ViewModels.Administration.Dashboard;

    public class DashboardController : AdministrationController
    {
        private readonly ISettingsService settingsService;

        public DashboardController(ISettingsService settingsService)
        {
            this.settingsService = settingsService;
        }

        public IActionResult Index()
        {
            var viewModel = new IndexViewModel { SettingsCount = this.settingsService.GetCount(), };
            return this.View(viewModel);
        }

        public IActionResult AddVehicle()
        {
            return this.View();
        }

        public IActionResult AddArticle()
        {
            return this.View();
        }
    }
}
