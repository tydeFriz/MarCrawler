
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

	public static DungeonRoom getDungeonRoomByType(int x, int y, int rand){
		switch ((x*1000) + y) {
		case 3003:
			return getDungeonRoomById ((rand % Constants.ROOM_3x3_COUNT)+1);
			break;
		case 3005:
			return getDungeonRoomById ((rand % Constants.ROOM_3x5_COUNT)+1);
			break;
		case 3007:
			return getDungeonRoomById ((rand % Constants.ROOM_3x7_COUNT)+1);
			break;
		case 3009:
			return getDungeonRoomById ((rand % Constants.ROOM_3x9_COUNT)+1);
			break;
		case 5005:
			return getDungeonRoomById ((rand % Constants.ROOM_5x5_COUNT)+1);
			break;
		case 5007:
			return getDungeonRoomById ((rand % Constants.ROOM_5x7_COUNT)+1);
			break;
		case 5009:
			return getDungeonRoomById ((rand % Constants.ROOM_5x9_COUNT)+1);
			break;
		case 5011:
			return getDungeonRoomById ((rand % Constants.ROOM_5x11_COUNT)+1);
			break;
		case 7007:
			return getDungeonRoomById ((rand % Constants.ROOM_7x7_COUNT)+1);
			break;
		case 7009:
			return getDungeonRoomById ((rand % Constants.ROOM_7x9_COUNT)+1);
			break;
		case 7011:
			return getDungeonRoomById ((rand % Constants.ROOM_7x11_COUNT)+1);
			break;
		case 9009:
			return getDungeonRoomById ((rand % Constants.ROOM_9x9_COUNT)+1);
			break;
		case 9011:
			return getDungeonRoomById ((rand % Constants.ROOM_9x11_COUNT)+1);
			break;
		default:
			throw new DungeonRoomNotAvailableException();
			break;
		}
	}

	private static DungeonRoom getDungeonRoomById(int id){
		switch (id) {
		default:
			throw new DungeonRoomNotAvailableException();
			break;
		}
	}

}

