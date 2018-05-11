using System.Collections.Generic;

public class r_3x3_003 : DungeonRoom {

	public r_3x3_003(bool rotate){
		this.rotate = rotate;
		treasures = new List<Treasure> ();
		char[,] defGrid;

		defGrid = new char[3, 3] {
			{ 'w', ' ', 'w' },
			{ ' ', ' ', ' ' },
			{ 'w', ' ', 'w' }
		};
		grid = new DungeonGrid(3, 3, defGrid);

		modelFileName = "TEMP_SHITTY_NAME_REMOVE_ME_BITCH";
	}

}
