using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using World.Models;

namespace World.Controllers
{
  public class CountriesController : Controller
  {
    [HttpGet("/countries")]
    public ActionResult Index()
    {
      List<Country> allCountries = Country.GetAll();
      return View(allCountries);
    }

    [HttpPost("/countries")]
    public ActionResult Filter()
    {
      string newCategory = Request.Form["category"];
      string newOperator = Request.Form["operator"];
      string newInput = Request.Form["input"];
      List<Country> allCountries = Country.GetAllFiltered(newCategory, newOperator, newInput);
      // List<Country> allCountries = Country.GetAllFiltered("Continent", "=", "Asia");
      return View("Index", allCountries);
    }
  }
}
