using System.Collections;
using System.Collections.Generic;

public abstract class DungeonLayout{
	public DungeonGrid grid;
	public List<PseudoRoom> rooms;
	public List<PathableArea> pathableAreas;

	public void DEBUG_TEST_ONLY_emergencyPrint(){

		TestLogger.log ("ATTENTION: EMERGENCY PRINTING");

		for (int x = 0; x < grid.sizeX; x++) {
			string line = "";

			for(int y = 0; y < grid.sizeY; y++){
				char temp = grid.grid [x, y];
				if(temp == 'w') temp = '█';
				if(temp == '_') temp = '.';
				if(temp == 'D') temp = '▒';
				if(temp == 'S') temp = '▓';
				if(temp == 'T') temp = '§';

				line += temp;
			}

			TestLogger.log (line);
		}

	}
}