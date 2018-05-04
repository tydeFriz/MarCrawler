using System;
using System.Collections;
using System.Collections.Generic;

public class DungeonGenerationController {
	
	public Dungeon generateDungeon(int seed){
		Random rand = new Random(seed);

		//LATER_PATCH: scegli tipo di dungeon

		//scegli layout
		DungeonLayout layout = DungeonDispatcher.getDungeonLayoutById((rand.Next() % Constants.LAYOUTS_COUNT)+1);

		//scegli stanze
		List<DungeonRoom> rooms = new List<DungeonRoom>();
		foreach(PseudoRoom room in layout.rooms){
			DungeonRoom pickedRoom = DungeonDispatcher.getDungeonRoomByType (room.sizeX, room.sizeY, rand.Next());
			layout.grid.paste(pickedRoom.grid, room.position);
			rooms.Add(pickedRoom);
		}

		List<Treasure> treasures = new List<Treasure>();
		//crea percorsi
		List<List<Coordinates>> pathableAreas = layout.grid.findAreas('.');
		foreach (List<Coordinates> area in pathableAreas) {
			double rateo = (layout.grid.countArea(area) / layout.grid.countPerimeter(area))*100;
			rateo = 5000 + 50*rateo;
			shufflePaths(layout.grid, area, rateo, rand);
			//TODO: make sure all doors touching the 
			List<List<Coordinates>> tempPaths = layout.grid.findAreas('_');
			//TODO: link all paths using DungeonGrid.drawPath(...)
			// define areas' realtive distances
			// starting from  closer ones, pick closer points and start drawing lines
			// re-evaluate areas
		}

		//inserisci tesori
		foreach(DungeonRoom room in rooms){
			foreach(Treasure treasure in room.treasures){
				treasures.Add(TreasureInitializer.initializeTreasure(treasure, rand.Next()));
			}
		}

		//add treasures to paths

		//LATER_PATCH: inserisci trappole

		return (new Dungeon(layout.grid, rooms, treasures/*LATER_PATCH: , traps*/));

	}

	//////////////////////////////////////////////////////////////////////////////////
	/*										|										*/
	/* 									 PRIVATES									*/
	/*										|										*/
	//////////////////////////////////////////////////////////////////////////////////

	private void shufflePaths(DungeonGrid grid, List<Coordinates> area, double rateo, Random rand){
		foreach(Coordinates position in area){
			int rnd = (rand.Next() % 10000) + 1;
			grid.grid[position.x, position.y] = rnd > rateo ? '_' : 'w';
		}
	}
}