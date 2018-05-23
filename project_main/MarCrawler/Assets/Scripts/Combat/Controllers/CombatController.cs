using System;
using System.Collections.Generic;

public class CombatController {

	Random rand;
	public Combat combat;
	private PriorityQueue<CombatAction> actionsQueue = new PriorityQueue<CombatAction>(Constants.MIN_SPEED, Constants.MAX_SPEED);
	private MobsController mobsController;

	/// <summary>
	/// use NULL as presetMobs if you want enemies to be generated randomly 
	/// </summary>
	public CombatController(Team team, int seed, MobTeam presetMobs/*LATER_PATCH: , int dungeonType*/){
		this.rand = new Random (seed);
		MobTeam mobs = presetMobs == null ? generateMobs(rand) : presetMobs;
		this.combat = new Combat (team, mobs);
		this.mobsController = new MobsController();
	}

	public CombatStateEnum NextState{
		get{ return getNextState(); }
	}

	public void addAction(CombatAction action){

		actionsQueue.Enqueue(action, action.performer.getStat(StatEnum.SPEED));

	}

	public void addMobsActions(){

		foreach(CombatAction action in mobsController.getMobsActions(combat)){
			addAction (action);
		}

	}

	public bool doNextAction(){
		ActionsRunner.runAction(actionsQueue.Dequeue());

		if (actionsQueue.Size > 0)
			return true;
		return false;
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

	private CombatStateEnum getNextState(){
		switch (combat.state) {
		case CombatStateEnum.START:
			return CombatStateEnum.PLAYER_PICK;
		case CombatStateEnum.PLAYER_PICK:
			return CombatStateEnum.MOBS_PICK;
		case CombatStateEnum.MOBS_PICK:
			return CombatStateEnum.OBSERVE;
		case CombatStateEnum.OBSERVE:
			return CombatStateEnum.PLAYER_PICK;
		default:
			throw new Exception(); //TODO: define exception
		}
	}

}