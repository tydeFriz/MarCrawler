using System.Collections.Generic;

public class MobsController{

	public List<CombatAction> getMobsActions(Combat combat){
		List<CombatAction> actions = new List<CombatAction> ();

		foreach (Mob mob in combat.mobs.getMobs()) {
			List<CombatAction> newActions = getNextActions(mob, combat);
			foreach (CombatAction ca in newActions) {
				actions.Add(ca);
			}
		}

		return actions;
	}

	//////////////////////////////////////////////////////////////////////////////////
	/*										|										*/
	/* 									 PRIVATES									*/
	/*										|										*/
	//////////////////////////////////////////////////////////////////////////////////

	private List<CombatAction> getNextActions(Mob mob, Combat combat){

		return mob.getNextMove(combat);

	}

}

