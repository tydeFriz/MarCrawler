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
			GridPaster.pasteAinB (pickedRoom.grid, grid, pickedRoom.sizeX, pickedRoom.sizeY, layout.sizeX, layout.sizeY, room.position);
			rooms.Add(pickedRoom);
		}

		List<Treasure> treasures = new List<Treasure>();
		//crea percorsi
		List<List<Coordinates>> areas = findAreas(grid, '.');
		foreach (List<Coordinates> area in areas) {
			double rateo = (countArea (area) / countPerimeter (area))*100;
			rateo = 5000 + 50*rateo;
			shufflePaths(grid, area, rateo, rand);
			List<List<Coordinates>> tempPaths = findAreas(grid, '_');
			//TODO: link all paths using GridDrawer.drawPath(...)
		}

		//inserisci tesori
		foreach(DungeonRoom room in rooms){
			foreach(Treasure treasure in room.treasures){
				treasures.Add(TreasureInitializer.initializeTreasure(treasure, rand.Next()));
			}
		}
		//TODO: add treasures to paths

		//LATER_PATCH: inserisci trappole

		return (new Dungeon(layout.sizeX , layout.sizeY , rooms, grid, treasures/*LATER_PATCH: , traps*/));

	}

	private int countArea(List<Coordinates> area){
		return area.Count;
	}

	private int countPerimeter(List<Coordinates> area){
		//TODO
		int count = 0;
		//raster area
		//foreach element in area increment count based on how many perimeters it has
		return count;
	}

	private List<List<Coordinates>> findAreas(char[,] grid, char marker){ //TODO
		//cerca un marker nella griglia
		//estendi fino a trovare tutti i marker raggiungibili
		//cerca un nuovo marker non trovato e ripeti
	}

	private char[,] shufflePaths(char[,] grid, List<Coordinates> area, double rateo, Random rand){
		foreach(Coordinates position in area){
			int rnd = (rand.Next() % 10000) + 1;
			grid[position.x, position.y] = rnd > rateo ? '_' : 'w';
		}

		return grid;
	}
}