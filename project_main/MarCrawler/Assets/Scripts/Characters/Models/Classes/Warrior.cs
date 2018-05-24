
public class Warrior : Character {

	public Warrior() : base(){
																//			STAT					RANK
		this.maxHp = (IntStat) StatsCalculator.getStat(				StatEnum.HP, 			Constants.A_RANK);
		this.maxMp = (IntStat) StatsCalculator.getStat(				StatEnum.MP, 			Constants.E_RANK);
		this.attackPower = (DiceStat) StatsCalculator.getStat(		StatEnum.ATTACK, 		Constants.A_RANK);
		this.magicPower = (DiceStat) StatsCalculator.getStat(		StatEnum.MAGIC, 		Constants.E_RANK);
		this.supportPower = (DiceStat) StatsCalculator.getStat(		StatEnum.SUPPORT, 		Constants.D_RANK);
		this.slashResistance = (IntStat) StatsCalculator.getStat(	StatEnum.SLASH_RES, 	Constants.B_RANK);
		this.bashResistance = (IntStat) StatsCalculator.getStat(	StatEnum.BASH_RES, 		Constants.B_RANK);
		this.pierceResistance = (IntStat) StatsCalculator.getStat(	StatEnum.PIERCE_RES, 	Constants.B_RANK);
		this.fireResistance = (IntStat) StatsCalculator.getStat(	StatEnum.FIRE_RES, 		Constants.D_RANK);
		this.iceResistance = (IntStat) StatsCalculator.getStat(		StatEnum.ICE_RES, 		Constants.D_RANK);
		this.thunderResistance = (IntStat) StatsCalculator.getStat(	StatEnum.THUNDER_RES, 	Constants.D_RANK);
		this.speed = (IntStat) StatsCalculator.getStat(				StatEnum.SPEED, 		Constants.C_RANK);
		this.critChance = (IntStat) StatsCalculator.getStat(		StatEnum.CRIT, 			Constants.D_RANK);
		this.avoidance = (IntStat) StatsCalculator.getStat(			StatEnum.AVOIDANCE, 	Constants.C_RANK);
		this.luck = (IntStat) StatsCalculator.getStat(				StatEnum.LUCK, 			Constants.D_RANK);

	}

	public override void addEffectsFromUpgrades(){
		//LATER_PATCH: \\REQUIRED_IMPLEMENTATIONS: upgrades
	}

}