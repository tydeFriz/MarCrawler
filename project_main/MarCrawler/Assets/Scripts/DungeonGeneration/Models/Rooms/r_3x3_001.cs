using System.Collections.Generic;

public class r_3x3_001 : DungeonRoom{
	
	public r_3x3_001(bool rotate){

		treasures = new List<Treasure> ();
		char[,] defGrid;
		defGrid = new char[3, 3] {
			{ ' ', ' ', ' ' },
			{ ' ', 'T', ' ' },
			{ ' ', ' ', ' ' }
		};
		treasures.Add (new Treasure (new Coordinates (1, 1), null, 0));
		grid = new DungeonGrid(3, 3, defGrid);

		modelFileName = "TEMP_SHITTY_NAME_REMOVE_ME_BITCH";
	}

}