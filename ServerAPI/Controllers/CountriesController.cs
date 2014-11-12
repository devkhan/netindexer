using ServerAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Data.Odbc;
using System.Configuration;
using System.Diagnostics;

namespace ServerAPI.Controllers
{
    public class CountriesController : ApiController
    {
        List<Country> countries = new List<Country>();

        public IEnumerable<Country> GetAllCountries()
        {
            try
            {
                using (OdbcConnection connection = new OdbcConnection("DRIVER={MySQL ODBC 3.51 Driver};Database=countries;Server=localhost;UID=root;PWD=;"))
                {
                    connection.Open();
                    using (OdbcCommand command = new OdbcCommand("SELECT id, name FROM countries", connection))
                    using (OdbcDataReader dr = command.ExecuteReader())
                    {
                        OdbcCommand count = new OdbcCommand("SELECT COUNT(*) as number FROM countries", connection);
                        OdbcDataReader d = count.ExecuteReader();
                        d.Read();
                        string x = d["number"].ToString();
                        int n = int.Parse(x);
                        Trace.WriteLine("No. of records: " + n.ToString());
                        Trace.WriteLine("Hello fucker");
                        while(n!=0)
                        {
                            var country = new Country();
                            Trace.WriteLine(dr.Read());
                            country.id = (int)dr["id"];
                            country.name = dr["name"].ToString();
                            countries.Add(country);
                            Trace.WriteLine(country.id.ToString() + " " + country.name.ToString());
                            n--;
                        }
                        d.Close();
                        dr.Close();
                    }
                    connection.Close();
                }
            }
            catch (Exception ex)
            {
                //throw;
                Trace.WriteLine(ex.ToString());
            }
            return countries;
        }

        public IHttpActionResult GetCountry(int id)
        {
            //var Country = countries.FirstOrDefault((p) => p.id == id);
            //if(Country==null)
            //{
            //    Trace.Write("Result nor found");
            //    return NotFound();
            //}
            //Trace.Write(Country.id.ToString() + " " + Country.name.ToString());
            Country Country = new Country();
            OdbcConnection connection = new OdbcConnection("DRIVER={MySQL ODBC 3.51 Driver};Database=countries;Server=localhost;UID=root;PWD=;");
            connection.Open();
            OdbcCommand command = new OdbcCommand("SELECT name FROM countries WHERE id=" + id.ToString() + ";", connection);
            OdbcDataReader dr = command.ExecuteReader();
            dr.Read();
            Country.id = id;
            Country.name = dr["name"].ToString();
            Trace.Write(Country);
            return Ok(Country);
        }
    }
}
