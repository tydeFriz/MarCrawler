﻿using System.Collections.Generic;

public class r_3x3_001 : DungeonRoom{
	
	public r_3x3_001(){
		sizeX = 3;
		sizeY = 3;
		grid = new char[3, 3]{
			{' ', ' ', ' '},
			{' ', 'T', ' '},
			{' ', ' ', ' '}
		};

		treasures = new List<Treasure> ();
		treasures.Add (new Treasure (new Coordinates(1, 1), null, 0));

		modelFileName = "TEMP_SHITTY_NAME_REMOVE_ME_BITCH";
	}

}