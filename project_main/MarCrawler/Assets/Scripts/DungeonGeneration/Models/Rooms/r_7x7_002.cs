using System.Collections.Generic;

public class r_7x7_002 : DungeonRoom{
	
	public r_7x7_002 (bool rotate){
		
		this.rotate = rotate;
		treasures = new List<Treasure> ();
		char[,] defGrid;
		if (!rotate) {
			defGrid = new char[7, 7] {
				{ 'w', ' ', ' ', ' ', 'w', 'w', 'w' },
				{ 'w', ' ', ' ', ' ', 'w', 'w', 'w' },
				{ ' ', ' ', ' ', ' ', 'w', 'w', 'w' },
				{ ' ', ' ', ' ', ' ', 'D', ' ', ' ' },
				{ ' ', ' ', ' ', ' ', 'w', 'w', 'w' },
				{ 'w', ' ', ' ', ' ', 'w', ' ', 'T' },
				{ 'w', ' ', ' ', ' ', 'S', ' ', ' ' }
			};
			treasures.Add (new Treasure (new Coordinates (5, 6)));
			grid = new DungeonGrid(7, 7, defGrid);
		} 
		else {
			defGrid = new char[7, 7] {
				{ 'w', 'w', ' ', ' ', ' ', 'w', 'w' },
				{ ' ', ' ', ' ', ' ', ' ', ' ', ' ' },
				{ ' ', ' ', ' ', ' ', ' ', ' ', ' ' },
				{ ' ', ' ', ' ', ' ', ' ', ' ', ' ' },
				{ 'S', 'w', 'w', 'D', 'w', 'w', 'w' },
				{ ' ', ' ', 'w', ' ', 'w', 'w', 'w' },
				{ ' ', 'T', 'w', ' ', 'w', 'w', 'w' }
			};
			treasures.Add (new Treasure (new Coordinates (6, 1)));
			grid = new DungeonGrid(7, 7, defGrid);
		}
		modelFileName = "TEMP_SHITTY_NAME_REMOVE_ME_BITCH";
		
	}

}

