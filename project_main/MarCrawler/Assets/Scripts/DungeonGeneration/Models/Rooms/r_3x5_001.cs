using System.Collections.Generic;

public class r_3x5_001 : DungeonRoom{

	public r_3x5_001(bool rotate){
		treasures = new List<Treasure> ();
		char[,] defGrid;
		if (rotate) {
			defGrid = new char[3, 5] {
				{ 'w', ' ', ' ', ' ', 'w' },
				{ ' ', ' ', ' ', ' ', ' ' },
				{ ' ', ' ', ' ', ' ', ' ' }
			};
			grid = new DungeonGrid(3, 3, defGrid);
		} 
		else {
			defGrid = new char[5, 3] {
				{ 'w', ' ', ' ' },
				{ ' ', ' ', ' ' },
				{ ' ', ' ', ' ' },
				{ ' ', ' ', ' ' },
				{ 'w', ' ', ' ' }
			};
			grid = new DungeonGrid(3, 3, defGrid);
		}

		modelFileName = "TEMP_SHITTY_NAME_REMOVE_ME_BITCH";
	}

}

