using System;
using System.Collections.Generic;

public class RandomPathLinker : PathLinkingStrategy{
	
	public override void linkPaths(DungeonLayout layout,Random rand){

		foreach (PathableArea area in layout.pathableAreas){
			shufflePaths(layout.grid, area, rand);
			mergePaths(layout.grid, area, rand);
		}

	}

	//////////////////////////////////////////////////////////////////////////////////
	/*										|										*/
	/* 									 PRIVATES									*/
	/*										|										*/
	//////////////////////////////////////////////////////////////////////////////////

	private void mergePaths(DungeonGrid grid, PathableArea area, Random rand){

		List<List<Coordinates>> tempPaths = grid.findAreas (Constants.PATH_MARKER, area.position, new Coordinates (area.position.x + area.sizeX, area.position.y + area.sizeY));
		if (tempPaths.Count == 1)
			return;

		bool[,] linkedGraph = new bool[tempPaths.Count, tempPaths.Count];

		for (int i = 0; i < tempPaths.Count; i++) {
			for (int j = 0; j < tempPaths.Count; j++) {
				linkedGraph [i, j] = (i == j ? true : false);
			}
		}

		int actual = 0;
		foreach (List<Coordinates> tempPath in tempPaths) {
			int linkTo = rand.Next () % tempPaths.Count; 
			int count = 0;
			while (linkedGraph [actual, linkTo] && count < tempPaths.Count) {
				linkTo = (linkTo + 1) % tempPaths.Count;
				count++;
			}
			if (count == tempPaths.Count)
				continue;

			linkedGraph [actual, linkTo] = true;
			linkedGraph [linkTo, actual] = true;
			linkAll (linkedGraph, tempPaths.Count, actual, linkTo);

			PathDistance points = findClosestPoints (tempPath, tempPaths [linkTo]);
			grid.drawPath (points.path_1, points.path_2, rand);

			actual++;
		}

	}

}

