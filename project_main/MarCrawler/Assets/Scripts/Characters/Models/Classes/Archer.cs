
public class Archer: Character{

	public Archer() : base(){
		//			STAT					RANK
		this.maxHp = (IntStat) StatsCalculator.getStat(				StatEnum.HP, 			Constants.D_RANK);
		this.maxMp = (IntStat) StatsCalculator.getStat(				StatEnum.MP, 			Constants.C_RANK);
		this.attackPower = (DiceStat) StatsCalculator.getStat(		StatEnum.ATTACK, 		Constants.B_RANK);
		this.magicPower = (DiceStat) StatsCalculator.getStat(		StatEnum.MAGIC, 		Constants.D_RANK);
		this.supportPower = (DiceStat) StatsCalculator.getStat(		StatEnum.SUPPORT, 		Constants.C_RANK);
		this.slashResistance = (IntStat) StatsCalculator.getStat(	StatEnum.SLASH_RES, 	Constants.D_RANK);
		this.bashResistance = (IntStat) StatsCalculator.getStat(	StatEnum.BASH_RES, 		Constants.D_RANK);
		this.pierceResistance = (IntStat) StatsCalculator.getStat(	StatEnum.PIERCE_RES, 	Constants.D_RANK);
		this.fireResistance = (IntStat) StatsCalculator.getStat(	StatEnum.FIRE_RES, 		Constants.E_RANK);
		this.iceResistance = (IntStat) StatsCalculator.getStat(		StatEnum.ICE_RES, 		Constants.E_RANK);
		this.thunderResistance = (IntStat) StatsCalculator.getStat(	StatEnum.THUNDER_RES, 	Constants.E_RANK);
		this.speed = (IntStat) StatsCalculator.getStat(				StatEnum.SPEED, 		Constants.A_RANK);
		this.critChance = (IntStat) StatsCalculator.getStat(		StatEnum.CRIT, 			Constants.C_RANK);
		this.avoidance = (IntStat) StatsCalculator.getStat(			StatEnum.AVOIDANCE, 	Constants.B_RANK);
		this.luck = (IntStat) StatsCalculator.getStat(				StatEnum.LUCK, 			Constants.B_RANK);

	}

	public override void addEffectsFromUpgrades(){
		//LATER_PATCH: \\REQUIRED_IMPLEMENTATIONS: upgrades
	}

}

