using System;
using System.Collections.Generic;
namespace DSLImplementation.IntermediateCode{
	
	public class RequestGetFlights : XmlRequestBase {

		public RequestGetFlights (Airport Airport1, Airport Airport2, DateTime Start = default(DateTime))
		{
			this.Airport1 = Airport1;
			this.Airport2 = Airport2;
			this.Start = Start;
		}

		public RequestGetFlights (City City1, City City2, DateTime Start = default(DateTime))
		{
			this.City1 = City1;
			this.City2 = City2;
			this.Start = Start;
		}

		public RequestGetFlights (Country Country1, Country Country2, DateTime Start = default(DateTime))
		{
			this.Country1 = Country1;
			this.Country2 = Country2;
			this.Start = Start;
		}
		
		public RequestGetFlights(Airport Airport1, Airport Airport2, DateTime Time, Airline Airline, SeatClass SeatClass){//TODO: manier zoeken om verschillende types mee te geven: airports, cities, countries
			//TODO: deze constructor zal volledig verdwijnen en zal vervangen door de bovenstaaande
			this.Airport1 = Airport1;
			this.Airport2 = Airport2;
			this.Airline = Airline;
			this.SeatClass = SeatClass;
		}

		public Airport Airport1 { get; set; }
		public Airport Airport2 { get; set;	}
		public Airline Airline { get; set; }
		public SeatClass SeatClass { get; set; }
		public DateTime Start { get; set; }
		public City City1 { get; set; }
		public City City2 { get; set; }
		public Country Country1 { get; set; }
		public Country Country2 { get; set; }

		private List<Flight> adapt (List<Database.Flight> dfs)
		{
			Database.FlightTemplateRequest ftr = new Database.FlightTemplateRequest();
			Database.AirlineRequest alr = new Database.AirlineRequest();
			Database.AirplaneRequest apr = new Database.AirplaneRequest();
			Database.LocationRequest lr = new Database.LocationRequest();
			Database.SeatRequest sr = new Database.SeatRequest();
			Database.ClassRequest cr = new Database.ClassRequest();
			Database.CountryRequest cor = new Database.CountryRequest();
			Database.CityRequest cir = new Database.CityRequest();
			Database.AirportRequest ar = new Database.AirportRequest();

			List<Flight> fs = new List<Flight>();
			foreach(Database.Flight f in dfs){
				FlightTemplate template = new FlightTemplate(ftr.fetchFromID(f.template)[0].code);
				Database.Airline airline_ = alr.fetchFromID(f.airline)[0];
				Airline airline = new Airline(Name: airline_.name, Code: airline_.code);
				
				Database.Location l = lr.fetchFromID(f.location)[0];
				Database.Airport startAirport_ = ar.fetchFromID(l.start_airport)[0];
				Database.Airport destinationAirport_ = ar.fetchFromID(l.destination_airport)[0];
				
				Country startCountry = new Country(cor.fetchFromID(startAirport_.country)[0].name);
				Country destinationCountry = new Country(cor.fetchFromID(destinationAirport_.country)[0].name);
				
				City startCity = new City(cir.fetchFromID(startAirport_.city)[0].name, startCountry);
				City destinationCity = new City(cir.fetchFromID(destinationAirport_.city)[0].name, destinationCountry);
				
				Airport startAirport = new Airport(startAirport_.name, startAirport_.code, startCity);
				Airport destinationAirport = new Airport(destinationAirport_.name, destinationAirport_.code, destinationCity);
				
				Database.Airplane airplane_ = apr.fetchFromID(f.airplane)[0];
				
				List<Seat> seats = new List<Seat>();
				foreach(int s in airplane_.seat){
					Database.Seat seat_ = sr.fetchFromID(s)[0];
					Database.Class seatClass_ = cr.fetchFromID(seat_.class_)[0];
					SeatClass seatClass = new SeatClass(seatClass_.name);
					seats.Add(new Seat(seatClass, seat_.number));
				}
				
				Airplane airplane = new Airplane(airplane_.type, seats);
				
				fs.Add(new Flight(template, airline, f.start, f.end, startAirport, destinationAirport, airplane));
			}

			return fs;
		}

		private List<Database.Flight> executeOnAirport ()
		{
			Database.FlightRequest fr = new Database.FlightRequest ();
			Database.AirportRequest ar = new Database.AirportRequest ();

			int airport1ID = ar.fetchAirportFromCode(this.Airport1.Code)[0].ID;
			int airport2ID = ar.fetchAirportFromCode(this.Airport2.Code)[0].ID;
			
			if (this.Airline == null) {
				//TODO gebruik dit
			}
			
			if (this.SeatClass == null) {
				//TODO gebruik dit
			}

			if (Start != default(DateTime)) {
				return fr.fetchFlight(airport1ID, airport2ID, startDateTime: Start);
			} 
			
			return fr.fetchFlight(airport1ID, airport2ID);
		}

		private List<Database.Flight> executeOnCity ()
		{
			Database.CityRequest cr = new Database.CityRequest ();
			Database.FlightRequest fr = new Database.FlightRequest ();

			Database.City startCity = cr.fetchFromNameAndCountry (City1.Name, City1.Country.Name) [0];
			Database.City endCity = cr.fetchFromNameAndCountry (City2.Name, City2.Country.Name) [0];

			if (Start != default(DateTime)) {
				return fr.fetchFlight(startCity, endCity, startDateTime: Start);
			} 

			return fr.fetchFlight(startCity, endCity);
		}

		private List<Database.Flight> executedOnCountry ()
		{
			Database.CountryRequest cr = new Database.CountryRequest ();
			Database.FlightRequest fr = new Database.FlightRequest ();

			Database.Country startCountry = cr.fetchCountryFromName (Country1.Name) [0];
			Database.Country endCountry = cr.fetchCountryFromName (Country2.Name) [0];

			if (Start != default(DateTime)) {
				return fr.fetchFlight(startCountry, endCountry, startDateTime: Start);
			}

			return fr.fetchFlight(startCountry, endCountry);
		}

		public override IXmlAnswer execute ()
		{
			List<Database.Flight> flights = new List<DSLImplementation.Database.Flight> ();
			if (Airport1 != null && Airport2 != null) {
				flights = executeOnAirport ();
			} else if (City1 != null && City2 != null) {
				flights = executeOnCity ();
			} else if (Country1 != null & Country2 != null) {
				flights = executedOnCountry();
			}

			return new AnswerGetFlights(adapt (flights));
		}
		
	}
}

