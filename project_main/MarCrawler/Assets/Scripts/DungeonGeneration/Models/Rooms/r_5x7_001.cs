using System.Collections.Generic;

public class r_5x7_001 : DungeonRoom {

	public r_5x7_001 (bool rotate){
		this.rotate = rotate;
		treasures = new List<Treasure> ();
		char[,] defGrid;
		if (!rotate) {
			defGrid = new char[5, 7] {
				{ ' ', ' ', ' ', ' ', ' ', ' ', ' ' },
				{ 'T', 'w', ' ', ' ', ' ', 'w', ' ' },
				{ ' ', ' ', ' ', ' ', ' ', ' ', ' ' },
				{ ' ', 'w', ' ', ' ', ' ', 'w', ' ' },
				{ ' ', ' ', ' ', ' ', ' ', ' ', ' ' }
			};
			treasures.Add (new Treasure (new Coordinates (1, 0)));
			grid = new DungeonGrid(5, 7, defGrid);
		} 
		else {
			defGrid = new char[7, 5] {
				{ ' ', ' ', ' ', 'T', ' ' },
				{ ' ', 'w', ' ', 'w', ' ' },
				{ ' ', ' ', ' ', ' ', ' ' },
				{ ' ', ' ', ' ', ' ', ' ' },
				{ ' ', ' ', ' ', ' ', ' ' },
				{ ' ', 'w', ' ', 'w', ' ' },
				{ ' ', ' ', ' ', ' ', ' ' }
			};
			treasures.Add (new Treasure (new Coordinates (0, 3)));
			grid = new DungeonGrid(7, 5, defGrid);
		}

		modelFileName = "TEMP_SHITTY_NAME_REMOVE_ME_BITCH";
	}

}

