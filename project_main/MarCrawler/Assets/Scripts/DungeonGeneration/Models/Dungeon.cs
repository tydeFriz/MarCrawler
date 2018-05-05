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

	public void DEBUG_TEST_ONY_printDungeon(){
		TestLogger.log("x:"+grid.sizeX+" y:"+grid.sizeY);
		for(int x = 0; x < grid.sizeX; x++){

			string line = "";

			for(int y = 0; y < grid.sizeY; y++){
				char temp = grid.grid[x, y];
				if(temp == 'w') temp = '█';
				if(temp == '_') temp = '.';
				if(temp == 'D') temp = '▒';
				if(temp == 'S') temp = '▓';
				if(temp == 'T') temp = '§';

				line += temp;
			}

			TestLogger.log(line);
		}
	}

}