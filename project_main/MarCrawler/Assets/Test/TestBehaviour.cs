using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestBehaviour : MonoBehaviour {

	// Use this for initialization
	void Start () {

		DungeonGenerationController controller = new DungeonGenerationController();
		Dungeon dungeon1 = controller.generateDungeon(-635753);
		Dungeon dungeon2 = controller.generateDungeon(6413637);
		Dungeon dungeon3 = controller.generateDungeon(75474);
		dungeon1.DEBUG_TEST_ONY_printDungeon();
		dungeon2.DEBUG_TEST_ONY_printDungeon();
		dungeon3.DEBUG_TEST_ONY_printDungeon();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
