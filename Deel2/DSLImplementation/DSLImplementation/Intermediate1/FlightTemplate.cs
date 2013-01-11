using System;
namespace DSLImplementation.IntermediateCode
{
	public class FlightTemplate
	{
		public FlightTemplate (string Code) {
			this.Code = Code;
		}

		public FlightTemplate (string digits, Airline airline)
		{
			this.digits = digits;
			this.airline = airline;
		}

		public string digits { get; set; }
		public Airline airline { get; set; }
		public String Code {
			get{
				if(code == null){
					Code = airline.Code + digits;
				}
				return code;
			}
			set{
				this.code = value;
			}
		}
		private string code;
	}
}

