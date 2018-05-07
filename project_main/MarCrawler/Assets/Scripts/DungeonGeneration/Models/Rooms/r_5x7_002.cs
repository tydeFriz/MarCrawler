using System.Collections.Generic;

public class r_5x7_002 : DungeonRoom{
		
	public r_5x7_002 (bool rotate){

		this.rotate = rotate;
		treasures = new List<Treasure> ();
		char[,] defGrid;
		if (!rotate) {
			defGrid = new char[5, 7] {
				{ 'w', ' ', ' ', ' ', ' ', ' ', 'w' },
				{ ' ', ' ', ' ', ' ', ' ', ' ', ' ' },
				{ ' ', ' ', ' ', ' ', ' ', ' ', ' ' },
				{ ' ', ' ', ' ', ' ', ' ', ' ', ' ' },
				{ 'w', ' ', ' ', ' ', ' ', ' ', 'w' }
			};
			grid = new DungeonGrid(5, 7, defGrid);
		} 
		else {
			defGrid = new char[7, 5] {
				{ 'w', ' ', ' ', ' ', 'w' },
				{ ' ', ' ', ' ', ' ', ' ' },
				{ ' ', ' ', ' ', ' ', ' ' },
				{ ' ', ' ', ' ', ' ', ' ' },
				{ ' ', ' ', ' ', ' ', ' ' },
				{ ' ', ' ', ' ', ' ', ' ' },
				{ 'w', ' ', ' ', ' ', 'w' }
			};
			grid = new DungeonGrid(7, 5, defGrid);
		}

		modelFileName = "TEMP_SHITTY_NAME_REMOVE_ME_BITCH";

	}
		
}

