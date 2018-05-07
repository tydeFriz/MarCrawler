using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class TestBehaviour : MonoBehaviour {

	// Use this for initialization
	void Start () {

		List<Dungeon> dungeons = new List<Dungeon>();
		System.Random rand = new System.Random();
		rand.Next ();

		DungeonGenerationController controller = new DungeonGenerationController();

		for(int i = 0; i < 4; i++){
			int seed = rand.Next();
			dungeons.Add(controller.generateDungeon(seed));
		}
		DEBUG_TEST_ONY_printDungeon(dungeons);

	}
	
	// Update is called once per frame
	void Update () {
		
	}

	private void DEBUG_TEST_ONY_printDungeon(List<Dungeon> dungeons){

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
