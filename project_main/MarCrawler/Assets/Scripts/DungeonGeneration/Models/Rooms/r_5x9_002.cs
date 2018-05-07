using System.Collections.Generic;

public class r_5x9_002 : DungeonRoom{

	public r_5x9_002 (bool rotate){
		this.rotate = rotate;
		treasures = new List<Treasure> ();
		char[,] defGrid;
		if (!rotate) {
			defGrid = new char[5, 9] {
				{ 'w', 'w', ' ', ' ', ' ', 'w', 'w', 'w', 'w' },
				{ ' ', ' ', ' ', ' ', ' ', 'S', ' ', 'w', ' ' },
				{ ' ', ' ', ' ', ' ', ' ', 'w', 'T', 'w', ' ' },
				{ ' ', ' ', ' ', ' ', ' ', 'w', 'w', 'w', ' ' },
				{ 'w', 'w', ' ', ' ', ' ', ' ', ' ', ' ', ' ' }
			};
			treasures.Add (new Treasure (new Coordinates (2, 6)));
			grid = new DungeonGrid(5, 9, defGrid);
		} 
		else {
			defGrid = new char[9, 5] {
				{ 'w', ' ', ' ', ' ', 'w' },
				{ 'w', ' ', ' ', ' ', 'w' },
				{ ' ', ' ', ' ', ' ', ' ' },
				{ ' ', ' ', ' ', ' ', ' ' },
				{ ' ', ' ', ' ', ' ', ' ' },
				{ 'w', 'w', 'w', 'S', 'w' },
				{ 'w', ' ', 'T', ' ', 'w' },
				{ 'w', ' ', ' ', ' ', 'w' },
				{ 'w', ' ', ' ', ' ', 'w' }
			};
			treasures.Add (new Treasure (new Coordinates (6, 2)));
			grid = new DungeonGrid(9, 5, defGrid);
		}

		modelFileName = "TEMP_SHITTY_NAME_REMOVE_ME_BITCH";
	}

}
