﻿using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using LocationTracker.Repositories.Core;
using LocationTracker.Utils;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace LocationTracker.Controllers
{
    public class RunningController : Controller
    {
        private readonly IRunRepository runRepository;
        private readonly ITagRepository tagRepository;

        public RunningController(
            IRunRepository runRepository,
            ITagRepository tagRepository
        )
        {
            this.runRepository = runRepository;
            this.tagRepository = tagRepository;
        }

        public async Task<IActionResult> Index()
        {
            var runs = await runRepository.GetRuns();
            return View(runs);
        }

        public async Task<IActionResult> Run(string date)
        {
            if (string.IsNullOrEmpty(date) ||
                !(DateTime.TryParseExact(date, "dd-MM-yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime _date)))
            {
                return RedirectToAction("Index");
            }

            var run = await runRepository.GetRun(_date);
            return View(run);
        }

    }
}