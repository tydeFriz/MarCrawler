using System.Collections.Generic;
using System;

public class CharactersGenerationController {
	/*
	public List<Character> generateInitialCharacterSet(Random rand){
		
	}
*/
	public Character generateCharacter(Random rand){

		Character character;
		character = CharacterDispatcher.getClassById((rand.Next() % Constants.TOTAL_CLASSES_NUMBER)+1);

		character.race = CharacterDispatcher.getRaceById ((rand.Next() % Constants.TOTAL_RACES_NUMBER)+1);
		character.level = 1;
		character.exp = 0;
		character.name = RandomNameGenerator.generateName(rand);

		return character;
	}

}
