using System.Collections.Generic;
using DSLImplementation.UserInterface;

namespace DSLImplementation.IntermediateCode
{
	public class AnswerGetCities : IXmlAnswer {		
		public AnswerGetCities (List<City> Cities)
		{
				this.Cities = Cities;
		}

		public List<City> Cities{ get; set; }

		#region IXmlAnswer implementation
		public IEnumerable<IPuzzlePiece> ToPuzzlePieces () {
			foreach(City city in Cities) {
				yield return new CityPiece(city.Name);
			}
		}
		#endregion
	
	}
}

