using System;
using System.Collections.Generic;

public class DungeonGrid{

	public int sizeX;
	public int sizeY;
	public char[,] grid;

	public DungeonGrid(int x, int y){
		this.grid = new char[x, y];
		for(int i = 0; i < x; i++){
			for(int j = 0; j < y; j++){
				this.grid[i, j] = '.';
			}
		}
	}

	public DungeonGrid(int x, int y, char[,] grid){
		this.grid = new char[x, y];
		for(int i = 0; i < x; i++){
			for(int j = 0; j < y; j++){
				this.grid[i, j] = grid[i, j];
			}
		}
	}

	public List<List<Coordinates>> findAreas(char marker){
		List<List<Coordinates>> result = new List<List<Coordinates>>();

		bool[,] found = new bool[sizeX, sizeY];
		for(int i = 0; i < sizeX; i++){
			for(int j = 0; j < sizeY; j++){
				found [i, j] = false;
			}
		}

		for(int i = 0; i < sizeX; i++){
			for(int j = 0; j < sizeY; j++){
				if (grid [i, j] == marker && !found[i, j]) {
					found [i, j] = true;
					List<Coordinates> area = exploreFromPoint(new Coordinates(i, j));
					foreach(Coordinates point in area){
						found[point.x, point.y] = true;
					}
					result.Add(area);
				}
			}
		}

		return result;
	}

	public int countArea(List<Coordinates> area){
		return area.Count;
	}

	public int countPerimeter(List<Coordinates> area){
		int count = 0;
		char previousMarker = grid[area[0].x, area[0].y];
		foreach(Coordinates point in area){
			grid [point.x - 1, point.y] = 'A';
		}
		foreach(Coordinates point in area){
			if(point.x > 0 && grid[point.x-1, point.y] != 'A') count++;
			if(point.x < sizeX && grid[point.x+1, point.y] != 'A') count++;
			if(point.y > 0 && grid[point.x, point.y-1] != 'A') count++;
			if(point.x < sizeY && grid[point.x, point.y+1] != 'A') count++;
		}
		foreach(Coordinates point in area){
			grid [point.x - 1, point.y] = previousMarker;
		}
		return count;
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

	public char[,] drawPath(Coordinates start, Coordinates end, Random rnd){

		Coordinates actualPosition = new Coordinates(start);
		while(!actualPosition.Equals(end)){
			try{
				Coordinates newPosition = findNextStep(actualPosition, end, rnd);
				grid[newPosition.x, newPosition.y] = '_';
				actualPosition.setByCopy(newPosition);
			}catch(CannotFindPathException e){
				return grid;
			}
		}

		return grid;
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
	/// NEVER call this method using 'F' as a marker
	/// </summary>
	private void recursiveExploration(char marker, Coordinates point, List<Coordinates> points){
		if (marker == 'F')
			throw new ShittyBlindProgrammerException ("the guy who called this function can't even read function descriptions");
		if(grid[point.x, point.y] != marker) return;
		points.Add(point);
		grid[point.x, point.y] = 'F';
		if(point.x > 0) recursiveExploration(marker, new Coordinates(point.x-1, point.y), points);
		if(point.x < sizeX) recursiveExploration(marker, new Coordinates(point.x+1, point.y), points);
		if(point.y > 0) recursiveExploration(marker, new Coordinates(point.x, point.y-1), points);
		if(point.x < sizeY) recursiveExploration(marker, new Coordinates(point.x, point.y+1), points);
	}

	private Coordinates findNextStep(Coordinates start, Coordinates end, Random rnd){

		int directionX = end.x > start.x ? 1 : -1;
		int directionY = end.y > start.y ? 1 : -1;
		if (start.x == end.x) {
			return stepY (start, end, directionY);
		}
		else if (start.y == end.y) {
			return stepX (start, end, directionX);
		}
		else {
			int random = rnd.Next () % 100;
			int distanceX = (end.x - start.x) * directionX;
			int distanceY = (end.y - start.y) * directionY;

			if (distanceX < distanceY) {
				if (random > 74)
					return stepY (start, end, directionY);
				else
					return stepX (start, end, directionX);
			}
			else if (distanceX > distanceY) {
				if (random > 74)
					return stepX (start, end, directionX);
				else
					return stepY (start, end, directionY);
			}
			else {
				if (random > 49)
					return stepX (start, end, directionX);
				else
					return stepY (start, end, directionY);
			}

		}
	}

	private Coordinates stepX(Coordinates start, Coordinates end, int direction){
		if(grid[start.x + direction, start.y] != '.') 
			throw new CannotFindPathException();
		return new Coordinates(start.x + direction, start.y);
	}

	private Coordinates stepY(Coordinates start, Coordinates end, int direction){
		if(grid[start.x, start.y + direction] != '.') 
			throw new CannotFindPathException();
		return new Coordinates(start.x, start.y + direction);
	}

}

