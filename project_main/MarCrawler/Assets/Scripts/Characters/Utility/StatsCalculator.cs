
public static class StatsCalculator{

	public static Stat getStat(StatEnum stat, char rank){

		switch (stat) {
		case StatEnum.HP:
		case StatEnum.MP:
			return getResourceStat(rank); 
		case StatEnum.ATTACK:
		case StatEnum.MAGIC:
		case StatEnum.SUPORT:
			return getDiceStat(rank);
		case StatEnum.SLASH_RES:
		case StatEnum.BASH_RES:
		case StatEnum.PIERCE_RES:
		case StatEnum.FIRE_RES:
		case StatEnum.ICE_RES:
		case StatEnum.THUNDER_RES:
			return getResistStat(rank); 
		/*case StatEnum.SPEED: TODO
			return getSpeedStat(rank);
		case StatEnum.AVOIDANCE: TODO
		case StatEnum.LUCK: TODO
			return getChanceStat(rank);*/
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

	private static DiceStat getDiceStat(char rank){
		
		Die[] definition = new Die[Constants.MAX_LEVEL];
	
		switch(rank){
		case Constants.S_RANK:
			definition[0] = new Die(6, new int[6]{2, 2, 3, 3, 4, 4});
			definition[1] = new Die(6, new int[6]{4, 5, 5, 5, 6, 7});
			definition[2] = new Die(6, new int[6]{5, 6, 7, 8, 8, 9});
			definition[3] = new Die(6, new int[6]{7, 8, 9, 9, 10, 11});
			definition[4] = new Die(6, new int[6]{9, 10, 11, 11, 12, 12});
			definition[5] = new Die(6, new int[6]{11, 12, 12, 13, 13, 14});
			definition[6] = new Die(6, new int[6]{12, 13, 14, 15, 16, 17});
			definition[7] = new Die(6, new int[6]{14, 15, 16, 17, 18, 18});
			definition[8] = new Die(6, new int[6]{16, 17, 18, 19, 19, 20});
			definition[9] = new Die(6, new int[6]{16, 18, 20, 20, 22, 24});
			break;
		/*case Constants.A_RANK:
			definition[0] = new Die(6, new int[6]{});
			definition[1] = new Die(6, new int[6]{});
			definition[2] = new Die(6, new int[6]{});
			definition[3] = new Die(6, new int[6]{});
			definition[4] = new Die(6, new int[6]{});
			definition[5] = new Die(6, new int[6]{});
			definition[6] = new Die(6, new int[6]{});
			definition[7] = new Die(6, new int[6]{});
			definition[8] = new Die(6, new int[6]{});
			definition[9] = new Die(6, new int[6]{});
			break;
		case Constants.B_RANK: 
			definition[0] = new Die(6, new int[6]{});
			definition[1] = new Die(6, new int[6]{});
			definition[2] = new Die(6, new int[6]{});
			definition[3] = new Die(6, new int[6]{});
			definition[4] = new Die(6, new int[6]{});
			definition[5] = new Die(6, new int[6]{});
			definition[6] = new Die(6, new int[6]{});
			definition[7] = new Die(6, new int[6]{});
			definition[8] = new Die(6, new int[6]{});
			definition[9] = new Die(6, new int[6]{});
			break;
		case Constants.C_RANK:
			definition[0] = new Die(6, new int[6]{});
			definition[1] = new Die(6, new int[6]{});
			definition[2] = new Die(6, new int[6]{});
			definition[3] = new Die(6, new int[6]{});
			definition[4] = new Die(6, new int[6]{});
			definition[5] = new Die(6, new int[6]{});
			definition[6] = new Die(6, new int[6]{});
			definition[7] = new Die(6, new int[6]{});
			definition[8] = new Die(6, new int[6]{});
			definition[9] = new Die(6, new int[6]{});
			break;
		case Constants.D_RANK:
			definition[0] = new Die(6, new int[6]{});
			definition[1] = new Die(6, new int[6]{});
			definition[2] = new Die(6, new int[6]{});
			definition[3] = new Die(6, new int[6]{});
			definition[4] = new Die(6, new int[6]{});
			definition[5] = new Die(6, new int[6]{});
			definition[6] = new Die(6, new int[6]{});
			definition[7] = new Die(6, new int[6]{});
			definition[8] = new Die(6, new int[6]{});
			definition[9] = new Die(6, new int[6]{});
			break;
		case Constants.E_RANK:
			definition[0] = new Die(6, new int[6]{});
			definition[1] = new Die(6, new int[6]{});
			definition[2] = new Die(6, new int[6]{});
			definition[3] = new Die(6, new int[6]{});
			definition[4] = new Die(6, new int[6]{});
			definition[5] = new Die(6, new int[6]{});
			definition[6] = new Die(6, new int[6]{});
			definition[7] = new Die(6, new int[6]{});
			definition[8] = new Die(6, new int[6]{});
			definition[9] = new Die(6, new int[6]{});
			break;
		case Constants.F_RANK:
			definition[0] = new Die(6, new int[6]{});
			definition[1] = new Die(6, new int[6]{});
			definition[2] = new Die(6, new int[6]{});
			definition[3] = new Die(6, new int[6]{});
			definition[4] = new Die(6, new int[6]{});
			definition[5] = new Die(6, new int[6]{});
			definition[6] = new Die(6, new int[6]{});
			definition[7] = new Die(6, new int[6]{});
			definition[8] = new Die(6, new int[6]{});
			definition[9] = new Die(6, new int[6]{});
			break;*/
		default:
			throw new InvalidStatRankException("invalid rank: "+rank);	
		}

		return new DiceStat (definition, rank);
	}
}