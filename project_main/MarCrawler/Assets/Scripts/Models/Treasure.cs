using System.Collections.Generic;

public class Treasure{

	int posX;
	int posY;
	bool opened;
	List<Item> items;
	int gold;

	public Treasure(int x, int y, List<Item> items, int gold){
		this.posX = x;
		this.posY = y;
		this.items = items;
		this.gold = gold;
	}
}