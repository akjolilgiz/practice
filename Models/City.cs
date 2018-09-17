using System.Collections.Generic;
using MySql.Data.MySqlClient;
using World;
using System;

namespace World.Models
{
  public class City
  {
    private int _id;
    private string _name;
    private string _countryCode;
    private string _district;
    private int _population;

    public City (int newId, string newName, string newCC, string newDistrict, int newPop)
    {
      _id = newId;
      _name = newName;
      _countryCode = newCC;
      _district = newDistrict;
      _population = newPop;
    }

    public int GetId()
    {
      return _id;
    }

    public void SetId(int newId)
    {
      _id = newId;
    }

    public string GetName()
    {
      return _name;
    }

    public void SetName(string newName)
    {
      _name = newName;
    }

    public string GetCountryCode()
    {
      return _countryCode;
    }

    public void SetCountryCode(string newCountryCode)
    {
      _countryCode = newCountryCode;
    }

    public string GetDistrict()
    {
      return _district;
    }

    public void SetDistrict(string newDistrict)
    {
      _district = newDistrict;
    }

    public int GetPop()
    {
      return _population;
    }

    public void SetPop(int newPop)
    {
      _population = newPop;
    }

    public static List<City> GetAll()
    {
      List<City> allCities = new List<City> {};
      MySqlConnection conn = DB.Connection();
      conn.Open();
      MySqlCommand cmd = conn.CreateCommand() as MySqlCommand;
      cmd.CommandText = @"SELECT * FROM city;";
      MySqlDataReader rdr = cmd.ExecuteReader() as MySqlDataReader;
      while (rdr.Read())
      {
        int cityId = rdr.GetInt32(0);
        string cityName = rdr.GetString(1);
        string cityCC = rdr.GetString(2);
        string cityDistrict = rdr.GetString(3);
        int cityPop = rdr.GetInt32(4);
        City newCity = new City(cityId, cityName, cityCC, cityDistrict, cityPop);
        allCities.Add(newCity);
      }
      conn.Close();
      if (conn != null)
      {
        conn.Dispose();
      }
      return allCities;
    }

    public static List<City> GetAllFiltered(string sortOrder)
    {
      List<City> allCities = new List<City> {};
      MySqlConnection conn = DB.Connection();
      conn.Open();
      MySqlCommand cmd = conn.CreateCommand() as MySqlCommand;
      cmd.CommandText = @"SELECT * FROM city ORDER BY Population " + sortOrder + ";";
      MySqlDataReader rdr = cmd.ExecuteReader() as MySqlDataReader;
      while (rdr.Read())
      {
        int cityId = rdr.GetInt32(0);
        string cityName = rdr.GetString(1);
        string cityCC = rdr.GetString(2);
        string cityDistrict = rdr.GetString(3);
        int cityPop = rdr.GetInt32(4);
        City newCity = new City(cityId, cityName, cityCC, cityDistrict, cityPop);
        allCities.Add(newCity);
      }
      conn.Close();
      if (conn != null)
      {
        conn.Dispose();
      }
      return allCities;
    }
    public static City GetCityById(string ID)
    {
      MySqlConnection conn = DB.Connection();
      City newCity = new City(0, "dum", "dum", "dum", 0);
      conn.Open();
      MySqlCommand cmd = conn.CreateCommand() as MySqlCommand;
      cmd.CommandText = @"SELECT * FROM city WHERE Id = " + ID + ";";
      MySqlDataReader rdr = cmd.ExecuteReader() as MySqlDataReader;
      while (rdr.Read())
      {
        int cityId = rdr.GetInt32(0);
        string cityName = rdr.GetString(1);
        string cityCC = rdr.GetString(2);
        string cityDistrict = rdr.GetString(3);
        int cityPop = rdr.GetInt32(4);
        newCity = new City(cityId, cityName, cityCC, cityDistrict, cityPop);
      }
      conn.Close();
      if (conn != null)
      {
        conn.Dispose();
      }
      return newCity;
    }

  }
}
