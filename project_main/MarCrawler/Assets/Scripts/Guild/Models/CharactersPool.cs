using System.Collections.Generic;

public class CharactersPool{

	int maxSize;
	public Dictionary<string, Character> aliveCharacters;
	public List<Character> deadCharacters;

	public bool addCharacter(Character c){
		if (aliveCharacters.Count == maxSize)
			return false;
		maxSize++;
		aliveCharacters.Add (c.getIdentifier(), c);
		return true;
	}

	public void died(Character c){
		aliveCharacters.Remove (c.getIdentifier ());
		deadCharacters.Add (c);
	}
}

