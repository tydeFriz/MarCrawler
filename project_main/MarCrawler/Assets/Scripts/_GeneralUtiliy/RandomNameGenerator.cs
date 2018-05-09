using System;

public static class RandomNameGenerator{

	public static string generateName(Random rand){

		string name = "";
		int howManyParts = (rand.Next() % 3) + 2;
		for (int i = 0; i < howManyParts; i++) {
			name += parts[rand.Next() % partsCount];
		}

		return name;
	}
		
	//////////////////////////////////////////////////////////////////////////////////
	/*										|										*/
	/* 									 PRIVATES									*/
	/*										|										*/
	//////////////////////////////////////////////////////////////////////////////////

	private const int partsCount = 25;
	private static string[] parts = new string[partsCount]{
		"pri",
		"bal",
		"ka",
		"grim",
		"fus",
		"ro",
		"da",
		"pan",
		"ta",
		"loon",
		"is",
		"grep",
		"git",
		"man",
		"bear",
		"pig",
		"fiz",
		"com",
		"net",
		"aba",
		"ae",
		"are",
		"odi",
		"ipu",
		"odo"
	};

}

