using System.Collections.Generic;

public class r_5x5_002 : DungeonRoom {

	public r_5x5_002(bool rotate){
		this.rotate = rotate;
		treasures = new List<Treasure> ();
		char[,] defGrid;
		if (!rotate) {
			defGrid = new char[5, 5] {
				{ ' ', 'w', ' ', 'w', ' ' },
				{ ' ', 'w', 'T', 'w', ' ' },
				{ ' ', 'w', 'w', 'w', ' ' },
				{ ' ', 'w', 'T', 'w', ' ' },
				{ ' ', ' ', ' ', ' ', ' ' }
			};
			treasures.Add (new Treasure (new Coordinates (1, 2)));
			treasures.Add (new Treasure (new Coordinates (3, 2)));
			grid = new DungeonGrid(5, 5, defGrid);
		} 
		else {
			defGrid = new char[5, 5] {
				{ ' ', ' ', ' ', ' ', ' ' },
				{ ' ', 'w', 'w', 'w', 'w' },
				{ ' ', 'T', 'w', 'T', ' ' },
				{ ' ', 'w', 'w', 'w', 'w' },
				{ ' ', ' ', ' ', ' ', ' ' }
			};
			treasures.Add (new Treasure (new Coordinates (2, 1)));
			treasures.Add (new Treasure (new Coordinates (2, 3)));
			grid = new DungeonGrid(5, 5, defGrid);
		}

		modelFileName = "TEMP_SHITTY_NAME_REMOVE_ME_BITCH";
	}

}
