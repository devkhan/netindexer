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
    public class RegionsController : ApiController
    {
		List<Region> regions = new List<Region>();

		public IEnumerable<Region> GetAllRegions()
		{
			try
			{
				using (OdbcConnection connection = new OdbcConnection("DRIVER={MySQL ODBC 3.51 Driver};Database=netindex;Server=localhost;UID=root;PWD=;"))
				{
					connection.Open();
					using (OdbcCommand command = new OdbcCommand("SELECT region_code, region FROM region_list", connection))
					using (OdbcDataReader dr = command.ExecuteReader())
					{
						OdbcCommand count = new OdbcCommand("SELECT COUNT(*) as number FROM region_list", connection);
						OdbcDataReader d = count.ExecuteReader();
						d.Read();
						string x = d["number"].ToString();
						int n = int.Parse(x);
						Trace.WriteLine("No. of records: " + n.ToString());
						while (n != 0)
						{
							var region = new Region();
							Trace.WriteLine(dr.Read());
							region.region_code = dr["region_code"].ToString();
							region.region = dr["region"].ToString();
							regions.Add(region);
							Trace.WriteLine(region.region_code.ToString() + " " + region.region.ToString());
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
			return regions;
		}

		public IHttpActionResult GetRegion(string region_code)
		{
			//var Country = countries.FirstOrDefault((p) => p.id == id);
			//if(Country==null)
			//{
			//    Trace.Write("Result nor found");
			//    return NotFound();
			//}
			//Trace.Write(Country.id.ToString() + " " + Country.name.ToString());


			//Country Country = new Country();
			//OdbcConnection connection = new OdbcConnection("DRIVER={MySQL ODBC 3.51 Driver};Database=countries;Server=localhost;UID=root;PWD=;");
			//connection.Open();
			//OdbcCommand command = new OdbcCommand("SELECT name FROM countries WHERE id=" + id.ToString() + ";", connection);
			//OdbcDataReader dr = command.ExecuteReader();
			//dr.Read();
			//Country.id = id;
			//Country.country = dr["name"].ToString();
			//Trace.Write(Country);
			//return Ok(Country);
			return null;
		}
    }
}
