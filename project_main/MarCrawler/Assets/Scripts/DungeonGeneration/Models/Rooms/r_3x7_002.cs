using System.Collections.Generic;

public class r_3x7_002 : DungeonRoom{

	public r_3x7_002(bool rotate){
		this.rotate = rotate;
		treasures = new List<Treasure> ();
		char[,] defGrid;
		if (!rotate) {
			defGrid = new char[3, 7] {
				{ 'T', ' ', 'w', ' ', 'w', ' ', 'T' },
				{ ' ', ' ', ' ', ' ', ' ', ' ', ' ' },
				{ ' ', ' ', 'w', ' ', 'w', ' ', ' ' }
			};
			grid = new DungeonGrid(3, 7, defGrid);
			treasures.Add(new Treasure(new Coordinates(0,0)));
			treasures.Add(new Treasure(new Coordinates(0,6)));
		} 
		else {
			defGrid = new char[7, 3] {
				{ ' ', ' ', 'T' },
				{ ' ', ' ', ' ' },
				{ 'w', ' ', 'w' },
				{ ' ', ' ', ' ' },
				{ 'w', ' ', 'w' },
				{ ' ', ' ', ' ' },
				{ ' ', ' ', 'T' }
			};
			grid = new DungeonGrid(7, 3, defGrid);
			treasures.Add(new Treasure(new Coordinates(0,2)));
			treasures.Add(new Treasure(new Coordinates(6,2)));
		}
		modelFileName = "TEMP_SHITTY_NAME_REMOVE_ME_BITCH";
	}

}

