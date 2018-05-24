
public class DamageResult{

	bool avoided;
	public Die[] rolledDice;
	public int damage;
	bool crit;

	public DamageResult(bool avoided, Die[] rolledDice, int damage, bool crit){
		this.avoided = avoided;
		this.rolledDice = rolledDice;
		this.damage = damage;
		this.crit = crit;
	}

}