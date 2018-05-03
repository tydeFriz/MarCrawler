
public static class GridPaster{

	public static char[,] pasteAinB(char[,] A, char[,] B, int sizeXA, int sizeYA, int sizeXB, int sizeYB, Coordinates start){
		
		for (int i = 0; i < sizeXA; i++){
			for (int j = 0; j < sizeYA; j++){
				int tempX = i+start.x;
				int tempY = j+start.y;
				if(tempX < sizeXB && tempY < sizeYB)
					B[tempX, tempY] = A[i, j];
			}
		}

		return B;
	}
}

