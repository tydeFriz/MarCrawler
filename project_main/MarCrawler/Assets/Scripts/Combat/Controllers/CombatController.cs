using System;
using System.Collections.Generic;

public class CombatController {

	Random rand;
	public Combat combat;
	private PriorityQueue<CombatAction> actionsQueue = new PriorityQueue<CombatAction>(Constants.MIN_SPEED, Constants.MAX_SPEED);
	private MobsController mobsController;
	private EndConditionsEnum endCondition;

	/// <summary>
	/// use NULL as presetMobs if you want enemies to be generated randomly 
	/// </summary>
	public CombatController(Team team, int seed, MobTeam presetMobs/*LATER_PATCH: , int dungeonType*/){
		this.rand = new Random (seed);
		MobTeam mobs = presetMobs == null ? generateMobs(rand) : presetMobs;
		this.combat = new Combat (team, mobs);
		this.mobsController = new MobsController();
		endCondition = EndConditionsEnum.NONE;
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

		if (endCondition != EndConditionsEnum.NONE) {
			endCombat();
			return false;
		}

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

		for(int i = rand.Next() % Constants.MAX_FRONT_MOBS + 1; i > 0; i++ ){
			team.frontRow[i - 1] = MobsDispatcher.getFrontMobById(rand.Next() % Constants.FRONT_MOBS_COUNT);
		}

		for(int i = rand.Next() % (Constants.MAX_BACK_MOBS + 1); i > 0; i++ ){
			team.backRow[i - 1] = MobsDispatcher.getBackMobById(rand.Next() % Constants.BACK_MOBS_COUNT);
		}

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
			throw new InvalidCombatStateException();
		}
	}

	private void endCombat(){
		combat.team.clearAfterCombat();

		switch (endCondition) {
		case EndConditionsEnum.ESCAPE:
			GameStateController.endCombatRun();
			break;
		case EndConditionsEnum.WIN:
			GameStateController.endCombatVictory();
			break;
		case EndConditionsEnum.LOSS:
			GameStateController.endCombatLoss();
			break;
		}
	}

}