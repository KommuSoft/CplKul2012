using System;
using System.Collections.Generic;
using System.Linq;

namespace DSLImplementation.Database
{
	public abstract class DatabaseTable
	{
		public abstract string tableName();

		protected string createInsertQuery (string table, List<String> columns, List<Object> values)
		{
			string query = "INSERT INTO " + table;
			string columnQuery = String.Join(", ", columns.ToArray());
			string valuequery = String.Join(", ", values.Select(x => Util.parse(x)).ToArray());
			
			return query + "(" + columnQuery + ") VALUES(" + valuequery + ")";
		}

		protected abstract bool isValid(out string exceptionMessage);

		public virtual void insert ()
		{
			throw new Exception ("Not implemented yet");
		}

		protected bool makeExceptionMessage (out string exceptionMessage, string message = "")
		{
			if (message.Length == 0) {
				exceptionMessage = message;
				return true;
			}
			exceptionMessage = message;
			return false;
		}

		private bool validColumn <T> (DatabaseRequest<T> request, int id, out string exceptionMessage)
		{
			if (request.fetchFromID (id).Count != 1) {
				return makeExceptionMessage(out exceptionMessage, request.tableName() + "(id = " + id + ") of the " + tableName() + " is invalid");
			}

			return makeExceptionMessage(out exceptionMessage);
		}

		protected bool validCity (int id, out string exceptionMessage)
		{
			return validColumn(new CityRequest(), id, out exceptionMessage);
		}

		protected bool validCountry (int id, out string exceptionMessage)
		{
			return validColumn(new CountryRequest(), id, out exceptionMessage);
		}

		protected bool validSeat (int id, out string exceptionMessage)
		{
			return validColumn(new SeatRequest(), id, out exceptionMessage);
		}

		protected bool validPassenger (int id, out string exceptionMessage)
		{
			return validColumn(new PassengerRequest(), id, out exceptionMessage);
		}

		protected bool validFlight (int id, out string exceptionMessage)
		{
			return validColumn(new FlightRequest(), id, out exceptionMessage);
		}

		protected bool validClass (int id, out string exceptionMessage)
		{
			return validColumn(new ClassRequest(), id, out exceptionMessage);
		}

		protected bool validAirport (int id, out string exceptionMessage)
		{
			return validColumn(new AirportRequest(), id, out exceptionMessage);
		}

		protected bool validLocation (int id, out string exceptionMessage)
		{
			return validColumn(new LocationRequest(), id, out exceptionMessage);
		}

		protected bool validAirline (int id, out string exceptionMessage)
		{
			return validColumn(new AirlineRequest(), id, out exceptionMessage);
		}

		protected bool validAirplane (int id, out string exceptionMessage)
		{
			return validColumn(new AirplaneRequest(), id, out exceptionMessage);
		}

		protected bool validTemplate (int id, out string exceptionMessage)
		{
			//TODO implementeer dit
			exceptionMessage = "";
			return true;
		}

		protected virtual void insert (List<string> columns, List<object> values)
		{
			string exceptionMessage;
			if (!isValid (out exceptionMessage)) {
				throw new InvalidObjectException (exceptionMessage);
			}
			
			string query = createInsertQuery(tableName(), columns, values);
			Console.WriteLine(query);
			
			//Database db = new Database();
			//db.CreateCommand(query);
		}
	}
}

