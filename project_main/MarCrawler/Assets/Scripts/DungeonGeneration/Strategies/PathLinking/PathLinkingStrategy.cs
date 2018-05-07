using System;
using System.Collections.Generic;

public abstract class PathLinkingStrategy {

	public abstract void linkPaths (DungeonLayout layout, Random rand);

	//////////////////////////////////////////////////////////////////////////////////
	/*										|										*/
	/* 									 PRIVATES									*/
	/*										|										*/
	//////////////////////////////////////////////////////////////////////////////////

	protected void shufflePaths(DungeonGrid grid, PathableArea area, Random rand){

		double rateo = ((double)grid.countArea(area) / (double)grid.countPerimeter(area));
		rateo = 5000*(rateo);
		if (rateo > 9000)
			rateo = 9000;
		if (rateo < 1000)
			rateo = 1000;

		for(int x = area.position.x; x < area.sizeX + area.position.x; x++){
			for(int y = area.position.y; y < area.sizeY + area.position.y; y++){
				Coordinates position = new Coordinates(x, y);
				if(grid.hasDoorsTouching(position) || grid.hasForcedPathTouching(position)) grid.grid[position.x, position.y] = Constants.PATH_MARKER;
				else{
					int rnd = (rand.Next() % 10000) + 1;
					grid.grid[position.x, position.y] = rnd > rateo ? Constants.PATH_MARKER : Constants.PATHABLE_MARKER;
				}
			}
		}
	}

	protected PathDistance findClosestPoints(List<Coordinates> a, List<Coordinates> b){
		PathDistance result = new PathDistance(Constants.TOO_MUCH_FOR_DUNGEON_GENERATION);

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

	protected bool[,] linkAll(bool[,] linkedGraph, int size, int a, int b){

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

	protected class PathDistance{

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
