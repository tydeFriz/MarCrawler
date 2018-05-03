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
		char[,] grid = layout.grid;
		foreach(PseudoRoom room in layout.rooms){
			DungeonRoom pickedRoom = DungeonDispatcher.getDungeonRoomByType (room.sizeX, room.sizeY, rand.Next());
			GridPaster.pasteAinB (pickedRoom.grid, grid, pickedRoom.sizeX, pickedRoom.sizeY, layout.sizeX, layout.sizeY, room.posX, room.posY);
			rooms.Add(pickedRoom);
		}

		//crea percorsi \\TODO
		List<Treasure> treasures = new List<Treasure>();

		//inserisci tesori \\TODO

		foreach(DungeonRoom room in rooms){
			foreach(Treasure treasure in room.treasures){
				treasures.Add(TreasureInitializer.initializeTreasure(treasure, rand.Next));
			}
		}

		//LATER_PATCH: inserisci trappole

		return (new Dungeon(layout.sizeX , layout.sizeY , rooms, grid, treasures/*LATER_PATCH: , traps*/));

	}
}