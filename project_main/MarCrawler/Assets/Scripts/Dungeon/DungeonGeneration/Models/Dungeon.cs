using System.Collections.Generic;

public class Dungeon{

	//LATER_PATCH: public string type;
	public int seed;
	public DungeonGrid grid;
	public List<DungeonRoom> rooms;
	public List<Treasure> treasures;
	//LATER_PATCH: public List<Traps> trap;

	public Dungeon(DungeonGrid grid, List<DungeonRoom> rooms, List<Treasure> treasures, int seed){
		this.seed = seed;
		this.rooms = rooms;
		this.treasures = setTreasures(treasures);
		this.grid = borderGrid(grid);
	}

	public  Coordinates getStartingPosition(){
		return grid.find(Constants.ENTRANCE_MARKER);
	}
		
	public  Coordinates getExitPosition(){
		return grid.find(Constants.EXIT_MARKER);
	}

	public bool canWalk(Coordinates to){
		return grid.isPath(to);
	}

	public Coordinates useDoor(Coordinates playerPosition, Coordinates doorPosition){
		if (!grid.isDoor (doorPosition))
			return playerPosition;
		return grid.getOtherDoorSide (playerPosition, doorPosition);
	}

	public Treasure openTreasure(Coordinates position){
		if (!grid.isTreasure (position))
			return null;
		foreach (Treasure t in treasures) {
			if(position.Equals(t.position))
				return t;
		}
		return null;
	}

	//////////////////////////////////////////////////////////////////////////////////
	/*										|										*/
	/* 									 PRIVATES									*/
	/*										|										*/
	//////////////////////////////////////////////////////////////////////////////////

	private List<Treasure> setTreasures(List<Treasure> treasures){

		foreach (Treasure treasure in treasures) {
			treasure.position.x = treasure.position.x + 1;
			treasure.position.y = treasure.position.y + 1;
		}

		return treasures;
	}

	private DungeonGrid borderGrid(DungeonGrid grid){

		int x = grid.sizeX + 2;
		int y = grid.sizeY + 2;
		char[,] fullGrid = new char[x,y];

		for(int i = 0; i < x; i++){
			fullGrid [i, 0] = Constants.WALL_MARKER;
			fullGrid [i, y-1] = Constants.WALL_MARKER;
		}
		for(int i = 0; i < y; i++){
			fullGrid [0, i] = Constants.WALL_MARKER;
			fullGrid [x-1, i] = Constants.WALL_MARKER;
		}

		for(int i = 0; i < grid.sizeX; i++){
			for(int j = 0; j < grid.sizeY; j++){
				fullGrid[i + 1, j + 1] = grid.grid[i, j];
			}
		}

		return new DungeonGrid (x, y, fullGrid);
	}

}