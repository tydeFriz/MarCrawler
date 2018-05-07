using System.Collections.Generic;

public class r_3x7_002 : DungeonRoom{

	public r_3x7_002(bool rotate){
		this.rotate = rotate;
		treasures = new List<Treasure> ();
		char[,] defGrid;
		if (!rotate) {
			defGrid = new char[3, 7] {
				{ ' ', ' ', 'w', ' ', 'w', ' ', ' ' },
				{ 'T', ' ', ' ', ' ', ' ', ' ', 'T' },
				{ ' ', ' ', 'w', ' ', 'w', ' ', ' ' }
			};
			grid = new DungeonGrid(3, 7, defGrid);
			treasures.Add(new Treasure(new Coordinates(1,0)));
			treasures.Add(new Treasure(new Coordinates(1,6)));
		} 
		else {
			defGrid = new char[7, 3] {
				{ ' ', 'T', ' ' },
				{ ' ', ' ', ' ' },
				{ 'w', ' ', 'w' },
				{ ' ', ' ', ' ' },
				{ 'w', ' ', 'w' },
				{ ' ', ' ', ' ' },
				{ ' ', 'T', ' ' }
			};
			grid = new DungeonGrid(7, 3, defGrid);
			treasures.Add(new Treasure(new Coordinates(0,1)));
			treasures.Add(new Treasure(new Coordinates(6,1)));
		}
		modelFileName = "TEMP_SHITTY_NAME_REMOVE_ME_BITCH";
	}

}

