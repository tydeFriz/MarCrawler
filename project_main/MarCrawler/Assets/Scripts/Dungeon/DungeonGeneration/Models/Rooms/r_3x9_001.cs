using System.Collections.Generic;

public class r_3x9_001 : DungeonRoom{
	
	public r_3x9_001 (bool rotate){
		this.rotate = rotate;
		treasures = new List<Treasure> ();
		char[,] defGrid;
		if (!rotate) {
			defGrid = new char[3, 9] {
				{ ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ' },
				{ ' ', 'w', 'w', ' ', ' ', ' ', 'w', 'w', ' ' },
				{ ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ' }
			};
			grid = new DungeonGrid(3, 9, defGrid);
		} 
		else {
			defGrid = new char[9, 3] {
				{ ' ', ' ', ' ' },
				{ ' ', 'w', ' ' },
				{ ' ', 'w', ' ' },
				{ ' ', ' ', ' ' },
				{ ' ', ' ', ' ' },
				{ ' ', ' ', ' ' },
				{ ' ', 'w', ' ' },
				{ ' ', 'w', ' ' },
				{ ' ', ' ', ' ' }
			};
			grid = new DungeonGrid(9, 3, defGrid);
		}
		modelFileName = "TEMP_SHITTY_NAME_REMOVE_ME_BITCH";
	}

}

