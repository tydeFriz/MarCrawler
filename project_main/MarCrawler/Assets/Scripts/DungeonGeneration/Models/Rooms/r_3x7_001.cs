using System.Collections.Generic;

public class r_3x7_001 : DungeonRoom{

	public r_3x7_001(bool rotate){
		this.rotate = rotate;
		treasures = new List<Treasure> ();
		char[,] defGrid;
		if (!rotate) {
			defGrid = new char[3, 7] {
				{ 'w', 'w', 'w', ' ', 'w', 'w', 'w' },
				{ ' ', ' ', ' ', ' ', ' ', ' ', ' ' },
				{ 'w', 'w', 'w', ' ', 'w', 'w', 'w' }
			};
			grid = new DungeonGrid(3, 7, defGrid);
		} 
		else {
			defGrid = new char[7, 3] {
				{ 'w', ' ', 'w' },
				{ 'w', ' ', 'w' },
				{ 'w', ' ', 'w' },
				{ ' ', ' ', ' ' },
				{ 'w', ' ', 'w' },
				{ 'w', ' ', 'w' },
				{ 'w', ' ', 'w' }
			};
			grid = new DungeonGrid(7, 3, defGrid);
		}
		modelFileName = "TEMP_SHITTY_NAME_REMOVE_ME_BITCH";
	}

}

