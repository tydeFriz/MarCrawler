using System.Collections.Generic;

public class Dungeon{

	//LATER_PATCH: public string type;
	public DungeonGrid grid;
	public List<DungeonRoom> rooms;
	public List<Treasure> treasures;
	//LATER_PATCH: public List<Traps> trap;

	public Dungeon(DungeonGrid grid, List<DungeonRoom> rooms, List<Treasure> treasures){
		this.grid = grid;
		this.rooms = rooms;
		this.treasures = treasures;
	}
}