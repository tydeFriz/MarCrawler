using System.Collections.Generic;

public class Team{
		
	Dictionary<TeamPositionEnum, Character> characters;

	public Team (Character front_l, Character front_m, Character front_r, Character back_l, Character back_m, Character back_r){
		this.characters = new Dictionary<TeamPositionEnum, Character>();
		this.characters.Add(TeamPositionEnum.FRONT_LEFT, front_l);
		this.characters.Add(TeamPositionEnum.FRONT_MID, front_m);
		this.characters.Add(TeamPositionEnum.FRONT_RIGHT, front_r);
		this.characters.Add(TeamPositionEnum.BACK_LEFT, back_l);
		this.characters.Add(TeamPositionEnum.BACK_MID, back_m);
		this.characters.Add(TeamPositionEnum.BACK_RIGHT, back_r);
	}

	public Character getCharacterFromPosition(TeamPositionEnum position){
		return characters[position];
	}

	public void switchCharacters(TeamPositionEnum position_a, TeamPositionEnum position_b){
		if (position_a == position_b)
			return;
		Character temp = characters[position_a];
		characters[position_a] = characters[position_b];
		characters[position_b] = temp;
	}

	public List<Character> getFrontRow(){
		List<Character> result = new List<Character>();

		if (characters [TeamPositionEnum.FRONT_LEFT] != null)
			result.Add (characters [TeamPositionEnum.FRONT_LEFT]);
		if (characters [TeamPositionEnum.FRONT_MID] != null)
			result.Add (characters [TeamPositionEnum.FRONT_MID]);
		if (characters [TeamPositionEnum.FRONT_RIGHT] != null)
			result.Add (characters [TeamPositionEnum.FRONT_RIGHT]);

		return result;
	}

	public List<Character> getBackRow(){
		List<Character> result = new List<Character>();

		if (characters [TeamPositionEnum.BACK_LEFT] != null)
			result.Add (characters [TeamPositionEnum.BACK_LEFT]);
		if (characters [TeamPositionEnum.BACK_MID] != null)
			result.Add (characters [TeamPositionEnum.BACK_MID]);
		if (characters [TeamPositionEnum.BACK_RIGHT] != null)
			result.Add (characters [TeamPositionEnum.BACK_RIGHT]);

		return result;
	}

	public void clearAfterCombat(){

		foreach (KeyValuePair<TeamPositionEnum, Character> pair in characters) {
			Character c = pair.Value;
			c.buffs.Clear();
			c.debuffs.Clear();
			c.effects.Clear();
		}

	}

}