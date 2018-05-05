using System.Collections.Generic;

public class r_3x3_002 : DungeonRoom{

	public r_3x3_002(bool rotate){
		this.rotate = rotate;
		treasures = new List<Treasure> ();
		char[,] defGrid;
		if (!rotate) {
			defGrid = new char[3, 3] {
				{ 'w', 'T', 'w' },
				{ ' ', 'w', 'w' },
				{ ' ', ' ', 'w' }
			};
			treasures.Add (new Treasure (new Coordinates (0, 1)));
			grid = new DungeonGrid(3, 3, defGrid);
		} 
		else {
			defGrid = new char[3, 3] {
				{ ' ', ' ', 'w' },
				{ ' ', 'w', 'T' },
				{ 'w', 'w', 'w' }
			};
			treasures.Add (new Treasure (new Coordinates (1, 2)));
			grid = new DungeonGrid(3, 3, defGrid);
		}

		modelFileName = "TEMP_SHITTY_NAME_REMOVE_ME_BITCH";
	}

}
