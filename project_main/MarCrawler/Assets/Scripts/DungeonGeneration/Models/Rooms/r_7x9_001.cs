using System.Collections.Generic;

public class r_7x9_001 : DungeonRoom{
		
	public r_7x9_001 (bool rotate){
		
		this.rotate = rotate;
		treasures = new List<Treasure> ();
		char[,] defGrid;
		if (!rotate) {
			defGrid = new char[7, 9] {
				{ 'T', 'w', ' ', ' ', ' ', ' ', 'w', 'w', 'w' },
				{ ' ', ' ', ' ', 'w', ' ', ' ', 'w', 'w', 'w' },
				{ 'w', 'w', 'w', ' ', ' ', ' ', ' ', ' ', ' ' },
				{ ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ' },
				{ 'w', 'w', 'w', ' ', ' ', ' ', ' ', ' ', ' ' },
				{ ' ', ' ', ' ', 'w', ' ', ' ', 'w', 'w', 'w' },
				{ ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ' }
			};
			treasures.Add (new Treasure (new Coordinates (0, 0)));
			grid = new DungeonGrid(7, 9, defGrid);
		} 
		else {
			defGrid = new char[9, 7] {
				{ ' ', ' ', 'w', ' ', 'w', ' ', 'T' },
				{ 'w', ' ', 'w', ' ', 'w', ' ', 'w' },
				{ ' ', ' ', 'w', ' ', 'w', ' ', ' ' },
				{ ' ', 'w', ' ', ' ', ' ', 'w', ' ' },
				{ ' ', ' ', ' ', ' ', ' ', ' ', ' ' },
				{ ' ', ' ', ' ', ' ', ' ', ' ', ' ' },
				{ ' ', 'w', ' ', ' ', ' ', 'w', 'w' },
				{ ' ', 'w', ' ', ' ', ' ', 'w', 'w' },
				{ ' ', 'w', ' ', ' ', ' ', 'w', 'w' }
			};
			treasures.Add (new Treasure (new Coordinates (0, 6)));
			grid = new DungeonGrid(9, 7, defGrid);
		}
		modelFileName = "TEMP_SHITTY_NAME_REMOVE_ME_BITCH";

	}

}

