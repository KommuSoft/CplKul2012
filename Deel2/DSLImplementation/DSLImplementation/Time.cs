using System;
using System.Xml.Serialization;
namespace DSLImplementation.XmlRepresentation
{
	[XmlType("Time")]
	public class Time
	{
		public Time ()
		{
		}
		
		public Time(String Year, String Month, String Day, String Hour, String Minute){
			this.Year = Year;
			this.Month = Month;
			this.Day = Day;
			this.Hour = Hour;
			this.Minute = Minute;
		}

		[XmlAttribute("Year")]
		public String Year {
			get;

			set;
		}		
		
		[XmlAttribute("Month")]
		public String Month {
			get;

			set;
		}
		
		[XmlAttribute("Day")]
		public String Day {
			get;

			set;
		}
		
		[XmlAttribute("Hour")]
		public String Hour {
			get;

			set;
		}
		
		[XmlAttribute("Minute")]
		public String Minute {
			get;

			set;
		}
		
	}
}

