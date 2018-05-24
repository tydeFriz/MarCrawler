using System;

public class DungeonNavigationController{

	Random rand;
	Quest currentQuest;
	Dungeon dungeon;
	Team team;
	Coordinates playerPosition;
	OrientationEnum playerOrientation;
	int colour;
	int chanceCounter;

	public DungeonNavigationController(Dungeon dungeon, Team team, Quest quest){

		this.dungeon = dungeon;
		this.team = team;
		this.playerPosition = dungeon.getStartingPosition();
		this.colour = 0;
		this.chanceCounter = 0;
		this.currentQuest = quest;
	}

	public Team getTeam(){
		return team;
	}
		
	public void playerMove(DirectionEnum direction){
		
		Coordinates to = getTargetCoordinates(direction);

		if (dungeon.canWalk (to)) {
			playerPosition = to;
			updateColour();
		}

	}

	public void playerTurn(OrientationEnum direction){
		playerOrientation = direction;
	}

	public void playerUseDoor(Coordinates doorPosition){
		playerPosition = dungeon.useDoor(playerPosition, doorPosition);
		updateColour();
	}

	public Treasure playerOpenTreasure(Coordinates treasurePosition){
		return dungeon.openTreasure(treasurePosition);
	}

	public void aiTurn(){
		//LATER_PATCH: \\REQUIRED IMPLEMENTATIONS: FOEs, AI
	}

	//////////////////////////////////////////////////////////////////////////////////
	/*										|										*/
	/* 									 PRIVATES									*/
	/*										|										*/
	//////////////////////////////////////////////////////////////////////////////////

	private void updateColour(){
		chanceCounter += (rand.Next () % Constants.ENCOUNTER_MAX_INCREMENTAL - Constants.ENCOUNTER_MIN_INCREMENTAL)
			+ Constants.ENCOUNTER_MIN_INCREMENTAL;

		if (chanceCounter >= 100) {
			chanceCounter = 0;
			colour++;
		}

		if (colour >= Constants.ENCOUNTER_COLOUR_TRIGGER) {
			colour = 0;
			GameStateController.startCombat();
		}
	}

	//PLEASE. Don't look at the code here.
	private Coordinates getTargetCoordinates(DirectionEnum direction){

		int toX = playerPosition.x;
		int toY = playerPosition.y;

		if (direction == DirectionEnum.FORWARD) {
			switch(playerOrientation){
			case OrientationEnum.NORTH:
				toY--;
				break;
			case OrientationEnum.SOUTH:
				toY++;
				break;
			case OrientationEnum.EAST:
				toX++;
				break;
			case OrientationEnum.WEST:
				toX--;
				break;
			}
		}
		else if(direction == DirectionEnum.BACKWARD){
			switch(playerOrientation){
			case OrientationEnum.NORTH:
				toY++;
				break;
			case OrientationEnum.SOUTH:
				toY--;
				break;
			case OrientationEnum.EAST:
				toX--;
				break;
			case OrientationEnum.WEST:
				toX++;
				break;
			}
		}
		else if(direction == DirectionEnum.LEFT){
			switch(playerOrientation){
			case OrientationEnum.NORTH:
				toX--;
				break;
			case OrientationEnum.SOUTH:
				toX++;
				break;
			case OrientationEnum.EAST:
				toY--;
				break;
			case OrientationEnum.WEST:
				toY++;
				break;
			}
		}
		else if(direction == DirectionEnum.RIGHT){
			switch(playerOrientation){
			case OrientationEnum.NORTH:
				toX++;
				break;
			case OrientationEnum.SOUTH:
				toX--;
				break;
			case OrientationEnum.EAST:
				toY++;
				break;
			case OrientationEnum.WEST:
				toY--;
				break;
			}
		}

		return new Coordinates(toX, toY);
	}

}