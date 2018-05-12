using System;

public class DungeonNavigationController{ //TODO

	Random rand;
	Dungeon dungeon;
	Team team;
	Coordinates playerPosition;
	OrientationEnum playerOrientation;
	bool inCombat;
	int colour;
	int chanceCounter;

	public DungeonNavigationController(Dungeon dungeon, Team team){

		this.dungeon = dungeon;
		this.team = team;
		this.playerPosition = dungeon.getStartingPosition();
		this.inCombat = false;
		this.colour = 0;
		this.chanceCounter = 0;
	}
		
	public void playerMove(Coordinates to){

		if (dungeon.canWalk (to)) {
			playerPosition = to;
			chanceCounter += (rand.Next () % Constants.ENCOUNTER_MAX_INCREMENTAL - Constants.ENCOUNTER_MIN_INCREMENTAL)
				+ Constants.ENCOUNTER_MIN_INCREMENTAL;

			if (chanceCounter >= 100) {
				chanceCounter = 0;
				colour++;
			}

			if (colour >= Constants.ENCOUNTER_COLOUR_TRIGGER) {
				colour = 0;
				inCombat = true;
				//TODO: start combat
			}
		}

	}

	public void playerTurn(OrientationEnum direction){
		playerOrientation = direction;
	}

	public void  playerUseDoor(Coordinates doorPosition){
		playerPosition = dungeon.useDoor(playerPosition, doorPosition);
	}

	public Treasure playerOpenTreasure(Coordinates treasurePosition){
		return dungeon.openTreasure(treasurePosition);
	}

	public void aiTurn(){
		//LATER_PATCH: \\REQUIRED IMPLEMENTATIONS: FOEs, AI
	}

}