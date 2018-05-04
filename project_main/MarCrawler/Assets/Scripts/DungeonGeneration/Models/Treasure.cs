using System.Collections.Generic;

public class Treasure{

	public Coordinates position;
	public bool opened;
	public List<Item> items;
	public int gold;

	public Treasure(Coordinates position){
		this.opened = false;
		this.position.x = position.x;
		this.position.y = position.y;
		this.items = new List<Item>();
		this.gold = 0;
	}

	public Treasure(Coordinates position, List<Item> items, int gold){
		this.opened = false;
		this.position.x = position.x;
		this.position.y = position.y;
		this.items = items;
		this.gold = gold;
	}
}