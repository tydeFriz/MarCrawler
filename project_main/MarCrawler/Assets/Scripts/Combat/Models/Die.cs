using System;

public class Die{

	protected int size;
	protected int[] faces;

	public Die(int size, int[] faces){
		this.faces = faces;
		this.size = size;
	}

	public int roll (Random rand){
		return faces[rand.Next() % size];
	}

}