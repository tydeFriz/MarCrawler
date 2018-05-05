using System;
using System.Collections.Generic;

public class ClosestPathLinker : PathLinkingStrategy{

	public override void linkPaths(DungeonLayout layout,Random rand){

		foreach (PathableArea area in layout.pathableAreas){
			shufflePaths(layout.grid, area, rand);
			recursiveMergePaths(layout.grid, area, rand);
		}

	}

	//////////////////////////////////////////////////////////////////////////////////
	/*										|										*/
	/* 									 PRIVATES									*/
	/*										|										*/
	//////////////////////////////////////////////////////////////////////////////////

	private void recursiveMergePaths(DungeonGrid grid, PathableArea area, Random rand){

		List<List<Coordinates>> tempPaths = grid.findAreas (Constants.PATH_MARKER, area.position, new Coordinates (area.position.x + area.sizeX, area.position.y + area.sizeY));
		if (tempPaths.Count == 1)
			return;

		PathDistance closest = findClosestPaths(tempPaths, rand);
		grid.drawPath (closest.path_1, closest.path_2, rand);

		recursiveMergePaths(grid, area, rand);
	}

	private PathDistance findClosestPaths(List<List<Coordinates>> paths, Random rand){

		PathDistance result = new PathDistance(Constants.TOO_MUCH_FOR_DUNGEON_GENERATION);

		foreach (List<Coordinates> path_1 in paths) {
			foreach (List<Coordinates> path_2 in paths) {
				if (!(path_1 [0] == path_2 [0])) {
					PathDistance temp = findClosestPoints(path_1, path_2);
					if (temp.distance < result.distance)
						result = temp;
					else if (temp.distance == result.distance && (rand.Next() % 2 == 0)) {
						result = temp;
					}
				}
			}
		}

		return result;
	}

}