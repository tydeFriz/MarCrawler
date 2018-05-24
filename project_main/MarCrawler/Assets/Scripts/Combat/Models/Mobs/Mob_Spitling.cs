using System;
using System.Collections.Generic;

public class Mob_Spitling : Mob{

	public Mob_Spitling(Random rand){

		name = "Spitling";

		maxHp = 5 + (rand.Next() % 2);		//5 -> 7
		hp = maxHp;
		maxMp = 0;							//0
		mp = maxMp;
		slashResistance = 1;
		bashResistance = 1;
		pierceResistance = 1;
		fireResistance = 6;
		iceResistance = -2;
		thunderResistance = -2;
		speed = 5 + (rand.Next() % 4);		//5 -> 8
		avoidance = 5 + (rand.Next() % 6);	//5 -> 10
		luck = 5;
		critChance = 12 + (rand.Next() % 5);	//12 -> 16

		loot = generateLoot(rand);
	}

	private Treasure generateLoot(Random rand){

		List<Item> items = new List<Item>();

		//LATER_PATCH: add items from lootTable

		return new Treasure(null, items, 4+(rand.Next() % 2));	
	}

}