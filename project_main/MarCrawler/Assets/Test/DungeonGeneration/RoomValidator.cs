using System;

public class RoomValidator {

	/// <summary>
	/// check if all rooms are declared correctly.
	/// does NOT check both rotations for rooms where sizeX == sizeY
	/// </summary>
	public static void runValidation(){
		Random r = new Random ();
		//validate 3x3
		for(int id = 0; id < Constants.ROOM_3x3_COUNT; id++){
			singleValidation(DungeonDispatcher.getDungeonRoomByType(3, 3, id, r), id+1, 3, 3);
		}
		//validate 3x5, 5x3
		for(int id = 0; id < Constants.ROOM_3x5_COUNT; id++){
			singleValidation(DungeonDispatcher.getDungeonRoomByType(3, 5, id, r), id+1, 3, 5);
			singleValidation(DungeonDispatcher.getDungeonRoomByType(5, 3, id, r), id+1, 5, 3);
		}
		//validate 3x7, 7x3
		for(int id = 0; id < Constants.ROOM_3x7_COUNT; id++){
			singleValidation(DungeonDispatcher.getDungeonRoomByType(3, 7, id, r), id+1, 3, 7);
			singleValidation(DungeonDispatcher.getDungeonRoomByType(7, 3, id, r), id+1, 7, 3);
		}
		//validate 3x9, 9x3
		for(int id = 0; id < Constants.ROOM_3x9_COUNT; id++){
			singleValidation(DungeonDispatcher.getDungeonRoomByType(3, 9, id, r), id+1, 3, 9);
			singleValidation(DungeonDispatcher.getDungeonRoomByType(9, 3, id, r), id+1, 9, 3);
		}
		//validate 5x5
		for(int id = 0; id < Constants.ROOM_5x5_COUNT; id++){
			singleValidation(DungeonDispatcher.getDungeonRoomByType(5, 5, id, r), id+1, 5, 5);
		}
		//validate 5x7, 7x5
		for(int id = 0; id < Constants.ROOM_5x7_COUNT; id++){
			singleValidation(DungeonDispatcher.getDungeonRoomByType(5, 7, id, r), id+1, 5, 7);
			singleValidation(DungeonDispatcher.getDungeonRoomByType(7, 5, id, r), id+1, 7, 5);
		}
		//validate 5x9, 9x5
		for(int id = 0; id < Constants.ROOM_5x9_COUNT; id++){
			singleValidation(DungeonDispatcher.getDungeonRoomByType(5, 9, id, r), id+1, 5, 9);
			singleValidation(DungeonDispatcher.getDungeonRoomByType(9, 5, id, r), id+1, 9, 5);
		}
		//validate 5x11, 11x5
		for(int id = 0; id < Constants.ROOM_5x11_COUNT; id++){
			singleValidation(DungeonDispatcher.getDungeonRoomByType(5, 11, id, r), id+1, 5, 11);
			singleValidation(DungeonDispatcher.getDungeonRoomByType(11, 5, id, r), id+1, 11, 5);
		}
		//validate 7x7
		for(int id = 0; id < Constants.ROOM_7x7_COUNT; id++){
			singleValidation(DungeonDispatcher.getDungeonRoomByType(7, 7, id, r), id+1, 7, 7);
		}
		//validate 7x9, 9x7
		for(int id = 0; id < Constants.ROOM_7x9_COUNT; id++){
			singleValidation(DungeonDispatcher.getDungeonRoomByType(7, 9, id, r), id+1, 7, 9);
			singleValidation(DungeonDispatcher.getDungeonRoomByType(9, 7, id, r), id+1, 9, 7);
		}
		//validate 7x11, 11x7
		for(int id = 0; id < Constants.ROOM_7x11_COUNT; id++){
			singleValidation(DungeonDispatcher.getDungeonRoomByType(7, 11, id, r), id+1, 7, 11);
			singleValidation(DungeonDispatcher.getDungeonRoomByType(11, 7, id, r), id+1, 11, 7);
		}
		//validate 9x9
		for(int id = 0; id < Constants.ROOM_9x9_COUNT; id++){
			singleValidation(DungeonDispatcher.getDungeonRoomByType(9, 9, id, r), id+1, 9, 9);
		}
		//validate 9x11, 11x9
		for(int id = 0; id < Constants.ROOM_9x11_COUNT; id++){
			singleValidation(DungeonDispatcher.getDungeonRoomByType(9, 11, id, r), id+1, 9, 11);
			singleValidation(DungeonDispatcher.getDungeonRoomByType(11, 9, id, r), id+1, 11, 9);
		}


	}

	private static void singleValidation(DungeonRoom room, int id, int sizeX, int sizeY){

		TestLogger.log("validating room - id: "+id+" size: "+sizeX+"x"+sizeY);

		if (room == null)
			throw new DungeonLayoutNotAvailableException ("DungeonDispatcher returned NULL for room id: "+id+" size: "+sizeX+"x"+sizeY);
		if (room.grid == null)
			throw new WrongRoomDeclarationException ("room.grid is NULL. room id: "+id+" size: "+sizeX+"x"+sizeY);
		if (room.grid.sizeX != sizeX)
			throw new WrongRoomDeclarationException ("room.grid.sizeX is wrong. room id: "+id+" size: "+sizeX+"x"+sizeY);
		if(room.grid.sizeY != sizeY)
			throw new WrongRoomDeclarationException ("room.grid.sizeY is wrong. room id: "+id+" size: "+sizeX+"x"+sizeY);
		if (room.treasures == null)
			throw new WrongRoomDeclarationException ("room.treasures is NULL. room id: "+id+" size: "+sizeX+"x"+sizeY);
		try{
			char a = room.grid.grid[sizeX, 0];
			throw new WrongRoomDeclarationException("room.grid.grid's X axis. room id: "+id+" size: "+sizeX+"x"+sizeY);
		}catch(Exception e){}
		try{
			char a = room.grid.grid[0, sizeY];
			throw new WrongRoomDeclarationException("room.grid.grid's Y axis. room id: "+id+" size: "+sizeX+"x"+sizeY);
		}catch(Exception e){}
		foreach (Treasure t in room.treasures) {
			if(!room.grid.isTreasure(t.position))
				throw new WrongRoomDeclarationException("treasure position mismatch. room id: "+id+" size: "+sizeX+"x"+sizeY);
		}

		TestLogger.log ("validated");
		TestLogger.log ("");
	}

}
