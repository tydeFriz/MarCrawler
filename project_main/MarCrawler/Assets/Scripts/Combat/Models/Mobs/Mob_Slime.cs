using System;
using System.Collections.Generic;

public class Mob_Slime : Mob{

	public Mob_Slime(Random rand){

		name = "Slime";

		maxHp = 8 + (rand.Next() % 3);		//8 -> 10
		hp = maxHp;
		maxMp = 0;							//0
		mp = maxMp;
		slashResistance = 3;
		bashResistance = 1;
		pierceResistance = 4;
		fireResistance = -1;
		iceResistance = -1;
		thunderResistance = -1;
		speed = 2 + (rand.Next() % 3);		//2 -> 4
		avoidance = 9 + (rand.Next() % 7);	//9 -> 15
		luck = 0;
		critChance = 9 + (rand.Next() % 7);	//9 -> 15

		loot = generateLoot(rand);

		possibleActions = getActionSet();

		//TODO: declare ai
		// ai = new SlimeAIStrategy();
	}

	//////////////////////////////////////////////////////////////////////////////////
	/*										|										*/
	/* 									 PRIVATES									*/
	/*										|										*/
	//////////////////////////////////////////////////////////////////////////////////

	private Treasure generateLoot(Random rand){

		List<Item> items = new List<Item>();

		//LATER_PATCH: add items from lootTable

		return new Treasure(null, items, 3+(rand.Next() % 3));	
	}

	private ActionSet getActionSet(){
		ActionSet result = new ActionSet();

		result.add(new PhysicalAttackAction(new Die[2]{
			new Die(6, new int[6]{0, 0, 1, 1, 1, 1}),
			new Die(6, new int[6]{0, 0, 0, 1, 2, 3}),
		}, PhysicalAttackTypesEnum.BASH));

		return result;
	}

}