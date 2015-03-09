using System;
using System.Collections.Generic;
using System.Data.Odbc;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ServerAPI.Controllers
{
	public class SearchResult
	{
		public string result { get; set; }
	}


    public class SearchController : ApiController
    {
		List<SearchResult> results = new List<SearchResult>();

		public IEnumerable<SearchResult> GetAllSearch()
		{
			return results;
		}

		public IHttpActionResult GetSearch(string id)
		{
			
			OdbcConnection connection = new OdbcConnection("DRIVER={MySQL ODBC 3.51 Driver};Database=netindex;Server=localhost;UID=root;PWD=;");
			connection.Open();
			OdbcCommand command = new OdbcCommand("select country from countries_list where country like '%"+id+"%';", connection);
			OdbcDataReader dr = command.ExecuteReader();
			while(dr.Read())
			{
				SearchResult searchResult = new SearchResult();
				searchResult.result = dr["country"].ToString();
				results.Add(searchResult);
			}
			return Ok(results);
		}
    }
}
