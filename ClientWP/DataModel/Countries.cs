using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using Windows.Data.Json;
using Windows.Storage;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Imaging;

namespace ClientWP.DataModel
{
    // My own data model for countries.
    public class Countries
    {
        public string country_code { get; set; }
        public string country { get; set; }
    }

    public class CountriesSource
    {
        private static CountriesSource _countriesSource = new CountriesSource();

        private ObservableCollection<Countries> _countries = new ObservableCollection<Countries>();
        public ObservableCollection<Countries> countries
        {
            get { return this._countries; }
        }

        private async Task GetSampleDataAsync()
        {
            if (this._countries.Count != 0)
                return;

            this._countries.Clear();

			JsonWebClient client = new JsonWebClient();
			var resp = await client.DoRequestAsync("http://169.254.80.80:88/api/countries");
			string jsonText = resp.ReadToEnd();
            //StorageFile file = await StorageFile.GetFileFromApplicationUriAsync(dataUri);
            //string jsonText = await FileIO.ReadTextAsync(file);
			JsonArray countriesList = JsonArray.Parse(jsonText);
			foreach (JsonValue jsonCountry in countriesList)
			{
				JsonObject countryObject = jsonCountry.GetObject();
				Countries country = new Countries();
				country.country_code = countryObject["country_code"].GetString();
				country.country = countryObject["country"].GetString();
				this.countries.Add(country);
			}
            //foreach (JsonValue groupValue in jsonArray)
            //{
            //    JsonObject groupObject = groupValue.GetObject();
            //    SampleDataGroup group = new SampleDataGroup(groupObject["UniqueId"].GetString(),
            //                                                groupObject["Title"].GetString(),
            //                                                groupObject["Subtitle"].GetString(),
            //                                                groupObject["ImagePath"].GetString(),
            //                                                groupObject["Description"].GetString());

            //    foreach (JsonValue itemValue in groupObject["Items"].GetArray())
            //    {
            //        JsonObject itemObject = itemValue.GetObject();
            //        group.Items.Add(new SampleDataItem(itemObject["UniqueId"].GetString(),
            //                                           itemObject["Title"].GetString(),
            //                                           itemObject["Subtitle"].GetString(),
            //                                           itemObject["ImagePath"].GetString(),
            //                                           itemObject["Description"].GetString(),
            //                                           itemObject["Content"].GetString()));
            //    }
            //    this.Groups.Add(group);

        }
    }
}
