using Microsoft.AspNetCore.Mvc;
using World.Models;
using System;
using System.Collections.Generic;

namespace World.Controllers
{
  public class HomeController : Controller
  {
    [HttpGet("/")]
    public ActionResult Index()
    {
      List<Country> allCountries = Country.GetAll();
      Random rnd = new Random();
      int randomIndex = rnd.Next(allCountries.Count);
      Country newCountry = allCountries[randomIndex];
      return View(newCountry);
    }
  }
}
