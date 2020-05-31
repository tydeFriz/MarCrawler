using System;
using System.Collections;
using System.Collections.Generic;

public class DungeonGenerationController {
	
	public Dungeon generateDungeon(Random rand, int seed){

		//LATER_PATCH: pick dungeon type

		//scegli layout
		DungeonLayout layout = DungeonDispatcher.getDungeonLayoutById((rand.Next() % Constants.LAYOUTS_COUNT)+1);

		//scegli stanze
		List<DungeonRoom> rooms = new List<DungeonRoom>();
		foreach (PseudoRoom room in layout.rooms) {
			DungeonRoom pickedRoom = DungeonDispatcher.getDungeonRoomByType (room.sizeX, room.sizeY, rand.Next(), rand);
			layout.grid.paste(pickedRoom.grid, room.position);
			rooms.Add(pickedRoom);
		}

		//crea percorsi
		PathLinkingStrategy pathLinker = new ClosestPathLinker(); //LATER_PATCH: decide which srtategy to use
		pathLinker.linkPaths (layout, rand);
		layout.grid.normalize();

		//inserisci tesori
		List<Treasure> treasures = new List<Treasure>();

		foreach (DungeonRoom room in rooms) {
			foreach (Treasure treasure in room.treasures) {
				treasures.Add(TreasureInitializer.initializeTreasure(treasure, rand));
			}
		}

		List<Coordinates> culDeSacs = layout.grid.getCulDeSacs();
		foreach(Coordinates culDeSac in culDeSacs){
		}
		int antiChances = Constants.TREASURE_SPAWN_PERIOD;
		foreach (Coordinates point in culDeSacs) {
			if (rand.Next() % antiChances == 0) {
				layout.grid.put(point, Constants.TREASURE_MARKER);
				treasures.Add(TreasureInitializer.initializeTreasure(new Treasure(point), rand));
				antiChances = Constants.TREASURE_SPAWN_PERIOD + (treasures.Count * Constants.TREASURE_SPAWN_INCREMENTAL);
			}
			else 
				antiChances -= Constants.TREASURE_SPAWN_INCREMENTAL;
		}

		//LATER_PATCH: add traps

		return (new Dungeon(layout.grid, rooms, treasures, seed/*LATER_PATCH: , traps*/));

	}

	//////////////////////////////////////////////////////////////////////////////////
	/*										|										*/
	/* 									 PRIVATES									*/
	/*										|										*/
	//////////////////////////////////////////////////////////////////////////////////

}