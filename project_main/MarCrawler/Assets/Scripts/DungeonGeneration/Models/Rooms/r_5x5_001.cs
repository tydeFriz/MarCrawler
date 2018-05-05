using System.Collections.Generic;

public class r_5x5_001 : DungeonRoom{
	
	public r_5x5_001(bool rotate){
		treasures = new List<Treasure> ();
		char[,] defGrid;
		if (rotate) {
			defGrid = new char[5, 5] {
				{ 'w', ' ', ' ', ' ', 'w' },
				{ 'T', 'w', ' ', 'w', 'T' },
				{ ' ', 'w', ' ', 'w', ' ' },
				{ ' ', ' ', ' ', ' ', ' ' },
				{ ' ', ' ', ' ', ' ', ' ' }
			};
			treasures.Add (new Treasure (new Coordinates (1, 0)));
			treasures.Add (new Treasure (new Coordinates (1, 4)));
			grid = new DungeonGrid(3, 3, defGrid);
		} 
		else {
			defGrid = new char[5, 5] {
				{ ' ', ' ', ' ', 'T', 'w' },
				{ ' ', ' ', 'w', 'w', ' ' },
				{ ' ', ' ', ' ', ' ', ' ' },
				{ ' ', ' ', 'w', 'w', ' ' },
				{ ' ', ' ', ' ', 'T', 'w' }
			};
			treasures.Add (new Treasure (new Coordinates (0, 3)));
			treasures.Add (new Treasure (new Coordinates (4, 3)));
			grid = new DungeonGrid(5, 5, defGrid);
		}

		modelFileName = "TEMP_SHITTY_NAME_REMOVE_ME_BITCH";
	}

}

