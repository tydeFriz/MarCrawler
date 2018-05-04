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
		List<List<Coordinates>> pathableAreas = layout.grid.findAreas(Constants.PATHABLE_MARKER);
		foreach (List<Coordinates> area in pathableAreas) {
			double rateo = (layout.grid.countArea(area) / layout.grid.countPerimeter(area))*100;
			rateo = 5000 + 50*rateo;
			shufflePaths(layout.grid, area, rateo, rand);
			List<List<Coordinates>> tempPaths = layout.grid.findAreas(Constants.PATH_MARKER);

			int count = 0;
			while(tempPaths.Count > 1 && count < 5000){
				mergePath(layout.grid, tempPaths, rand);
				tempPaths = layout.grid.findAreas(Constants.PATH_MARKER);
				count++;
			}

		}

		//inserisci tesori
		foreach(DungeonRoom room in rooms){
			foreach(Treasure treasure in room.treasures){
				treasures.Add(TreasureInitializer.initializeTreasure(treasure, rand.Next()));
			}
		}
		//TODO: add treasures to paths

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
			if(grid.hasDoorsTouching(position)) grid.grid[position.x, position.y] = Constants.PATH_MARKER;
			else{
				int rnd = (rand.Next() % 10000) + 1;
				grid.grid[position.x, position.y] = rnd > rateo ? Constants.PATH_MARKER : Constants.WALL_MARKER;
			}

		}
	}

	private void mergePath(DungeonGrid grid, List<List<Coordinates>> fragments, Random rand){

		PathDistance pd = new PathDistance(100000);

		foreach (List<Coordinates> fragment_1 in fragments) {
			foreach (List<Coordinates> fragment_2 in fragments) {
				if (fragment_1[0].Equals (fragment_2[0])) {
					continue;
				}
					
				foreach (Coordinates point_1 in fragment_1) {
					foreach (Coordinates point_2 in fragment_2) {
						int tempDistance = Math.Abs(point_1.x - point_2.x) + Math.Abs(point_1.y - point_2.y);
						if (tempDistance < pd.distance || (tempDistance == pd.distance && rand.Next() % 2 == 0)) {
							pd.setAs (point_1, point_2, tempDistance);
						}
					}
				}
			}
		}

		grid.drawPath(pd.path_1, pd.path_2, rand);
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