public static class Constants{

	//////////////////////////////////////////////////////////////////////////////////
	/*										|										*/
	/* 									   LOGS										*/
	/*										|										*/
	//////////////////////////////////////////////////////////////////////////////////


	public const bool DEBUG_WRITE_CONSOLE = false;
	public const bool DEBUG_WRITE_FILE = true;

	//////////////////////////////////////////////////////////////////////////////////
	/*										|										*/
	/* 								DUNGEON GENERATION								*/
	/*										|										*/
	//////////////////////////////////////////////////////////////////////////////////

	///<summary>
	/// a number too large to fit inside a dungeon, no matter what
	/// </summary>
	public const int TOO_MUCH_FOR_DUNGEON_GENERATION = 10000;

	public const int ROOM_NUMBER_MAX_CARDINALITY = 10;
	public const int ROOM_SIZE_X_MAX_CARDINALITY = 100;
	public const int ROOM_SIZE_Y_MAX_CARDINALITY = 100;

	public const int LAYOUTS_COUNT = 1;

	public const int ROOM_3x3_COUNT = 2;
	public const int ROOM_3x5_COUNT = 1;
	public const int ROOM_3x7_COUNT = 0;
	public const int ROOM_3x9_COUNT = 1;
	public const int ROOM_5x5_COUNT = 1;
	public const int ROOM_5x7_COUNT = 0;
	public const int ROOM_5x9_COUNT = 0;
	public const int ROOM_5x11_COUNT = 0;
	public const int ROOM_7x7_COUNT = 1;
	public const int ROOM_7x9_COUNT = 0;
	public const int ROOM_7x11_COUNT = 1;
	public const int ROOM_9x9_COUNT = 0;
	public const int ROOM_9x11_COUNT = 0;

	public const char PSEUDO_ROOM_MARKER = ' ';
	public const char WALL_MARKER = 'w';
	public const char DOOR_MARKER = 'D';
	public const char SECRET_DOOR_MARKER = 'S';
	public const char TREASURE_MARKER = 'T';
	public const char PATHABLE_MARKER = '.';
	public const char PATH_MARKER = '_';
	public const char DEFAULT_PATH_MARKER = 'p';
	public const char TEMP_EXPLORE_MARKER = 'F';

	public const bool STEP_X = true;
	public const bool STEP_Y = false;

	public const int TREASURE_SPAWN_PERIOD = 10;
	public const int TREASURE_SPAWN_INCREMENTAL = 1;
}