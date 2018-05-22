using System.Collections.Generic;

public class r_9x9_001 : DungeonRoom{

	public r_9x9_001(bool rotate){
		this.rotate = rotate;
		treasures = new List<Treasure> ();
		char[,] defGrid;
		defGrid = new char[9, 9] {
			{ ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ' },
			{ ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ' },
			{ ' ', ' ', ' ', 'w', ' ', 'w', ' ', ' ', ' ' },
			{ ' ', ' ', 'w', 'w', ' ', 'w', 'w', ' ', ' ' },
			{ ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ' },
			{ ' ', ' ', 'w', 'w', ' ', 'w', 'w', ' ', ' ' },
			{ ' ', ' ', ' ', 'w', ' ', 'w', ' ', ' ', ' ' },
			{ ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ' },
			{ ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ' }
		};
		grid = new DungeonGrid(9, 9, defGrid);

		modelFileName = "TEMP_SHITTY_NAME_REMOVE_ME_BITCH";
	}

}