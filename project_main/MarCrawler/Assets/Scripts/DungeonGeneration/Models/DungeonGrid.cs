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

	public void put(Coordinates point, char marker){
		grid[point.x, point.y] = marker;
	}

	public bool isCulDeSac(Coordinates point){

		if (grid [point.x, point.y] != Constants.PATH_MARKER)
			return false;

		int encode = 0;
		if (point.x > 0 && grid [point.x-1, point.y] != Constants.PATH_MARKER)
			encode += 1;
		if (point.x < (sizeX-1) && grid [point.x+1, point.y] != Constants.PATH_MARKER)
			encode += 10;
		if (point.y > 0 && grid [point.x, point.y-1] != Constants.PATH_MARKER)
			encode += 100;
		if (point.y < (sizeX-1) && grid [point.x, point.y+1] != Constants.PATH_MARKER)
			encode += 1000;
		
			switch(encode){
		case 1110:
		case 1101:
		case 1011:
		case 0111:
		case 1111:
			return true;
		default:
			return false;
		}
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

		bool[,] found = new bool[end.x - start.x, end.y - start.y];
		for(int i = start.x; i < end.x; i++){
			for(int j = start.x; j < end.y; j++){
				found [i, j] = false;
			}
		}

		for(int ii = start.x; ii < end.x; ii++){
			for(int jj = start.x; jj < end.y; jj++){
				if (grid [ii, jj] == marker && !found[ii, jj]) {
					found [ii, jj] = true;
					List<Coordinates> area = exploreFromPoint(new Coordinates(ii, jj));
					foreach(Coordinates point in area){
						found[point.x, point.y] = true;
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

	public void drawPath(Coordinates start, Coordinates end, System.Random rnd){

		//TODO

	}

	public void normalize(){
		for(int i = 0; i < sizeX; i++){
			for(int j = 0; j < sizeY; j++){
				if(grid[i, j] == Constants.PATHABLE_MARKER)
					grid[i, j] = Constants.WALL_MARKER;
			}
		}
	}

	public bool hasDoorsTouching(Coordinates position){
		if(position.x > 0 && grid[position.x-1, position.y] == Constants.DOOR_MARKER) return true;
		if(position.x < (sizeX-1) && grid[position.x+1, position.y] == Constants.DOOR_MARKER) return true;
		if(position.y > 0 && grid[position.x, position.y-1] == Constants.DOOR_MARKER) return true;
		if(position.y < (sizeY-1) && grid[position.x, position.y+1] == Constants.DOOR_MARKER) return true;
		if(position.x > 0 && grid[position.x-1, position.y] == Constants.SECRET_DOOR_MARKER) return true;
		if(position.x < (sizeX-1) && grid[position.x+1, position.y] == Constants.SECRET_DOOR_MARKER) return true;
		if(position.y > 0 && grid[position.x, position.y-1] == Constants.SECRET_DOOR_MARKER) return true;
		if(position.y < (sizeY-1) && grid[position.x, position.y+1] == Constants.SECRET_DOOR_MARKER) return true;
		return false;
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