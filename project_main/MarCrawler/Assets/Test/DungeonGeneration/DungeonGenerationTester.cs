using System.Collections.Generic;
using System;

public class DungeonGenerationTester{
		
	public static void testGeneration(){
		List<Dungeon> dungeons = new List<Dungeon>();
		Random rand = new Random();

		DungeonGenerationController controller = new DungeonGenerationController();

		for(int i = 0; i < 4; i++){
			int seed = rand.Next();
			Random tempRand = new Random(seed);
			dungeons.Add(controller.generateDungeon(tempRand, seed));
		}
		DEBUG_TEST_ONY_printDungeon(dungeons);
	}

	private static void DEBUG_TEST_ONY_printDungeon(List<Dungeon> dungeons){

		foreach (Dungeon d in dungeons) {
			TestLogger.log ("dungeon seed: "+d.seed);
			for (int x = 0; x < d.grid.sizeX; x++) {
				string line = "";
				for(int y = 0; y < d.grid.sizeY; y++){
					char temp = d.grid.grid [x, y];
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

		TestLogger.log ("");
	}

}

