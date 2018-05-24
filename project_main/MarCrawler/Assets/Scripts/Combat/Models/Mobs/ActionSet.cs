using System.Collections.Generic;

public class ActionSet{
	//TODO: make this a more structured set, with categories

	private List<CombatAction> actions;

	public ActionSet(){
		actions = new List<CombatAction>();
	}

	public void add(CombatAction action){
		if(! actions.Contains(action))
			actions.Add(action);
	}

	public List<CombatAction> getActions(){
		return actions;
	}
}

