
public static class StatsCalculator{

	public static Stat getStat(StatEnum stat, char rank){

		switch (stat) {
		case StatEnum.HP:
		case StatEnum.MP:
			return getResourceStat(rank); 
		case StatEnum.ATTACK:
		case StatEnum.MAGIC:
		case StatEnum.SUPPORT:
			return getDiceStat(rank);
		case StatEnum.SLASH_RES:
		case StatEnum.BASH_RES:
		case StatEnum.PIERCE_RES:
		case StatEnum.FIRE_RES:
		case StatEnum.ICE_RES:
		case StatEnum.THUNDER_RES:
			return getResistStat(rank); 
		case StatEnum.SPEED:
			return getSpeedStat(rank);
		case StatEnum.CRIT:
		case StatEnum.AVOIDANCE:
		case StatEnum.LUCK:
			return getChanceStat(rank);
		default:
			throw new InvalidStatException();
		}

	}
		
	//////////////////////////////////////////////////////////////////////////////////
	/*										|										*/
	/* 									 PRIVATES									*/
	/*										|										*/
	//////////////////////////////////////////////////////////////////////////////////

	private static IntStat getResourceStat(char rank){
		switch(rank){
		case Constants.S_RANK:
			return new IntStat (16, 6.556, rank);
		case Constants.A_RANK:
			return new IntStat (14, 6.222, rank);
		case Constants.B_RANK: 
			return new IntStat (12, 5.889, rank);
		case Constants.C_RANK:
			return new IntStat (10, 5.556, rank);
		case Constants.D_RANK:
			return new IntStat (9, 5.111, rank);
		case Constants.E_RANK:
			return new IntStat (7, 4.778, rank);
		case Constants.F_RANK:
			return new IntStat (5, 4.444, rank);
		default:
			throw new InvalidStatRankException("invalid rank: "+rank);	
		}
	}

	private static IntStat getResistStat(char rank){
		switch(rank){
		case Constants.S_RANK:
			return new IntStat (6, 1, rank);
		case Constants.A_RANK:
			return new IntStat (5, 0.889, rank);
		case Constants.B_RANK: 
			return new IntStat (4, 0.778, rank);
		case Constants.C_RANK:
			return new IntStat (3, 0.667, rank);
		case Constants.D_RANK:
			return new IntStat (2, 0.556, rank);
		case Constants.E_RANK:
			return new IntStat (1, 0.444, rank);
		case Constants.F_RANK:
			return new IntStat (0, 0.333, rank);
		default:
			throw new InvalidStatRankException("invalid rank: "+rank);	
		}
	}

	private static IntStat getSpeedStat(char rank){
		switch(rank){
		case Constants.S_RANK:
			return new IntStat (7, 1, rank);
		case Constants.A_RANK:
			return new IntStat (6, 1, rank);
		case Constants.B_RANK: 
			return new IntStat (5, 0.667, rank);
		case Constants.C_RANK:
			return new IntStat (4, 0.667, rank);
		case Constants.D_RANK:
			return new IntStat (3, 0.5, rank);
		case Constants.E_RANK:
			return new IntStat (2, 0.5, rank);
		case Constants.F_RANK:
			return new IntStat (1, 0.333, rank);
		default:
			throw new InvalidStatRankException("invalid rank: "+rank);	
		}
	}

	private static IntStat getChanceStat(char rank){
		switch(rank){
		case Constants.S_RANK:
			return new IntStat (25, 2.778, rank);
		case Constants.A_RANK:
			return new IntStat (21, 2.444, rank);
		case Constants.B_RANK: 
			return new IntStat (17, 2.222, rank);
		case Constants.C_RANK:
			return new IntStat (13, 1.889, rank);
		case Constants.D_RANK:
			return new IntStat (9, 1.556, rank);
		case Constants.E_RANK:
			return new IntStat (5, 1.333, rank);
		case Constants.F_RANK:
			return new IntStat (1, 1, rank);
		default:
			throw new InvalidStatRankException("invalid rank: "+rank);	
		}
	}

	private static DiceStat getDiceStat(char rank){
		
		Die[] definition = new Die[Constants.MAX_LEVEL];
	
		switch(rank){
		case Constants.S_RANK:
			definition[0] = new Die(6, new int[6]{2, 3, 4, 4, 5, 6});
			definition[1] = new Die(6, new int[6]{2, 3, 4, 5, 6, 6});
			definition[2] = new Die(6, new int[6]{3, 3, 4, 5, 6, 7});
			definition[3] = new Die(6, new int[6]{3, 4, 5, 5, 6, 7});
			definition[4] = new Die(6, new int[6]{3, 4, 5, 6, 7, 7});
			definition[5] = new Die(6, new int[6]{4, 4, 5, 6, 7, 8});
			definition[6] = new Die(6, new int[6]{4, 5, 6, 6, 7, 8});
			definition[7] = new Die(6, new int[6]{4, 5, 6, 7, 8, 8});
			definition[8] = new Die(6, new int[6]{5, 5, 6, 7, 8, 9});
			definition[9] = new Die(6, new int[6]{5, 6, 7, 7, 8, 9});
			break;
		case Constants.A_RANK:
			definition[0] = new Die(6, new int[6]{2, 2, 3, 4, 4, 5});
			definition[1] = new Die(6, new int[6]{2, 3, 3, 4, 5, 5});
			definition[2] = new Die(6, new int[6]{2, 3, 4, 4, 5, 6});
			definition[3] = new Die(6, new int[6]{3, 3, 4, 5, 5, 6});
			definition[4] = new Die(6, new int[6]{3, 4, 4, 5, 6, 6});
			definition[5] = new Die(6, new int[6]{3, 4, 5, 5, 6, 7});
			definition[6] = new Die(6, new int[6]{4, 4, 5, 6, 6, 7});
			definition[7] = new Die(6, new int[6]{4, 5 ,5, 6, 7, 7});
			definition[8] = new Die(6, new int[6]{4, 5, 6, 6, 7, 8});
			definition[9] = new Die(6, new int[6]{5, 5, 6, 7, 7, 8});
			break;
		case Constants.B_RANK: 
			definition[0] = new Die(6, new int[6]{1, 2, 3, 3, 4, 4});
			definition[1] = new Die(6, new int[6]{1, 2, 3, 4, 4, 5});
			definition[2] = new Die(6, new int[6]{2, 3, 3, 4, 4, 5});
			definition[3] = new Die(6, new int[6]{2, 3, 4, 4, 5, 5});
			definition[4] = new Die(6, new int[6]{2, 3, 4, 5, 5, 6});
			definition[5] = new Die(6, new int[6]{3, 4, 4, 5, 5, 6});
			definition[6] = new Die(6, new int[6]{3, 4, 4, 5, 6, 6});
			definition[7] = new Die(6, new int[6]{3, 4, 5, 5, 6, 7});
			definition[8] = new Die(6, new int[6]{4, 4, 5, 6, 6, 7});
			definition[9] = new Die(6, new int[6]{4, 5, 5, 6, 7, 7});
			break;
		case Constants.C_RANK:
			definition[0] = new Die(6, new int[6]{1, 1, 2, 3, 3, 4});
			definition[1] = new Die(6, new int[6]{1, 2, 2, 3, 3, 4});
			definition[2] = new Die(6, new int[6]{1, 2, 3, 3, 4, 4});
			definition[3] = new Die(6, new int[6]{1, 2, 3, 4, 4, 5});
			definition[4] = new Die(6, new int[6]{2, 3, 3, 4, 4, 5});
			definition[5] = new Die(6, new int[6]{2, 3, 4, 4, 5, 5});
			definition[6] = new Die(6, new int[6]{2, 3, 4, 5, 5, 6});
			definition[7] = new Die(6, new int[6]{3, 4, 4, 5, 5, 6});
			definition[8] = new Die(6, new int[6]{3, 4, 5, 5, 6, 6});
			definition[9] = new Die(6, new int[6]{4, 4, 5, 5, 6, 7});
			break;
		case Constants.D_RANK:
			definition[0] = new Die(6, new int[6]{0, 1, 1, 2, 3, 3});
			definition[1] = new Die(6, new int[6]{1, 1, 2, 2, 3, 3});
			definition[2] = new Die(6, new int[6]{1, 1, 2, 3, 3, 4});
			definition[3] = new Die(6, new int[6]{1, 2, 2, 3, 4, 4});
			definition[4] = new Die(6, new int[6]{1, 2, 3, 3, 4, 4});
			definition[5] = new Die(6, new int[6]{1, 2, 3, 4, 4, 5});
			definition[6] = new Die(6, new int[6]{2, 3, 3, 4, 4, 5});
			definition[7] = new Die(6, new int[6]{2, 3, 4, 4, 5, 5});
			definition[8] = new Die(6, new int[6]{3, 4, 4, 5, 5, 6});
			definition[9] = new Die(6, new int[6]{3, 4, 4, 5, 6, 6});
			break;
		case Constants.E_RANK:
			definition[0] = new Die(6, new int[6]{0, 0, 1, 1, 2, 2});
			definition[1] = new Die(6, new int[6]{0, 0, 1, 1, 2, 3});
			definition[2] = new Die(6, new int[6]{0, 1, 1, 2, 3, 3});
			definition[3] = new Die(6, new int[6]{1, 1, 2, 2, 3, 3});
			definition[4] = new Die(6, new int[6]{1, 1, 2, 3, 3, 4});
			definition[5] = new Die(6, new int[6]{1, 2, 2, 3, 4, 4});
			definition[6] = new Die(6, new int[6]{1, 2, 3, 3, 4, 4});
			definition[7] = new Die(6, new int[6]{1, 2, 3, 4, 4, 5});
			definition[8] = new Die(6, new int[6]{2, 3, 3, 4, 4, 5});
			definition[9] = new Die(6, new int[6]{2, 3, 4, 4, 5, 5});
			break;
		case Constants.F_RANK:
			definition[0] = new Die(6, new int[6]{0, 0, 0, 1, 1, 1});
			definition[1] = new Die(6, new int[6]{0, 0, 1, 1, 1, 2});
			definition[2] = new Die(6, new int[6]{0, 1, 1, 1, 2, 2});
			definition[3] = new Die(6, new int[6]{0, 1, 1, 1, 2, 3});
			definition[4] = new Die(6, new int[6]{1, 1, 1, 2, 2, 3});
			definition[5] = new Die(6, new int[6]{1, 1, 2, 2, 3, 3});
			definition[6] = new Die(6, new int[6]{1, 1, 2, 3, 3, 4});
			definition[7] = new Die(6, new int[6]{1, 2, 2, 3, 4, 4});
			definition[8] = new Die(6, new int[6]{1, 2, 3, 3, 4, 4});
			definition[9] = new Die(6, new int[6]{1, 2, 3, 4, 4, 5});
			break;
		default:
			throw new InvalidStatRankException("invalid rank: "+rank);	
		}

		return new DiceStat (definition, rank);
	}
}