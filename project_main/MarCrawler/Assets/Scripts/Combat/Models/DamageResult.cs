
public class DamageResult{

	bool avoided;
	public Die[] rolledDice;
	public int[] singleDamage;
	public int damage;
	bool crit;

	public DamageResult(bool avoided, Die[] rolledDice, int[] singleDamage, int damage, bool crit){
		this.avoided = avoided;
		this.rolledDice = rolledDice;
		this.singleDamage = singleDamage;
		this.damage = damage;
		this.crit = crit;
	}

}