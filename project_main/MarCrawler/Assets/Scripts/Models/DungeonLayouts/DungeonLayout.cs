using System.Collections;
using System.Collections.Generic;

public abstract class DungeonLayout{
	public int sizeX;
	public int sizeY;
	public char[,] grid;
	public List<PseudoRoom> rooms;
}