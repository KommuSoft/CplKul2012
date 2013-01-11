using System;
using System.Collections.Generic;
using System.Linq;


namespace DSLImplementation.IntermediateCode{
	
	public class RequestGetFlights : XmlRequestBase {

		public RequestGetFlights (Airport Airport1, Airport Airport2, DateTime Start = default(DateTime), Airline Airline = null, SeatClass SeatClass = null)
		{
			this.Airport1 = Airport1;
			this.Airport2 = Airport2;
			setCommon(Start, Airline, SeatClass);
		}

		public RequestGetFlights (City City1, City City2, DateTime Start = default(DateTime), Airline Airline = null, SeatClass SeatClass = null)
		{
			this.City1 = City1;
			this.City2 = City2;
			setCommon(Start, Airline, SeatClass);
		}

		public RequestGetFlights (Country Country1, Country Country2, DateTime Start = default(DateTime), Airline Airline = null, SeatClass SeatClass = null)
		{
			this.Country1 = Country1;
			this.Country2 = Country2;
			setCommon(Start, Airline, SeatClass);
		}

		private void setCommon (DateTime Start, Airline Airline, SeatClass SeatClass)
		{
			this.Start = Start;
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
				Database.FlightTemplate ft = ftr.fetchFromID(f.template)[0];
				Database.Airline airline_ = alr.fetchFromID(ft.airline)[0];

				Airline airline = new Airline(Name: airline_.name, Code: airline_.code);
				FlightTemplate template = new FlightTemplate(ft.digits, airline);

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
				
				Airplane airplane = new Airplane(airplane_.type, seats, airplane_.code);
				
				fs.Add(new Flight(template, f.start, f.end, startAirport, destinationAirport, airplane));
			}

			return fs;
		}

		private int getAirlineID ()
		{
			int airlineID = -1;
			if (this.Airline != null) {
				Database.AirlineRequest alr = new Database.AirlineRequest();

				List<Database.Airline> airlines = alr.fetchAirlineFromCode(this.Airline.Code);
				if(airlines.Count() != 1){
					throw new Exception("A (unique) airline with code " + this.Airline.Code + " couldn't be found.");
				}
				airlineID = airlines[0].ID;
			}

			return airlineID;
		}

		private int getClassID ()
		{
			int classID = -1;
			if (this.SeatClass != null) {
				Database.ClassRequest cr = new Database.ClassRequest();
				List<Database.Class> classes = cr.fetchClassFromName(this.SeatClass.Name);
				if(classes.Count() != 1){
					throw new Exception("A (unique) class with name " + this.SeatClass.Name + " could not be found.");
				}
				classID = classes[0].ID;
			}

			return classID;
		}

		private List<Database.Flight> doDispatch (Database.ILocatable start, Database.ILocatable end)
		{
			Database.FlightRequest fr = new Database.FlightRequest ();
			int airlineID = getAirlineID();
			int classID = getClassID();
			
			if (this.Airline != null) {
				if (this.SeatClass != null) {
					return fr.fetchFlight (start, end, startDateTime: Start, class_: classID, airline: airlineID);
				} else {
					return fr.fetchFlight (start, end, startDateTime: Start, airline: airlineID);
				}
			} else {
				if (this.SeatClass != null) {
					return fr.fetchFlight (start, end, startDateTime: Start, class_: classID);
				} else {
					return fr.fetchFlight (start, end, startDateTime: Start);
				}
			}
		}

		private List<Database.Flight> executeOnAirport ()
		{
			Database.AirportRequest ar = new Database.AirportRequest ();

			List<Database.Airport> airports = ar.fetchAirportFromCode (this.Airport1.Code);
			if (airports.Count () != 1) {
				throw new Exception ("A (unique) airport with code " + this.Airport1.Code + " couldn't be found");
			}
			Database.Airport airport1 = airports [0];

			airports = ar.fetchAirportFromCode (this.Airport2.Code);
			if (airports.Count () != 1) {
				throw new Exception("A (unique) airport with code " + this.Airport2.Code + " couldn't be found");
			}
			Database.Airport airport2 = airports [0];

			return doDispatch(airport1, airport2);
		}

		private List<Database.Flight> executeOnCity ()
		{
			Database.CityRequest cr = new Database.CityRequest ();

			List<Database.City> cities = cr.fetchFromNameAndCountry (City1.Name, City1.Country.Name);
			if (cities.Count () != 1) {
				throw new Exception ("A (unique) city with name " + City1.Name + " and country " + City1.Country.Name + " couldn't be found");
			}
			Database.City startCity = cities [0];

			cities = cr.fetchFromNameAndCountry (City2.Name, City2.Country.Name);
			if (cities.Count () != 1) {
				throw new Exception("A (unique) city with name " + City2.Name + " and country " + City2.Country.Name + " couldn't be found");
			}
			Database.City endCity = cities [0];

			return doDispatch(startCity, endCity);
		}

		private List<Database.Flight> executedOnCountry ()
		{
			Database.CountryRequest cr = new Database.CountryRequest ();

			List<Database.Country> countries = cr.fetchCountryFromName (Country1.Name);
			if (countries.Count () != 1) {
				throw new Exception ("A (unique) country with name " + Country1.Name + " couldn't be found");
			}
			Database.Country startCountry = countries [0];

			countries = cr.fetchCountryFromName (Country2.Name);
			if (countries.Count () != 1) {
				throw new Exception("A (unique) country with name " + Country2.Name + " couldn't be found");
			}
			Database.Country endCountry = countries [0];

			return doDispatch(startCountry, endCountry);
		}

		public override IAnswer execute ()
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

