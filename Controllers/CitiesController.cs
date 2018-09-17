using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using World.Models;

namespace World.Controllers
{
  public class CitiesController : Controller
  {
    [HttpGet("/cities")]
    public ActionResult Index()
    {
      List<City> allCities = City.GetAll();
      return View(allCities);
    }

    [HttpPost("/cities")]
    public ActionResult Filter()
    {
      List<City> allCities = City.GetAllFiltered(Request.Form["order"]);
      return View("Index", allCities);
    }
    [HttpGet("/cities/{Id}")]
    public ActionResult Details(string Id)
    {
      City newCity = City.GetCityById(Id);
      return View(newCity);
    }
  }
}
