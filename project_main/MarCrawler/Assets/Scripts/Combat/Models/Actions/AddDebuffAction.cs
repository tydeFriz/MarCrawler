
public class AddDebuffAction : CombatAction{

	private DebuffEnum debuff;

	public AddDebuffAction(DebuffEnum debuff){
		this.debuff = debuff;
	}

	public DebuffEnum getDebuff(){
		return debuff;
	}
		
}