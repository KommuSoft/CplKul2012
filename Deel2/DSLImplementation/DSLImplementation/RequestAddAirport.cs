using System;
using System.Xml.Serialization;
namespace DSLImplementation.XmlRepresentation
{
	[XmlRoot("RequestAddAirport")]
	public class RequestAddAirport : XmlRequestBase
	{
		public RequestAddAirport ()
		{
		}
		
		public RequestAddAirport (Airport Airport){
			this.Airport = Airport;
		}
		
		[XmlElement("Airport")]
		public Airport Airport{
			get;
			set;
		}	

		public override IXmlAnswer execute ()
		{
			Database.CountryRequest cor = new Database.CountryRequest ();
			Database.CityRequest cir = new Database.CityRequest ();

			int countryID = cor.fetchCountryFromName (this.Airport.Country.Name)[0].ID;
			int cityID = cir.fetchCityFromName (this.Airport.City.Name)[0].ID;

			AnswerAdd aa = new AnswerAdd ();
			Database.Airport airport = new Database.Airport (name: this.Airport.Name, code: this.Airport.Code, country: countryID, city: cityID);

			try {
				airport.insert();
			} catch (Exception e) {
				aa = new AnswerAdd(e.Message);
			}

			return aa;
		}
		
	}
}

