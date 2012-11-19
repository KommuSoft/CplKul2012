public class Car{
	//attributes
	private int speed;
	
	//constructor
	public Car(){
		this.speed = 0;
	}

	//other methods
	public void accelerate(int speedIncrease){
		this.speed += speedIncrease;
	}
}
