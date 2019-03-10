using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MVCApplication.Models;
using MVCApplication.ViewModels;

namespace MVCApplication.Controllers
{
  
    public class HomeController : Controller
    {
        public IActionResult Index()
        {

            return View();
        }

        public IActionResult Error()
        {

            return View();
        }

        public IActionResult Result()
        {
            ResultViewModel resultViewModel = new ResultViewModel();

            ViewBag.error = "Please return to the 'Home' page and enter values to use for calculations.";

            return View(resultViewModel);
        }

        [HttpPost]
        public IActionResult Result(ResultViewModel resultViewModel)

        {
            if (ModelState.IsValid)
            {
                if(resultViewModel.quant == 0)
                {
                    Random random = new Random();
                    resultViewModel.quant = random.Next(0, 100);

                }

                RandomValue qbert = new RandomValue("qbert");

                resultViewModel.RandomNumbers = qbert.RandomNumbers(resultViewModel.quant);

                return View(resultViewModel);
            }

            return Redirect("/Home/Error");
        }

    }



}
