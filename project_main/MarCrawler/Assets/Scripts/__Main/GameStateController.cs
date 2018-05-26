using System;
using System.Collections.Generic;

public static class GameStateController{

	static GameStateEnum gameState = GameStateEnum.MENU;
	static Random rand = new Random();

	//LATER_PATCH: MenuController, SettingsController
	static GuildController guildGontroller = null;
	static CityController cityController = null;
	static DungeonNavigationController dungeonNavigationController = null;
	static CombatController combatController = null;

	public static void newgame(){
		gameState = GameStateEnum.NEWGAME;
		//LATER_PATCH
	}

	public static void loadGame(string gameName){
		//LATER_PATCH
	}

	public static void exitGame(){
		gameState = GameStateEnum.MENU;
		//LATER_PATCH
		//save game, then back to menu
	}

	public static void startQuest(Quest quest){
		gameState = GameStateEnum.DUNGEON;
		//LATER_PATCH: quest adds utility character \\REQUIRED_IMPLEMENTATIONS: utility characters
		//LATER_PATCH: quest dictates dungeon type and other things
		DungeonGenerationController dgc = new DungeonGenerationController();
		int seed = rand.Next();
		dungeonNavigationController = new DungeonNavigationController(dgc.generateDungeon(new Random(seed), seed) , guildGontroller.team, quest);

	}

	public static void startCombat(){

		combatController = new CombatController (dungeonNavigationController.getTeam(), rand.Next (), null);
		gameState = GameStateEnum.COMBAT;

		//LATER_PATCH: combat (view)
	}

	public static void endCombatVictory(){
		gameState = GameStateEnum.DUNGEON;

		//TODO: give loot and exp
		//TODO: back to dungeon (view)
	}

	public static void endCombatRun(){
		gameState = GameStateEnum.DUNGEON;

		//TODO: back to dungeon (view)
	}
		
	public static void endCombatLoss(){
		gameState = GameStateEnum.CITY;

		//TODO: defeat message (view)
		//TODO: back to city (view)
	}

	public static void userInput(InputEnum input){
		//TODO
	}

	//////////////////////////////////////////////////////////////////////////////////
	/*										|										*/
	/* 									 PRIVATES									*/
	/*										|										*/
	//////////////////////////////////////////////////////////////////////////////////



}