using System.Collections.Generic;

public abstract class Character : Combatant{

	public string code;
	public int level;
	public int exp;
	public Race race;
	public Equip equip;
	public List<Upgrade> upgrades;

	//stats
	protected IntStat maxHp;
	protected IntStat maxMp;
	protected DiceStat attackPower;
	protected DiceStat magicPower;
	protected DiceStat supportPower;
	protected IntStat slashResistance;
	protected IntStat bashResistance;
	protected IntStat pierceResistance;
	protected IntStat fireResistance;
	protected IntStat iceResistance;
	protected IntStat thunderResistance;
	protected IntStat speed;
	protected IntStat avoidance;
	protected IntStat luck;
	protected IntStat critChance;

	//combat
	public List<Effect> effects;
	public Status status;
	public List<Buff> buffs;
	public List<Debuff> debuffs;

	public Character(){
		this.code = CodeGenerator.getCode();
		this.effects = new List<Effect>();
		this.status = null;
		this.buffs = new List<Buff>();
		this.debuffs = new List<Debuff>();
	}

	public string getIdentifier(){
		return name + "_" + code;
	}

	public int getStat(StatEnum stat){
		//LATER_PATCH: appy upgrades, status, effects, buffs, debuffs
		switch(stat){
		case StatEnum.HP:
			return maxHp.getByLevel(level);
		case StatEnum.MP:
			return maxMp.getByLevel(level);
		case StatEnum.SLASH_RES:
			return slashResistance.getByLevel(level);
		case StatEnum.BASH_RES:
			return bashResistance.getByLevel(level);
		case StatEnum.PIERCE_RES:
			return pierceResistance.getByLevel(level);
		case StatEnum.FIRE_RES:
			return fireResistance.getByLevel(level);
		case StatEnum.ICE_RES:
			return iceResistance.getByLevel(level);
		case StatEnum.THUNDER_RES:
			return thunderResistance.getByLevel(level);
		case StatEnum.SPEED:
			return speed.getByLevel(level);
		case StatEnum.CRIT:
			return critChance.getByLevel(level);
		case StatEnum.AVOIDANCE:
			return avoidance.getByLevel(level);
		case StatEnum.LUCK:
			return luck.getByLevel(level);
		default:
			throw new InvalidStatException("cannot use stat as int: "+stat);
		}

	}

	public Die getDie(StatEnum stat){
		//LATER_PATCH: appy upgrades, status, effects, buffs, debuffs
		switch(stat){
		case StatEnum.ATTACK:
			return attackPower.getByLevel(level);
		case StatEnum.MAGIC:
			return magicPower.getByLevel(level);
		case StatEnum.SUPORT:
			return supportPower.getByLevel(level);
		default:
			throw new InvalidStatException("cannot use stat as Die: "+stat);
		}

	}

}