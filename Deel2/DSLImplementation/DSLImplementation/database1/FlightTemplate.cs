using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace DSLImplementation.Database
{
	public class FlightTemplate : DatabaseTable
	{
		public string code { get; set; }
		public int airline { get; set; }
		public string digits { get; set; }

		public override string tableName ()
		{
			return "flight_template";
		}

		public FlightTemplate ()
		{
			this.code = "";
		}

		public FlightTemplate (int airline, string digits)
		{
			this.airline = airline;
			this.digits = digits;
		}

		public FlightTemplate (IDataReader reader)
		{
			this.ID = reader.GetInt32(reader.GetOrdinal("id"));
			this.airline = reader.GetInt32(reader.GetOrdinal("airline"));
			this.digits = reader.GetString(reader.GetOrdinal("digits"));
		}

		public string generateCode ()
		{
			AirlineRequest ar = new AirlineRequest();
			code = ar.fetchFromID(airline)[0].code + digits;
			return code;
		}

		protected override bool isValid (out string exceptionMessage)
		{
			if (digits.Length != 3 && digits.Length != 4) {
				return makeExceptionMessage (out exceptionMessage, "The digits of the template are invalid (it has the wrong size)");
			}

			if (!digits.All (char.IsDigit)) {
				return makeExceptionMessage(out exceptionMessage, "The digits of the template are invalid (they aren't all digits)");
			}

			return validAirline(airline, out exceptionMessage);
		}

		public override int insert ()
		{
			List<string> columns = new List<string>{"code"};
			List<object> values = new List<object>{code};
			
			return base.insert(columns, values);
		}

	}
}

