using System.Collections.Generic;

public abstract class Character {

	public string name;
	public int level;
	public int exp;
	public Race race;
	public Equip equip;
	public List<Upgrade> upgrades;
	//TODO: stats

	//combat
	public Status status;
	public List<Effect> effects;
	public List<Buff> buffs;
	public List<Debuff> debuffs;

}