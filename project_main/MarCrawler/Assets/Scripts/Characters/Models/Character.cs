using System.Collections.Generic;

public abstract class Character {

	public string name;
	public int level;
	public int exp;
	public Race race;
	public Equip equip;
	public List<Upgrade> upgrades;

	//stats
	public int maxHp;
	public int hp;
	public int maxMp;
	public int mp;
	public int attackPower;
	public int magicPower;
	public int slashResistance;
	public int bashResistance;
	public int pierceResistance;
	public int fireResistance;
	public int iceResistance;
	public int thunderResistance;
	public int speed;
	public int avoidance;
	public int critChance;

	//combat
	public Status status;
	public List<Effect> effects;
	public List<Buff> buffs;
	public List<Debuff> debuffs;

}