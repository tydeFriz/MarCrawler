using System;

public static class GameStateController{

	static GameStateEnum gameState = GameStateEnum.MENU;
	static Random rand = new Random();

	//LATER_PATCH: MenuController, SettingsController
	static GuildController guildGontroller = null;
	static CityController cityController = null;
	static DungeonNavigationController dungeonNavigationController = null;
	static CombatController combatController = null;

	public static void newgame(){
		//LATER_PATCH
	}

	public static void loadGame(string gameName){
		//LATER_PATCH
	}

	public static void startQuest(Quest quest){
		//LATER_PATCH: quest adds utility character \\REQUIRED_IMPLEMENTATIONS: utility characters
		//LATER_PATCH: quest dictates dungeon type and other things
		DungeonGenerationController dgc = new DungeonGenerationController();
		int seed = rand.Next();
		dungeonNavigationController = new DungeonNavigationController(dgc.generateDungeon(new Random(seed), seed) , guildGontroller.team, quest);

	}

	public static void startCombat(){

		combatController = new CombatController (dungeonNavigationController.getTeam(), rand.Next (), null);
		gameState = GameStateEnum.COMBAT;

		//LATER_PATCH: grphic faggotry
	}

}