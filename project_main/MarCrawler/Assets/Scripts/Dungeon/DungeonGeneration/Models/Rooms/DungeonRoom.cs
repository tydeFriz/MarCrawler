using System.Collections.Generic;

public abstract class DungeonRoom {

	public DungeonGrid grid;
	public List<Treasure> treasures;
	public string modelFileName;
	public bool rotate;
	//LATER_PATCH - maybe: list of "notables" 
}
