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
				if(grid.hasDoorsTouching(position)) grid.grid[position.x, position.y] = Constants.PATH_MARKER;
				else{
					int rnd = (rand.Next() % 10000) + 1;
					grid.grid[position.x, position.y] = rnd > rateo ? Constants.PATH_MARKER : Constants.PATHABLE_MARKER;
				}
			}
		}
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
