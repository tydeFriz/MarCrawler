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
		foreach (PseudoRoom room in layout.rooms) {
			DungeonRoom pickedRoom = DungeonDispatcher.getDungeonRoomByType (room.sizeX, room.sizeY, rand.Next());
			layout.grid.paste(pickedRoom.grid, room.position);
			rooms.Add(pickedRoom);
		}

		//crea percorsi
		foreach (PathableArea area in layout.pathableAreas){
			double rateo = ((double)layout.grid.countArea(area) / (double)layout.grid.countPerimeter(area));
			rateo = 5000*(rateo);
			if (rateo > 9000)
				rateo = 9000;
			if (rateo < 1000)
				rateo = 1000;
			shufflePaths(layout.grid, area, rateo, rand);
			mergePaths(layout.grid, area, rand);
		}
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
		int antiChances = 100;
		foreach (Coordinates point in culDeSacs) {
			if (rand.Next() % antiChances == 0) {
				layout.grid.put(point, Constants.TREASURE_MARKER);
				treasures.Add(TreasureInitializer.initializeTreasure(new Treasure(point), rand));
				antiChances = 100 + (treasures.Count * 9);
			}
			else 
				antiChances -= 9;
		}

		//LATER_PATCH: inserisci trappole

		return (new Dungeon(layout.grid, rooms, treasures, seed/*LATER_PATCH: , traps*/));

	}

	//////////////////////////////////////////////////////////////////////////////////
	/*										|										*/
	/* 									 PRIVATES									*/
	/*										|										*/
	//////////////////////////////////////////////////////////////////////////////////

	private void shufflePaths(DungeonGrid grid, PathableArea area, double rateo, Random rand){

		for(int x = area.position.x; x < area.sizeX + area.position.x; x++){
			for(int y = area.position.y; y < area.sizeY + area.position.y; y++){
				Coordinates position = new Coordinates(x, y);
				if(grid.hasDoorsTouching(position)) grid.grid[position.x, position.y] = Constants.PATH_MARKER;
				else{
					int rnd = (rand.Next() % 10000) + 1;
					grid.grid[position.x, position.y] = rnd > rateo ? Constants.PATH_MARKER : Constants.PATHABLE_MARKER;
				}
			}
		}
	}

	private void mergePaths(DungeonGrid grid, PathableArea area, Random rand){
		
		List<List<Coordinates>> tempPaths = grid.findAreas(Constants.PATH_MARKER, area.position, new Coordinates(area.position.x + area.sizeX, area.position.y + area.sizeY));
		if (tempPaths.Count == 1)
			return;

		bool[,] linkedGraph = new bool[tempPaths.Count, tempPaths.Count];

		for(int i = 0; i < tempPaths.Count; i++){
			for(int j = 0; j < tempPaths.Count; j++){
				linkedGraph[i, j] = (i == j ? true : false);
			}
		}

		int actual = 0;
		foreach (List<Coordinates> tempPath in tempPaths) {
			//LATER_PATCH: make linkTo the closer path, not random
			int linkTo = rand.Next () % tempPaths.Count; 
			int count = 0;
			while(linkedGraph[actual, linkTo] && count < tempPaths.Count){
				linkTo = (linkTo + 1) % tempPaths.Count;
				count++;
			}
			if (count == tempPaths.Count)
				continue;

			linkedGraph[actual, linkTo] = true;
			linkedGraph[linkTo, actual] = true;
			linkAll(linkedGraph, tempPaths.Count, actual, linkTo);

			PathDistance points = findClosest(tempPath, tempPaths[linkTo]);
			grid.drawPath(points.path_1, points.path_2, rand);

			actual++;
		}

	}

	private PathDistance findClosest(List<Coordinates> a, List<Coordinates> b){
		PathDistance result = new PathDistance(10000);

		foreach (Coordinates p1 in a) {
			foreach (Coordinates p2 in b) {

				int distance = Math.Abs (p1.x - p2.x) + Math.Abs (p1.y - p2.y);
				if (distance < result.distance) {
					result.distance = distance;
					result.path_1 = p1;
					result.path_2 = p2;
				}
			}
		}

		return result;
	}

	private bool[,] linkAll(bool[,] linkedGraph, int size, int a, int b){

		for(int i = 0; i < size; i++){
			if(linkedGraph[a, i]){
				linkedGraph[b, i] = true;
				linkedGraph[i, b] = true;
			}
			if(linkedGraph[b, i]){
				linkedGraph[a, i] = true;
				linkedGraph[i, a] = true;
			}
		}

		return linkedGraph;
	}

	private class PathDistance{

		public Coordinates path_1;
		public Coordinates path_2;
		public int distance;

		public PathDistance(int distance){
			this.path_1 = null;
			this.path_2 = null;
			this.distance = distance;
		}

		public PathDistance(Coordinates p1, Coordinates p2, int distance){
			this.path_1 = p1;
			this.path_2= p2;
			this.distance = distance;
		}

		public void setAs(Coordinates p1, Coordinates p2, int distance){
			this.path_1 = p1;
			this.path_2 = p2;
			this.distance = distance;
		}
	}
}