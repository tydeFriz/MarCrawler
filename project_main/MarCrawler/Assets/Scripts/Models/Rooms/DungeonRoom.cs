using System.Collections.Generic;

public abstract class DungeonRoom {

	public int sizeX;
	public int sizeY;
	public char[,] grid;
	public List<Treasure> treasures;
	public string modelFileName;
	//LATER_PATCH - maybe: list of "notables" 
}
