
public static class GridPaster{

	public static char[,] pasteAinB(char[,] A, char[,] B, int sizeXA, int sizeYA, int sizeXB, int sizeYB, int startX, int startY){
		
		for (int i = 0; i < sizeXA; i++){
			for (int j = 0; j < sizeYA; j++){
				int tempX = i+startX;
				int tempY = j+startY;
				if(tempX < sizeXB && tempY < sizeYB)
					B[tempX, tempY] = A[i, j];
			}
		}

		return B;
	}
}

