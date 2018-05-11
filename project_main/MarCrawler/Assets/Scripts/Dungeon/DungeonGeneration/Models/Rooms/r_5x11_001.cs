using System.Collections.Generic;

public class r_5x11_001 : DungeonRoom{

	public r_5x11_001 (bool rotate){

		this.rotate = rotate;
		treasures = new List<Treasure> ();
		char[,] defGrid;
		if (!rotate) {
			defGrid = new char[5, 11] {
				{' ', ' ', ' ', 'w', 'w', ' ', 'w', 'w', ' ', ' ', ' '},
				{'w', 'w', ' ', ' ', ' ', ' ', ' ', ' ', ' ', 'w', ' '},
				{' ', 'w', 'T', ' ', ' ', ' ', ' ', ' ', ' ', 'w', ' '},
				{' ', 'w', 'w', 'w', 'w', 'w', 'w', 'w', 'w', 'w', ' '},
				{' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' '}
			};
			treasures.Add (new Treasure (new Coordinates (2, 2)));
			grid = new DungeonGrid(5, 11, defGrid);
		} 
		else {
			defGrid = new char[11, 5] {
				{' ', ' ', ' ', 'w', ' '},
				{' ', 'w', 'w', 'w', ' '},
				{' ', 'w', 'T', ' ', ' '},
				{' ', 'w', ' ', ' ', 'w'},
				{' ', 'w', ' ', ' ', 'w'},
				{' ', 'w', ' ', ' ', ' '},
				{' ', 'w', ' ', ' ', 'w'},
				{' ', 'w', ' ', ' ', 'w'},
				{' ', 'w', ' ', ' ', ' '},
				{' ', 'w', 'w', 'w', ' '},
				{' ', ' ', ' ', ' ', ' '}
			};
			treasures.Add (new Treasure (new Coordinates (2, 2)));
			grid = new DungeonGrid(11, 5, defGrid);
		}
		modelFileName = "TEMP_SHITTY_NAME_REMOVE_ME_BITCH";

	}

}

