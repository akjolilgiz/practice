using System.Collections.Generic;
using MySql.Data.MySqlClient;
using World;
using System;

namespace World.Models
{
  public class Country
  {
    private string _code;
    private string _name;
    private string _continent;
    private int _population;
    private string _localName;
    private string _governmentForm;

    public Country(string newCode, string newName, string newContinent, int newPopulation, string newLN, string newGF)
    {
      _code = newCode;
      _name = newName;
      _continent = newContinent;
      _population = newPopulation;
      _localName = newLN;
      _governmentForm = newGF;
    }
    public string GetCode()
    {
      return _code;
    }
    public void SetCode(string newCode)
    {
      _code = newCode;
    }
    public string GetName()
    {
      return _name;
    }
    public void SetName(string newName)
    {
      _name = newName;
    }
    public string GetContinent()
    {
      return _continent;
    }
    public void SetCountinent(string newContinent)
    {
      _continent = newContinent;
    }
    public int GetPopulation()
    {
      return _population;
    }
    public void SetPopulation(int newContinent)
    {
      _population = newContinent;
    }
    public string GetLN()
    {
      return _localName;
    }
    public void SetLN(string newLN)
    {
      _localName = newLN;
    }
    public string GetGF()
    {
      return _governmentForm;
    }
    public void SetGF(string newGF)
    {
      _governmentForm = newGF;
    }

    public static List<Country> GetAll()
    {
      List<Country> allCountries = new List<Country> {};
      MySqlConnection conn = DB.Connection();
      conn.Open();
      MySqlCommand cmd = conn.CreateCommand() as MySqlCommand;
      cmd.CommandText = @"SELECT * FROM country;";
      MySqlDataReader rdr = cmd.ExecuteReader() as MySqlDataReader;
      while(rdr.Read())
      {
        string countryCode = rdr.GetString(0);
        string countryName = rdr.GetString(1);
        string countryContinent = rdr.GetString(2);
        int countryPopulation = rdr.GetInt32(3);
        string countryLN = rdr.GetString(4);
        string countryGF = rdr.GetString(5);
        Country newCountry = new Country(countryCode, countryName, countryContinent, countryPopulation, countryLN, countryGF);
        allCountries.Add(newCountry);
      }
      conn.Close();
      if (conn !=null)
      {
        conn.Dispose();
      }
      return allCountries;
    }



    //Filter method
    public static List<Country> GetAllFiltered(string filterColumn, string operatorChoice, string userInput)
    {
      List<Country> allCountries = new List<Country> {};
      MySqlConnection conn = DB.Connection();
      conn.Open();
      MySqlCommand cmd = conn.CreateCommand() as MySqlCommand;
      cmd.CommandText = @"SELECT * FROM country WHERE " + filterColumn + " " + operatorChoice + " '" + userInput + "';";
      // cmd.CommandText = @"SELECT * FROM country WHERE Continent = 'Asia';";
      MySqlDataReader rdr = cmd.ExecuteReader() as MySqlDataReader;
      while(rdr.Read())
      {
        string countryCode = rdr.GetString(0);
        string countryName = rdr.GetString(1);
        string countryContinent = rdr.GetString(2);
        int countryPopulation = rdr.GetInt32(3);
        string countryLN = rdr.GetString(4);
        string countryGF = rdr.GetString(5);
        Country newCountry = new Country(countryCode, countryName, countryContinent, countryPopulation, countryLN, countryGF);
        allCountries.Add(newCountry);
      }
      conn.Close();
      if (conn !=null)
      {
        conn.Dispose();
      }
      return allCountries;
    }
  }
}
