using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class TestBehaviour : MonoBehaviour {

	// Use this for initialization
	void Start () {

		if (Constants.TEST_NAME_GENERATION) {
			NameGeneratorTester.testGeneration ();
		}

		if (Constants.VALIDATE_LAYOUTS) {
			try{
				LayoutValidator.runValidation ();
			}catch(Exception e){
				TestLogger.log ("WrongLayoutDeclarationException: "+e.Message);
			}
		}

		if (Constants.VALIDATE_ROOMS){
			try{
				RoomValidator.runValidation ();
			}catch(WrongRoomDeclarationException e){
				TestLogger.log ("WrongRoomDeclarationException: "+e.Message);
			}
		}
			
		if (Constants.TEST_DUNGEON_GENERATION)
			DungeonGenerationTester.testGeneration ();
		
		//if (Constants.VALIDATE_CHARACTERS)
		//	/*character validation function call here*/;

		//if (Constants.TEST_CHARACTERS_GENERATION)
		//	/*character generation test function call here*/;
	}
	 

	void Update () {}

}
