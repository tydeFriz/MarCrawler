using System;

public class ClosestPathLinker : PathLinkingStrategy{

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
		
	}
}