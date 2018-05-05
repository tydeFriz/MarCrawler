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
			//LATER_PATCH: make linkTo the closer path, not random
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

			PathDistance points = findClosest (tempPath, tempPaths [linkTo]);
			grid.drawPath (points.path_1, points.path_2, rand);

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

}

