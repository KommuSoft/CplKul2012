using System.Collections.Generic;
using System.Xml.Serialization;
using DSLImplementation.UserInterface;

namespace DSLImplementation.XmlRepresentation
{
	[XmlRoot("CityAnswer")]
	public class AnswerGetCities : IXmlAnswer {
		
		public AnswerGetCities(){
		}
		
		public AnswerGetCities (List<City> Cities)
		{
				this.Cities = Cities;
		}
		
		[XmlArray("ListOfCities")]
		[XmlArrayItem("City")]
		public List<City> Cities{
			get;
			set;
		}

		#region IXmlAnswer implementation
		public IEnumerable<IPuzzlePiece> ToPuzzlePieces () {
			foreach(City city in Cities) {
				yield return new CityPiece();
			}
		}
		#endregion
	
	}
}

