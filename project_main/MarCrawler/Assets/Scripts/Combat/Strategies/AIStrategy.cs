using System;
using System.Collections.Generic;

public abstract class AIStrategy{

	public abstract List<CombatAction> getNextMove (Combat context, Random rand/*TODO: set of possible actions*/);

}