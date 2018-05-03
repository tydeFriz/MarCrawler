using System.Collections.Generic;

public class Dungeon{

	//LATER_PATCH: public string type;
	public int sizeX;
	public int sizeY;
	public List<DungeonRoom> rooms;
	public char[,] grid;
	public List<Treasure> treasures;
	//LATER_PATCH: public List<Traps> trap;

	public Dungeon(int sizeX, int sizeY, List<DungeonRoom> rooms, char[,] grid, List<Treasure> treasures){
		this.sizeX = sizeX;
		this.sizeY = sizeY;
		this.rooms = rooms;
		this.grid = grid;
		this.treasures = treasures;
	}
}