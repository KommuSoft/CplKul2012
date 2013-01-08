using System;
using System.Xml.Serialization;
using System.Collections.Generic;


namespace DSLImplementation.XmlRepresentation{

	[XmlRoot("RequestGetFlights")]
	public class RequestGetFlights : XmlRequestBase {

		public RequestGetFlights (){
		}
		
		public RequestGetFlights(Airport Airport1, Airport Airport2, DateTime Time, Airline Airline, SeatClass SeatClass){//TODO: manier zoeken om verschillende types mee te geven: airports, cities, countries
			this.Airport1 = Airport1;
			this.Airport2 = Airport2;
			this.Time = Time;
			this.Airline = Airline;
			this.SeatClass = SeatClass;
		}

		[XmlElement("Airport1")]
		public Airport Airport1 {
			get;
			set;
		}
		
		[XmlElement("Airport2")]
		public Airport Airport2{
			get;
			set;
		}
		
		[XmlElement("Time")]
		public DateTime Time{
			get;
			set;
		}
		
		[XmlElement("Airline")]
		public Airline Airline{
			get;
			set;
		}
		
		[XmlElement("Class")]
		public SeatClass SeatClass{
			get;
			set;
		}

		public override IXmlAnswer execute ()
		{
			Database.FlightRequest fr = new Database.FlightRequest ();
			Database.AirportRequest ar = new Database.AirportRequest();

			Database.FlightTemplateRequest ftr = new Database.FlightTemplateRequest();
			Database.AirlineRequest alr = new Database.AirlineRequest();
			Database.AirplaneRequest apr = new Database.AirplaneRequest();
			Database.LocationRequest lr = new Database.LocationRequest();
			Database.SeatRequest sr = new Database.SeatRequest();
			Database.ClassRequest cr = new Database.ClassRequest();
			Database.CountryRequest cor = new Database.CountryRequest();
			Database.CityRequest cir = new Database.CityRequest();

			int airport1ID = ar.fetchAirportFromCode(this.Airport1.Code)[0].ID;
			int airport2ID = ar.fetchAirportFromCode(this.Airport2.Code)[0].ID;

			if (this.Airline == null) {
				//TODO gebruik dit
			}

			if (this.SeatClass == null) {
				//TODO gebruik dit
			}

			List<Database.Flight> dfs = fr.fetchFlight(airport1ID, airport2ID);
			List<Flight> fs = new List<Flight>();
			foreach(Database.Flight f in dfs){
				FlightTemplate template = new FlightTemplate(ftr.fetchFromID(f.template)[0].code);
				Airline airline = new Airline(alr.fetchFromID(f.airline)[0].code);

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

			return new AnswerGetFlights(fs);
		}
		
	}
}

