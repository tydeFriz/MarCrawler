using System;

public class PathableArea{
		
	public Coordinates position;
	public int sizeX;
	public int sizeY;

	public PathableArea(Coordinates position, int sizeX, int sizeY){
		this.position = new Coordinates(position);
		this.sizeX = sizeX;
		this.sizeY = sizeY;
	}

}