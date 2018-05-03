using System;

public static class GridDrawer{

	public static char[,] drawPath(Coordinates start, Coordinates end, char[,] grid, Random rnd){
		
		Coordinates actualPosition = new Coordinates(start);
		while(!actualPosition.Equals(end)){
			try{
				Coordinates newPosition = findNextStep(actualPosition, end, grid, rnd);
				grid[newPosition.x, newPosition.y] = '_';
				actualPosition.setByCopy(newPosition);
			}catch(CannotFindPathException e){
				return grid;
			}
		}

		return grid;
	}

	private static Coordinates findNextStep(Coordinates start, Coordinates end, char[,] grid, Random rnd){

		int directionX = end.x > start.x ? 1 : -1;
		int directionY = end.y > start.y ? 1 : -1;
		if (start.x == end.x) {
			return stepY (start, end, grid, directionY);
		}
		else if (start.y == end.y) {
			return stepX (start, end, grid, directionX);
		}
		else {
			int random = rnd.Next () % 100;
			int distanceX = (end.x - start.x) * directionX;
			int distanceY = (end.y - start.y) * directionY;

			if (distanceX < distanceY) {
				if (random > 74)
					return stepY (start, end, grid, directionY);
				else
					return stepX (start, end, grid, directionX);
			}
			else if (distanceX > distanceY) {
				if (random > 74)
					return stepX (start, end, grid, directionX);
				else
					return stepY (start, end, grid, directionY);
			}
			else {
				if (random > 49)
					return stepX (start, end, grid, directionX);
				else
					return stepY (start, end, grid, directionY);
			}

		}
	}

	private static Coordinates stepX(Coordinates start, Coordinates end, char[,] grid, int direction){
		if(grid[start.x + direction, start.y] != '.') 
			throw new CannotFindPathException();
		return new Coordinates(start.x + direction, start.y);
	}

	private static Coordinates stepY(Coordinates start, Coordinates end, char[,] grid, int direction){
		if(grid[start.x, start.y + direction] != '.') 
			throw new CannotFindPathException();
		return new Coordinates(start.x, start.y + direction);
	}

}