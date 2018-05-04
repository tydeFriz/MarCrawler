﻿
public static class DungeonDispatcher{
		
	public static DungeonLayout getDungeonLayoutById(int id){
		switch (id) {
		case 1:
			return new l_01();
			break;
		default:
			throw new DungeonLayoutNotAvailableException();
			break;
		}
	}

	public static DungeonRoom getDungeonRoomByType(int sizeX, int sizeY, int rand){
		bool rotate = false;
		if (sizeX > sizeY || ((sizeX == sizeY) && (rand % 2 == 0))) {
			VariableSwapper.Swap(ref sizeX, ref sizeY);
			rotate = true;
		}
		switch ((sizeX*Constants.ROOM_SIZE_X_MAX_CARDINALITY) + sizeY) {
		/* 
		 * syntax:
		 * SIZE_X
		 * SIZE_Y
		 */
		case(3*Constants.ROOM_SIZE_X_MAX_CARDINALITY)
			+3:
			return getDungeonRoomById ((rand % Constants.ROOM_3x3_COUNT)+1, 3, 3, rotate);
			break;
		case(3*Constants.ROOM_SIZE_X_MAX_CARDINALITY)
			+5:
			return getDungeonRoomById ((rand % Constants.ROOM_3x5_COUNT)+1, 3, 5, rotate);
			break;
		case(3*Constants.ROOM_SIZE_X_MAX_CARDINALITY)
			+7:
			return getDungeonRoomById ((rand % Constants.ROOM_3x7_COUNT)+1, 3, 7, rotate);
			break;
		case(3*Constants.ROOM_SIZE_X_MAX_CARDINALITY)
			+9:
			return getDungeonRoomById ((rand % Constants.ROOM_3x9_COUNT)+1, 3, 9, rotate);
			break;
		case(5*Constants.ROOM_SIZE_X_MAX_CARDINALITY)
			+5:
			return getDungeonRoomById ((rand % Constants.ROOM_5x5_COUNT)+1, 5, 5, rotate);
			break;
		case(5*Constants.ROOM_SIZE_X_MAX_CARDINALITY)
			+7:
			return getDungeonRoomById ((rand % Constants.ROOM_5x7_COUNT)+1, 5, 7, rotate);
			break;
		case(5*Constants.ROOM_SIZE_X_MAX_CARDINALITY)
			+9:
			return getDungeonRoomById ((rand % Constants.ROOM_5x9_COUNT)+1, 5, 9, rotate);
			break;
		case(5*Constants.ROOM_SIZE_X_MAX_CARDINALITY)
			+11:
			return getDungeonRoomById ((rand % Constants.ROOM_5x11_COUNT)+1, 5, 11, rotate);
			break;
		case(7*Constants.ROOM_SIZE_X_MAX_CARDINALITY)
			+7:
			return getDungeonRoomById ((rand % Constants.ROOM_7x7_COUNT)+1, 7, 7, rotate);
			break;
		case(7*Constants.ROOM_SIZE_X_MAX_CARDINALITY)
			+9:
			return getDungeonRoomById ((rand % Constants.ROOM_7x9_COUNT)+1, 7, 9, rotate);
			break;
		case(7*Constants.ROOM_SIZE_X_MAX_CARDINALITY)
			+11:
			return getDungeonRoomById ((rand % Constants.ROOM_7x11_COUNT)+1, 7, 11, rotate);
			break;
		case(9*Constants.ROOM_SIZE_X_MAX_CARDINALITY)
			+9:
			return getDungeonRoomById ((rand % Constants.ROOM_9x9_COUNT)+1, 9, 9, rotate);
			break;
		case(9*Constants.ROOM_SIZE_X_MAX_CARDINALITY)
			+11:
			return getDungeonRoomById ((rand % Constants.ROOM_9x11_COUNT)+1, 9, 11, rotate);
			break;
		default:
			throw new DungeonRoomNotAvailableException();
			break;
		}

		return null;
	}

	//////////////////////////////////////////////////////////////////////////////////
	/*										|										*/
	/* 									 PRIVATES									*/
	/*										|										*/
	//////////////////////////////////////////////////////////////////////////////////

	private static DungeonRoom getDungeonRoomById(int id, int sizeX, int sizeY, bool rotate){
		DungeonRoom picked;
		switch (id) {
		/* 
		 * syntax:
		 * SIZE_X
		 * SIZE_Y
		 * ACTUAL_ID
		 */
		case(3*Constants.ROOM_SIZE_X_MAX_CARDINALITY*Constants.ROOM_SIZE_Y_MAX_CARDINALITY*Constants.ROOM_NUMBER_MAX_CARDINALITY)+
			(3*Constants.ROOM_SIZE_Y_MAX_CARDINALITY*Constants.ROOM_NUMBER_MAX_CARDINALITY)
			+1:
			picked = new r_3x3_001(rotate);
			break;
		default:
			throw new DungeonRoomNotAvailableException();
			break;
		}

		return null;
	}

}

