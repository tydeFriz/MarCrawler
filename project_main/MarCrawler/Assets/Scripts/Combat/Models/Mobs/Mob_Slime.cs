using System;

public class Mob_Slime : Mob{

	public Mob_Slime(Random rand){

		name = "slime";

		maxHp = 8 + (rand.Next() % 3);		//8 -> 10
		hp = maxHp;
		maxMp = 0;							//0
		mp = maxMp;
		slashResistance = 3;
		bashResistance = 1;
		pierceResistance = 4;
		fireResistance = 0;
		iceResistance = 0;
		thunderResistance = 0;
		speed = 2 + (rand.Next() % 3);		//2 -> 4
		avoidance = 9 + (rand.Next() % 7);	//9 -> 15
		luck = 0;
		critChance = 9 + (rand.Next() % 7);	//9 -> 15

	}

}