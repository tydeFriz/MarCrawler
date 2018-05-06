using System.Collections.Generic;

public class r_5x9_001 : DungeonRoom{
		
	public r_5x9_001 (bool rotate){
		this.rotate = rotate;
		treasures = new List<Treasure> ();
		char[,] defGrid;
		if (!rotate) {
			defGrid = new char[5, 9] {
				{ ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ' },
				{ 'T', 'w', 'w', ' ', ' ', ' ', 'w', 'w', ' ' },
				{ ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ' },
				{ ' ', 'w', 'w', ' ', ' ', ' ', 'w', 'w', ' ' },
				{ ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ' }
			};
			treasures.Add (new Treasure (new Coordinates (1, 0)));
			grid = new DungeonGrid(5, 9, defGrid);
		} 
		else {
			defGrid = new char[9, 5] {
				{ ' ', ' ', ' ', 'T', ' ' },
				{ ' ', 'w', ' ', 'w', ' ' },
				{ ' ', 'w', ' ', 'w', ' ' },
				{ ' ', ' ', ' ', ' ', ' ' },
				{ ' ', ' ', ' ', ' ', ' ' },
				{ ' ', ' ', ' ', ' ', ' ' },
				{ ' ', 'w', ' ', 'w', ' ' },
				{ ' ', 'w', ' ', 'w', ' ' },
				{ ' ', ' ', ' ', ' ', ' ' }
			};
			treasures.Add (new Treasure (new Coordinates (0, 3)));
			grid = new DungeonGrid(9, 5, defGrid);
		}

		modelFileName = "TEMP_SHITTY_NAME_REMOVE_ME_BITCH";
	}

}

