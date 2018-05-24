using System.Collections.Generic;

public class MobTeam{

	public Mob[] frontRow;
	public Mob[] backRow;

	public MobTeam(){
		this.frontRow = new Mob[Constants.MAX_FRONT_MOBS];
		this.backRow = new Mob[Constants.MAX_BACK_MOBS];
	}

	public List<Mob> getMobs(){
		List<Mob> mobs = new List<Mob>();

		for (int i = 0; i < Constants.MAX_FRONT_MOBS; i++) {
			if (frontRow [i] != null)
				mobs.Add(frontRow[i]);
		}
		for (int i = 0; i < Constants.MAX_FRONT_MOBS; i++) {
			if (backRow [i] != null)
				mobs.Add(backRow[i]);
		}

		return mobs;
	}

}