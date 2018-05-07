using System.Collections.Generic;

public class r_7x11_002 : DungeonRoom{

	public r_7x11_002(bool rotate){
		this.rotate = rotate;
		treasures = new List<Treasure> ();
		char[,] defGrid;
		if (!rotate) {
			defGrid = new char[7, 11] {
				{ ' ', ' ', ' ', 'w', 'w', ' ', 'w', 'w', ' ', ' ', ' ' },
				{ ' ', 'w', 'w', 'w', ' ', ' ', ' ', 'w', 'w', 'w', ' ' },
				{ ' ', 'w', ' ', ' ', ' ', ' ', ' ', ' ', ' ', 'w', ' ' },
				{ ' ', 'w', ' ', ' ', ' ', ' ', ' ', ' ', ' ', 'w', ' ' },
				{ ' ', 'w', ' ', ' ', ' ', ' ', ' ', ' ', ' ', 'w', ' ' },
				{ ' ', 'w', 'w', 'w', ' ', ' ', ' ', 'w', 'w', 'w', ' ' },
				{ ' ', ' ', ' ', 'w', 'w', ' ', 'w', 'w', ' ', ' ', ' ' }
			};
			grid = new DungeonGrid(7, 11, defGrid);
		} 
		else {
			defGrid = new char[11, 7] {
				{ ' ', ' ', ' ', ' ', ' ', ' ', ' ' },
				{ ' ', 'w', 'w', 'w', 'w', 'w', ' ' },
				{ ' ', 'w', ' ', ' ', ' ', 'w', ' ' },
				{ 'w', 'w', ' ', ' ', ' ', 'w', 'w' },
				{ 'w', ' ', ' ', ' ', ' ', ' ', 'w' },
				{ ' ', ' ', ' ', ' ', ' ', ' ', ' ' },
				{ 'w', ' ', ' ', ' ', ' ', ' ', 'w' },
				{ 'w', 'w', ' ', ' ', ' ', 'w', 'w' },
				{ ' ', 'w', ' ', ' ', ' ', 'w', ' ' },
				{ ' ', 'w', 'w', 'w', 'w', 'w', ' ' },
				{ ' ', ' ', ' ', ' ', ' ', ' ', ' ' }
			};
			grid = new DungeonGrid(11, 7, defGrid);
		}
		modelFileName = "TEMP_SHITTY_NAME_REMOVE_ME_BITCH";
	}

}
