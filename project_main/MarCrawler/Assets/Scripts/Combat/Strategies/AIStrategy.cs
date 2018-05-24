using System;
using System.Collections.Generic;

public abstract class AIStrategy{
	
	public abstract List<CombatAction> getNextMove (Combat context, Mob mob);

}