
public static class CharacterDispatcher{

	public static Character getClassById(int id){

		switch (id) {
		case (int)Constants.ARCHER_CLASS:
			return new Archer();
		case (int)Constants.GUARDIAN_CLASS:
			return new Guardian();
		case (int)Constants.MAGE_CLASS:
			return new Mage();
		case (int)Constants.SHAMAN_CLASS:
			return new Shaman();
		case (int)Constants.WARRIOR_CLASS:
			return new Warrior();
		default:
			throw new CharacterClassNotAvailableException ();
		}
	}

	public static Race getRaceById(int id){

		switch (id) {
		case (int)Constants.HOOMAN_RACE:
			return new Hooman();
		default:
			throw new CharacterRaceNotAvailableException ();
		}
	}

}