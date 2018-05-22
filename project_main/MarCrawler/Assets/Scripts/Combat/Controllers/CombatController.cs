using System;

public class CombatController {

	Random rand;
	public Combat combat;

	/// <summary>
	/// use NULL as presetMobs if you want enemies to be generated randomly 
	/// </summary>
	public CombatController(Team team, int seed, MobTeam presetMobs/*LATER_PATCH: , int dungeonType*/){
		this.rand = new Random (seed);
		MobTeam mobs = generateMobs(rand);
		this.combat = new Combat (team, mobs);
	}

	public CombatStateEnum nextState(){
		switch (combat.state) {
		case CombatStateEnum.START:
			return CombatStateEnum.PLAYER_PICK;
			break;
		case CombatStateEnum.PLAYER_PICK:
			return CombatStateEnum.MOBS_PICK;
			break;
		case CombatStateEnum.MOBS_PICK:
			return CombatStateEnum.OBSERVE;
			break;
		case CombatStateEnum.OBSERVE:
			return CombatStateEnum.PLAYER_PICK;
			break;
		default:
			throw new Exception(); //TODO: define exception
		}
	}

	public void doAction(CombatAction action){
		
	}

	//////////////////////////////////////////////////////////////////////////////////
	/*										|										*/
	/* 									 PRIVATES									*/
	/*										|										*/
	//////////////////////////////////////////////////////////////////////////////////

	private MobTeam generateMobs(Random rand){
		MobTeam team = new MobTeam();

		//TODO \\REQUIRED IMPLEMENTATIONS: mobs

		return team;
	}

}