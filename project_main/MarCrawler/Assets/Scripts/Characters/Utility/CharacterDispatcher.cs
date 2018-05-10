
public static class CharacterDispatcher{

	public static Character getClassById(int id){

		switch (id) {
		case 1:
			return new Warrior();
		default:
			throw new CharacterClassNotAvailableException ();
		}
	}

	public static Race getRaceById(int id){

		switch (id) {
		case 1:
			return new Hooman();
		default:
			throw new CharacterRaceNotAvailableException ();
		}
	}

}