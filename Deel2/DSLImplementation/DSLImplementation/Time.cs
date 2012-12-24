using System;
namespace DSLImplementation
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
			get { return this.year; }

			set { this.year = value; }
		}		
		
		[XmlAttribute("Month")]
		public String Month {
			get { return this.month; }

			set { this.month = value; }
		}
		
		[XmlAttribute("Day")]
		public String Day {
			get { return this.day; }

			set { this.day = value; }
		}
		
		[XmlAttribute("Hour")]
		public String Hour {
			get { return this.hour; }

			set { this.hour = value; }
		}
		
		[XmlAttribute("Minute")]
		public String Minute {
			get { return this.minute; }

			set { this.minute = value; }
		}
		
	}
}

