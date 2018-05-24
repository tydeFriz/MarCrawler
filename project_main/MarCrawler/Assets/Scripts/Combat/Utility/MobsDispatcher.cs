using System;

public static class MobsDispatcher{

	static public Mob getFrontMobById(int id){
		return getMob(id*10 + 1);
	}
		
	static public Mob getBackMobById(int id){
		return getMob(id*10 + 2);
	}

	//////////////////////////////////////////////////////////////////////////////////
	/*										|										*/
	/* 									 PRIVATES									*/
	/*										|										*/
	//////////////////////////////////////////////////////////////////////////////////

	private static Mob getMob(int id){
		Random rand = new Random();
		switch(id){
		case 11:
			return new Mob_Slime(rand);
		case 12:
			return new Mob_Spitling(rand);
		default: 
			throw new InvalidMobIdException("invalid request. id: "+id);
		}
	}
}