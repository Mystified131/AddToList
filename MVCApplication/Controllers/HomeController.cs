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
        static public List<string> TheList = new List<string>();

        public IActionResult Index()
        {
            
        IndexViewModel indexViewModel = new IndexViewModel();

            return View(indexViewModel);
        }

        [HttpGet]
        public IActionResult Result()
        {
            if(TheList.Count > 0) { 
            ResultViewModel resultViewModel = new ResultViewModel();

                resultViewModel.TheList = TheList;

                return View(resultViewModel);
            }

            else
            {
                return Redirect("/");
            }
        }

        [HttpPost]
        public IActionResult Result(ResultViewModel resultViewModel)

        {
            if (ModelState.IsValid)
            {

                TheList.Add(resultViewModel.NewElement);

                resultViewModel.TheList = TheList;

                return View(resultViewModel);
            }

            return Redirect("/");

        }

    }



}
