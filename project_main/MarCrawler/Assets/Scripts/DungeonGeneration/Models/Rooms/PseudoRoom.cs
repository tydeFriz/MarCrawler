
public class PseudoRoom{
	public Coordinates position;
	public int sizeX;
	public int sizeY;

	public PseudoRoom(Coordinates position, int sx, int sy){
		this.position.x = position.x;
		this.position.y = position.y;
		this.sizeX = sx;
		this.sizeY = sy;
	}
}