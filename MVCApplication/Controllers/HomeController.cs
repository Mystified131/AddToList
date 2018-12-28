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
        static public string Searchstr;
        static public string Bridgeelement;

        public IActionResult Index()
        {

            IndexViewModel indexViewModel = new IndexViewModel();

            return View(indexViewModel);
        }

        public IActionResult Error()
        {

            return View();
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

                TheList.Add(resultViewModel.NewElement.ToLower());

                resultViewModel.TheList = TheList;

                return View(resultViewModel);
            }

            return Redirect("/Home/Error");

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

            return Redirect("/Home/Error");

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
                    Bridgeelement = editSelectViewModel.NewElement1;
                TheList.Remove(editSelectViewModel.NewElement1);

                return View("EditItem");
                }

            return Redirect("/Home/Error");

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

            TheList.Add(Bridgeelement);
            return Redirect("/Home/Error");

        }

        [HttpGet]
        public IActionResult SearchSelect()
        {
            if (TheList.Count > 0)
            {
                SearchSelectViewModel searchSelectViewModel = new SearchSelectViewModel();

                return View(searchSelectViewModel);
            }

            else
            {
                return Redirect("/");
            }
        }

        [HttpPost]
        public IActionResult SearchSelect(SearchSelectViewModel searchSelectViewModel)

        {
            if (ModelState.IsValid)

            {
                Searchstr = searchSelectViewModel.Searchstr.ToLower();
                return Redirect("/Home/SearchResult");
            }

            return Redirect("/Home/Error");

        }

        [HttpGet]
        public IActionResult SearchResult()
        {
            if (TheList.Count > 0)
            {
                SearchResultViewModel searchResultViewModel = new SearchResultViewModel();
                List<string> Anslist = new List<string>();

                foreach (string item in TheList)
                {
                    if (item.Contains(Searchstr))
                    {

                        Anslist.Add(item);

                    }


                }

                if (Anslist.Count == 0)
                {

                    Anslist.Add("That search returned no results.");

                }

                ViewBag.Anslist = Anslist;

                return View(searchResultViewModel);
            }

            else
            {
                return Redirect("/");
            }

        }

        [HttpGet]
        public IActionResult Sort()
        {
            if (TheList.Count > 0)
            {
                SortViewModel sortViewModel = new SortViewModel();


                List<string> Bridgelist = new List<string>();
                foreach (string item in TheList)
                { 

                Bridgelist.Add(item);

                }

                Bridgelist.Sort();

                sortViewModel.Sortlist = Bridgelist;

                return View(sortViewModel);
            }

            else
            {
                return Redirect("/");
            }
        }


    }

      
    }




