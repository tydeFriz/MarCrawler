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
	}

	private Treasure generateLoot(Random rand){

		List<Item> items = new List<Item>();

		//LATER_PATCH: add items from lootTable

		return new Treasure(null, items, 3+(rand.Next() % 3));	
	}

}