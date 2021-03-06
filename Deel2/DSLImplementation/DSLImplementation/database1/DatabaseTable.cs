using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;

namespace DSLImplementation.Database
{
	public abstract class DatabaseTable
	{
		private bool hasID = false;
		private int id;
		
		public int ID {
			get {
				return id;
			}
			set{
				hasID = true;
				id = value;
			}
		}

		public abstract string tableName();

		protected string createInsertQuery (string table, List<String> columns, List<Object> values)
		{
			string query = "INSERT INTO " + table;
			string columnQuery = String.Join(", ", columns.ToArray());
			string valuequery = String.Join(", ", values.Select(x => Util.parse(x)).ToArray());
			
			return query + "(" + columnQuery + ") VALUES(" + valuequery + ")";
		}

		protected abstract bool isValid(out string exceptionMessage);

		public virtual int insert ()
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
			return validColumn(new FlightTemplateRequest(), id, out exceptionMessage);
		}

		protected virtual int insert (List<string> columns, List<object> values)
		{
			if (hasID) {
				columns.Insert(0, "id");
				values.Insert(0, ID);
			}

			string exceptionMessage;
			if (!isValid (out exceptionMessage)) {
				throw new InvalidObjectException (exceptionMessage);
			}
			
			string query = createInsertQuery(tableName(), columns, values) + " RETURNING id";

			Database db = new Database();
			IDataReader reader = db.CreateCommand(query);

			reader.Read();
			int id = reader.GetInt32(reader.GetOrdinal("id"));

			return id;
		}
	}
}

