using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestBehaviour : MonoBehaviour {

	// Use this for initialization
	void Start () {

		DungeonGenerationController controller = new DungeonGenerationController();
		Dungeon dungeon = controller.generateDungeon(2);
		dungeon.DEBUG_TEST_ONY_printDungeon();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
