using System;
using System.Collections.Generic;

public class DungeonGrid{

	public int sizeX;
	public int sizeY;
	public char[,] grid;

	public DungeonGrid(int x, int y){
		this.sizeX = x;
		this.sizeY = y;
		this.grid = new char[x, y];
		for(int i = 0; i < x; i++){
			for(int j = 0; j < y; j++){
				this.grid[i, j] = Constants.PATHABLE_MARKER;
			}
		}
	}

	public DungeonGrid(int x, int y, char[,] grid){
		this.sizeX = x;
		this.sizeY = y;
		this.grid = new char[x, y];
		for(int i = 0; i < x; i++){
			for(int j = 0; j < y; j++){
				this.grid[i, j] = grid[i, j];
			}
		}
	}

	public bool isValidPoint(Coordinates point){
		if(point.x < 0 || point.x >= sizeX || point.y < 0 || point.y >= sizeY)
			return false;
		return true;
	}

	public Coordinates find(char target){
		for(int x = 0; x < sizeX; x++){
			for(int y = 0; y < sizeY; y++){
				if (grid [x, y] == target)
					return new Coordinates (x, y);
			}
		}
		return null;
	}

	public void put(Coordinates point, char marker){
		grid[point.x, point.y] = marker;
	}

	public bool isCulDeSac(Coordinates position){

		if (!isValidPoint (position))
			return false;
		if (grid [position.x, position.y] != Constants.PATH_MARKER)
			return false;

		int count = 0;
		Coordinates point = new Coordinates(position.x-1, position.y);
		if (isWall(point) || !isValidPoint(point))
			count++;
		point = new Coordinates(position.x+1, position.y);
		if (isWall(point) || !isValidPoint(point))
			count++;
		point = new Coordinates(position.x, position.y-1);
		if (isWall(point) || !isValidPoint(point))
			count++;
		point = new Coordinates(position.x, position.y+1);
		if (isWall(point) || !isValidPoint(point))
			count++;

		if (count == 3)
			return true;
		else
			return false;
	}

	public bool isDoor(Coordinates point){
		if (!isValidPoint(point))
			return false;
		if (grid [point.x, point.y] != Constants.DOOR_MARKER && grid [point.x, point.y] != Constants.SECRET_DOOR_MARKER)
			return false;
		return true;
	}

	public bool isPath(Coordinates point){
		if (!isValidPoint(point))
			return false;
		if (grid [point.x, point.y] != Constants.PATH_MARKER)
			return false;
		return true;
	}


	public bool isForcedPath(Coordinates point){
		if (!isValidPoint(point))
			return false;
		if (grid [point.x, point.y] != Constants.DEFAULT_PATH_MARKER)
			return false;
		return true;
	}

	public bool isWall(Coordinates point){
		if (!isValidPoint(point))
			return false;
		if (grid [point.x, point.y] != Constants.WALL_MARKER)
			return false;
		return true;
	}

	public bool isTreasure(Coordinates point){
		if (!isValidPoint(point))
			return false;
		if (grid [point.x, point.y] != Constants.TREASURE_MARKER)
			return false;
		return true;
	}

	public Coordinates getOtherDoorSide(Coordinates startingPosition, Coordinates doorPosition){
		int directionX = doorPosition.x - startingPosition.x;
		int directionY = doorPosition.y - startingPosition.y;
		return new Coordinates (doorPosition.x + directionX, doorPosition.y + directionY);
	}

	public List<Coordinates> getCulDeSacs(){
		List<Coordinates> culDeSacs = new List<Coordinates>();

		for(int i = 0; i < sizeX; i++){
			for(int j = 0; j < sizeY; j++){
				Coordinates p = new Coordinates (i, j);
				if (isCulDeSac(p))
					culDeSacs.Add(p);
			}
		}

		return culDeSacs;
	}
		
	public List<List<Coordinates>> findAreas(char marker, Coordinates start, Coordinates end){

		List<List<Coordinates>> result = new List<List<Coordinates>>();

		int x = end.x - start.x;
		int y = end.y - start.y;

		bool[,] found = new bool[x, y];
		for(int i = 0; i < x; i++){
			for(int j = 0; j < y; j++){
				found [i, j] = false;
			}
		}

		for(int i = 0; i < x; i++){
			for(int j = 0; j < y; j++){
				if (grid [i + start.x, j + start.y] == marker && !found[i, j]) {
					found [i, j] = true;

					List<Coordinates> area = exploreFromPoint(new Coordinates(i + start.x, j + start.y));

					foreach(Coordinates point in area){
						found[point.x - start.x, point.y - start.y] = true;
					}
					result.Add(area);
				}
			}
		}

		return result;
	}

	public int countArea(PathableArea area){
		return area.sizeX * area.sizeY;
	}

	public int countPerimeter(PathableArea area){
		return 2 * (area.sizeX + area.sizeY);
	}

	public void paste(DungeonGrid from, Coordinates start){

		for (int i = 0; i < from.sizeX; i++){
			for (int j = 0; j < from.sizeY; j++){
				int tempX = i+start.x;
				int tempY = j+start.y;
				if(tempX < sizeX && tempY < sizeY)
					grid[tempX, tempY] = from.grid[i, j];
			}
		}

	}

	public void drawPath(Coordinates start, Coordinates end, System.Random rand){

		int distanceX = Math.Abs(start.x - end.x);
		int distanceY = Math.Abs(start.y - end.y);
		int directionX = start.x > end.x ? -1 : 0;
		directionX = start.x < end.x ? 1 : directionX;
		int directionY = start.y > end.y ? -1 : 0;
		directionY = start.y < end.y ? 1 : directionY;

		Coordinates nextStep;
		while (distanceX > 0 && distanceY > 0) {
			int rateo;
			if (distanceX > distanceY) {
				rateo = 2;
			} else if (distanceX < distanceY) {
				rateo = 0;
			} else {
				rateo = 1;
			}
			if (rand.Next() % 3 < rateo) {
				nextStep = new Coordinates(start.x + directionX, start.y);
				distanceX--;
			}
			else {
				nextStep = new Coordinates(start.x, start.y + directionY);
				distanceY--;
			}
			grid[nextStep.x, nextStep.y] = grid[start.x, start.y];
			start = nextStep;
		}
		while (distanceX > 0) {
			nextStep = new Coordinates(start.x + directionX, start.y);
			grid[nextStep.x, nextStep.y] = grid[start.x, start.y];
			start = nextStep;
			distanceX--;
		}
		while (distanceY > 0) {
			nextStep = new Coordinates(start.x, start.y + directionY);
			grid[nextStep.x, nextStep.y] = grid[start.x, start.y];
			start = nextStep;
			distanceY--;
		}
	}

	public void normalize(){
		for(int i = 0; i < sizeX; i++){
			for(int j = 0; j < sizeY; j++){
				if(grid[i, j] == Constants.PATHABLE_MARKER)
					grid[i, j] = Constants.WALL_MARKER;
				if(grid[i, j] == Constants.DEFAULT_PATH_MARKER)
					grid[i, j] = Constants.PATH_MARKER;
				if(grid[i, j] == Constants.PSEUDO_ROOM_MARKER)
					grid[i, j] = Constants.PATH_MARKER;
			}
		}
	}

	public bool hasDoorsTouching(Coordinates position){

		return(isDoor (new Coordinates (position.x - 1, position.y))
			|| isDoor (new Coordinates (position.x + 1, position.y))
			|| isDoor (new Coordinates (position.x, position.y - 1))
			|| isDoor (new Coordinates (position.x, position.y + 1)));
	}

	public bool hasForcedPathTouching(Coordinates position){

		return(isForcedPath (new Coordinates (position.x - 1, position.y))
			|| isForcedPath (new Coordinates (position.x + 1, position.y))
			|| isForcedPath (new Coordinates (position.x, position.y - 1))
			|| isForcedPath (new Coordinates (position.x, position.y + 1)));
	}

	//////////////////////////////////////////////////////////////////////////////////
	/*										|										*/
	/* 									 PRIVATES									*/
	/*										|										*/
	//////////////////////////////////////////////////////////////////////////////////

	private List<Coordinates> exploreFromPoint(Coordinates point){
		char marker = grid[point.x, point.y];
		List<Coordinates> points = new List<Coordinates>();

		recursiveExploration(marker, point, points);

		foreach(Coordinates p in points){
			grid[p.x, p.y] = marker;
		}

		return points;
	}
		
	/// <summary>
	/// NEVER call this method using Constants.TEMP_EXPLORE_MARKER ('F') as a marker
	/// </summary>
	private void recursiveExploration(char marker, Coordinates point, List<Coordinates> points){
		if (marker == Constants.TEMP_EXPLORE_MARKER)
			throw new ShittyBlindProgrammerException ("the guy who called this function can't even read function descriptions");
		if(grid[point.x, point.y] != marker) return;
		points.Add(point);
		grid[point.x, point.y] = Constants.TEMP_EXPLORE_MARKER;
		if(point.x > 0) recursiveExploration(marker, new Coordinates(point.x-1, point.y), points);
		if(point.x < sizeX-1) recursiveExploration(marker, new Coordinates(point.x+1, point.y), points);
		if(point.y > 0) recursiveExploration(marker, new Coordinates(point.x, point.y-1), points);
		if(point.y < sizeY-1) recursiveExploration(marker, new Coordinates(point.x, point.y+1), points);
	}

}