
public class LayoutValidator  {

	/// <summary>
	/// check if all layouts are declared correctly
	/// </summary>
	public static void runValidation(){

		for(int i = 1; i <= Constants.LAYOUTS_COUNT; i++){
			singleValidation(DungeonDispatcher.getDungeonLayoutById(i), i);
		}

	}

	private static void singleValidation(DungeonLayout layout, int id){

		TestLogger.log("validating layout - id: "+id);

		if (layout == null)
			throw new DungeonLayoutNotAvailableException ("DungeonDispatcher returned NULL for layout id: "+id);
		if (layout.grid == null)
			throw new WrongLayoutDeclarationException ("layout.grid is NULL. layout id: "+id);
		if (layout.rooms == null)
			throw new WrongLayoutDeclarationException ("layout.rooms is NULL. layout id: "+id);
		if (layout.pathableAreas == null)
			throw new WrongLayoutDeclarationException ("layout.pathableAreas is NULL. layout id: "+id);
		
		foreach(PseudoRoom room in layout.rooms){
			checkRoom (layout, room);
		}
		foreach(PathableArea area in layout.pathableAreas){
			checkArea (layout, area);
		}
	
		TestLogger.log ("validated");
		TestLogger.log ("");
	}

	private static void checkRoom(DungeonLayout layout, PseudoRoom room){
		for (int x = room.position.x; x < room.sizeX+room.position.x; x++) {
			for (int y = room.position.y; y < room.sizeY+room.position.y; y++) {
				if (layout.grid.grid [x, y] != Constants.PSEUDO_ROOM_MARKER)
					throw new WrongLayoutDeclarationException("PseudoRoom declaration error. position: "+room.position.x+","+room.position.y);
			}
		}
	}

	private static void checkArea(DungeonLayout layout, PathableArea area){
		for (int x = area.position.x; x < area.sizeX+area.position.x; x++) {
			for (int y = area.position.y; y < area.sizeY+area.position.y; y++) {
				if (layout.grid.grid [x, y] != Constants.PATHABLE_MARKER)
					throw new WrongLayoutDeclarationException("PathableArea declaration error. position: "+area.position.x+","+area.position.y);
			}
		}
	}

}
