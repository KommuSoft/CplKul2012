using System;
using System.Xml.Serialization;
using System.Collections.Generic;


namespace DSLImplementation.XmlRepresentation
{
	[XmlRoot("RequestGetCity")]
	public class RequestGetCities : XmlRequestBase
	{
		public RequestGetCities ()
		{
		}
		
		public RequestGetCities(Country Country){
			this.Country = Country;
		}
		
		[XmlElement("Country")]
		public Country Country {
			get;
			set;
		}

		public override IXmlAnswer execute()
		{
			Database.CityRequest cr = new Database.CityRequest();
			List<Database.City> cities = cr.fetchCityFromCountry(new Database.Country(this.Country.Name));
			List<City> resultCities = new List<City>();
			foreach(Database.City c in cities){
				resultCities.Add(new City(Name: c.name, Country: this.Country));
			}

			return new AnswerGetCities(resultCities);
		}
		
	}
}

