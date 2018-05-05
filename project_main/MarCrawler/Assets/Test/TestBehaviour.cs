using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestBehaviour : MonoBehaviour {

	// Use this for initialization
	void Start () {

		List<Dungeon> dungeons = new List<Dungeon>();

		DungeonGenerationController controller = new DungeonGenerationController();
		dungeons.Add(controller.generateDungeon(42));
		dungeons.Add(controller.generateDungeon(1));
		dungeons.Add(controller.generateDungeon(47659));
		dungeons.Add(controller.generateDungeon(-2315));
		dungeons.Add(controller.generateDungeon(-63525));
		DEBUG_TEST_ONY_printDungeon(dungeons);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	private void DEBUG_TEST_ONY_printDungeon(List<Dungeon> dungeons){

		string seeds = "";
		foreach (Dungeon d in dungeons) {
			seeds += ""+d.seed+", ";
		}
		TestLogger.log("seeds: "+seeds);

		int size = dungeons[0].grid.sizeX;

		for(int x = 0; x < size; x++){

			string line = "";

			foreach (Dungeon d in dungeons) {
				for(int y = 0; y < size; y++){
					char temp = d.grid.grid [x, y];
					if(temp == 'w') temp = '█';
					if(temp == '_') temp = '.';
					if(temp == 'D') temp = '▒';
					if(temp == 'S') temp = '▓';
					if(temp == 'T') temp = '§';

					line += temp;
				}

				line += "     ";
			}

			TestLogger.log(line);
		}
	}
}
