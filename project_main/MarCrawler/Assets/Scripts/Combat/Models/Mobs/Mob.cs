using System.Collections.Generic;

public abstract class Mob : Combatant{

	protected int maxHp;
	protected int maxMp;

	//combat
	public List<Effect> effects;
	public Status status;
	public List<Buff> buffs;
	public List<Debuff> debuffs;

	//stats
	protected int slashResistance;
	protected int bashResistance;
	protected int pierceResistance;
	protected int fireResistance;
	protected int iceResistance;
	protected int thunderResistance;
	protected int speed;
	protected int avoidance;
	protected int luck;
	protected int critChance;

	AIStrategy ai;

	/*LATER_PATCH: model, texture, animations...*/

	public override int getStat(StatEnum stat){
		//LATER_PATCH: appy upgrades, status, effects, buffs, debuffs
		switch (stat) {
		case StatEnum.HP:
			return maxHp;
		case StatEnum.MP:
			return maxMp;
		case StatEnum.SLASH_RES:
			return slashResistance;
		case StatEnum.BASH_RES:
			return bashResistance;
		case StatEnum.PIERCE_RES:
			return pierceResistance;
		case StatEnum.FIRE_RES:
			return fireResistance;
		case StatEnum.ICE_RES:
			return iceResistance;
		case StatEnum.THUNDER_RES:
			return thunderResistance;
		case StatEnum.SPEED:
			return speed;
		case StatEnum.CRIT:
			return critChance;
		case StatEnum.AVOIDANCE:
			return avoidance;
		case StatEnum.LUCK:
			return luck;
		default:
			throw new InvalidStatException ("cannot use stat as int: " + stat);
		}
	}

	//TODO: set of possible actions

	//TODO: getNextAction

}