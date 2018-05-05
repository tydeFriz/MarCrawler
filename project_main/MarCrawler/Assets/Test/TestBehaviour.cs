using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestBehaviour : MonoBehaviour {

	// Use this for initialization
	void Start () {

		DungeonGenerationController controller = new DungeonGenerationController();
		Dungeon dungeon1 = controller.generateDungeon(-66346);
		Dungeon dungeon2 = controller.generateDungeon(1174);
		Dungeon dungeon3 = controller.generateDungeon(42);
		dungeon1.DEBUG_TEST_ONY_printDungeon();
		dungeon2.DEBUG_TEST_ONY_printDungeon();
		dungeon3.DEBUG_TEST_ONY_printDungeon();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
