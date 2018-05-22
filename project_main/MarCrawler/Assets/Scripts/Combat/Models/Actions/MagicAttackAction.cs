
public class MagicAttackAction : CombatAction{

	public short type;
	private int damage;

	public MagicAttackAction(int damage){
		this.damage = damage;
	}

	public int getDamage(){
		int finalDamage = damage;

		//TODO: calculate based on performer, target and relative alterations

		return finalDamage;
	}

}

