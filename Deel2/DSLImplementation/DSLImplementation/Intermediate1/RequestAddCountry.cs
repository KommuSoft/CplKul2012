using System;
namespace DSLImplementation.IntermediateCode
{
	public class RequestAddCountry : XmlRequestBase
	{
		public RequestAddCountry (Country Country){
			this.Country = Country;
		}		

		public Country Country{ get; set;}
		
		public override IAnswer execute(){
			Database.Country c = new Database.Country(this.Country.Name);

			AnswerAdd aa = new AnswerAdd();
			try{
				c.insert();
			} catch(Exception e){
				aa = new AnswerAdd(e.Message);
			}

			return aa;
		}
		
	}
}

