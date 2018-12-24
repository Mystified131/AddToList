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
            if (TheList.Count > 0) {
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


        [HttpGet]
        public IActionResult Remove()
        {
            if (TheList.Count > 0)
            {
                RemoveViewModel removeViewModel = new RemoveViewModel();

                removeViewModel.TheList = TheList;

                return View(removeViewModel);
            }

            else
            {
                return Redirect("/");
            }
        }

        [HttpPost]
        public IActionResult Remove(RemoveViewModel removeViewModel)

        {
            if (ModelState.IsValid)
            {

                TheList.Remove(removeViewModel.NewElement1);

                removeViewModel.TheList = TheList;

                return Redirect("/Home/Result");
            }

            return Redirect("/");

        }

        [HttpGet]
        public IActionResult EditSelect()
        {
            if (TheList.Count > 0)
            {
                EditSelectViewModel editSelectViewModel = new EditSelectViewModel();

                editSelectViewModel.TheList = TheList;

                return View(editSelectViewModel);
            }

            else
            {
                return Redirect("/");
            }
        }


        [HttpPost]
        public IActionResult EditSelect(EditSelectViewModel editSelectViewModel)
        {

                if (ModelState.IsValid)
                {

                    ViewBag.NewElement1 = editSelectViewModel.NewElement1;
                    TheList.Remove(editSelectViewModel.NewElement1);

                return View("EditItem");
                }

                return Redirect("/");

            }


        [HttpGet]
        public IActionResult EditItem()
        {
            if (TheList.Count > 0)
            {
                EditItemViewModel editItemViewModel = new EditItemViewModel();

                return View(editItemViewModel);
            }

            else
            {
                return Redirect("/");
            }
        }

        [HttpPost]
        public IActionResult EditItem(EditItemViewModel editItemViewModel)

        {
            if (ModelState.IsValid)

            { 
               

                TheList.Add(editItemViewModel.NewElement2);

                return Redirect("/Home/Result");
            }

            return Redirect("/");

        }
    }

}


