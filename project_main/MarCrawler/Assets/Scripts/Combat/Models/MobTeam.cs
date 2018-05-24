
public class MobTeam{

	public Mob[] frontRow;
	public Mob[] backRow;

	public MobTeam(){
		this.frontRow = new Mob[Constants.MAX_FRONT_MOBS];
		this.backRow = new Mob[Constants.MAX_BACK_MOBS];
	}

}