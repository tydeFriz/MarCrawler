using System;

public class NameGeneratorTester
{

	public static void testGeneration(){
		
		Random rand = new System.Random();
		for (int i = 0; i < 100; i++) {
			TestLogger.log ("new name: "+RandomNameGenerator.generateName(rand));
		}
	}

}

