﻿using System.Collections.Generic;

public class r_3x5_003 : DungeonRoom {

	public r_3x5_003(bool rotate){
		this.rotate = rotate;
		treasures = new List<Treasure> ();
		char[,] defGrid;
		if (!rotate) {
			defGrid = new char[3, 5] {
				{ ' ', ' ', ' ', ' ', ' ' },
				{ ' ', 'w', 'w', 'w', ' ' },
				{ ' ', ' ', ' ', ' ', ' ' }
			};
			grid = new DungeonGrid(3, 5, defGrid);
		} 
		else {
			defGrid = new char[5, 3] {
				{ ' ', ' ', ' ' },
				{ ' ', 'w', ' ' },
				{ ' ', 'w', ' ' },
				{ ' ', 'w', ' ' },
				{ ' ', ' ', ' ' }
			};
			grid = new DungeonGrid(5, 3, defGrid);
		}

		modelFileName = "TEMP_SHITTY_NAME_REMOVE_ME_BITCH";
	}

}
