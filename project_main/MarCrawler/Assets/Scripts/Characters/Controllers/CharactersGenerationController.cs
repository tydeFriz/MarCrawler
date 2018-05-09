using System.Collections.Generic;
using System;

public class CharactersGenerationController {
	
	public List<Character> generateInitialCharacterSet(Random rand){

		List<Character> characters = new List<Character>();
		for(int i = 0; i < Constants.STARTING_POOL_SIZE; i++){
			characters.Add(generateCharacter(rand, 1, 1));
		}

		return characters;
	}

	public Character generateCharacter(Random rand, int minLvl, int maxLvl){

		Character character;
		character = CharacterDispatcher.getClassById((rand.Next() % Constants.TOTAL_CLASSES_NUMBER)+1);

		character.race = CharacterDispatcher.getRaceById ((rand.Next() % Constants.TOTAL_RACES_NUMBER)+1);
		character.level = (rand.Next() % (maxLvl - minLvl) + 1) + minLvl;
		character.exp = 0;
		character.name = RandomNameGenerator.generateName(rand);

		return character;
	}

}
