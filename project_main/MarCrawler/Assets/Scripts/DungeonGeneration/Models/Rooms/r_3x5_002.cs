using System.Collections.Generic;

public class r_3x5_002: DungeonRoom{
		
	public r_3x5_002(bool rotate){
		this.rotate = rotate;
		treasures = new List<Treasure> ();
		char[,] defGrid;
		if (!rotate) {
			defGrid = new char[3, 5] {
				{ ' ', 'w', ' ', 'T', 'w' },
				{ ' ', 'w', 'w', 'w', ' ' },
				{ ' ', ' ', ' ', ' ', ' ' }
			};
			treasures.Add (new Treasure (new Coordinates (0, 3)));
			grid = new DungeonGrid(3, 5, defGrid);
		} 
		else {
			defGrid = new char[5, 3] {
				{ ' ', ' ', ' ' },
				{ ' ', 'w', 'w' },
				{ ' ', 'w', ' ' },
				{ ' ', 'w', 'T' },
				{ ' ', ' ', 'w' }
			};
			treasures.Add (new Treasure (new Coordinates (3, 2)));
			grid = new DungeonGrid(5, 3, defGrid);
		}

		modelFileName = "TEMP_SHITTY_NAME_REMOVE_ME_BITCH";
	}

}

