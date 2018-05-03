using System;

public class Coordinates{
	public int x;
	public int y;

	public Coordinates(int x, int y){
		this.x = x;
		this.y = y;
	}

	public Coordinates(Coordinates position){
		this.x = position.x;
		this.y = position.y;
	}

	public override bool Equals(Object obj){
		if (obj == null || GetType() != obj.GetType()) 
			return false;
		Coordinates coord = (Coordinates)obj;
		if (coord.x != x || coord.y != y)
			return false;
		return true;
	}

	public void setByCoords(int x, int y){
		this.x = x;
		this.y = y;
	}

	public void setByCopy(Coordinates position){
		this.x = position.x;
		this.y = position.y;
	}
}