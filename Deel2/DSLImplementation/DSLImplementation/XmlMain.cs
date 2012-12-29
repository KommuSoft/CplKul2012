using System;
using System.Xml.Serialization;
using System.IO;

namespace DSLImplementation.XmlRepresentation{
	public class XmlMain{
		public static void Main (string[] args){
				Country c = new Country("Belgie");
				CityRequest cr = new CityRequest(c);
				XmlSerializer s = new XmlSerializer(typeof(CityRequest));
				FileStream fs = File.Open("test.xml", FileMode.Create, FileAccess.Write);
				s.Serialize(fs, cr);
				fs.Close();
		}
	}
}

