
public class RemoveDebuffAction : CombatAction{

	private DebuffEnum debuff;

	public RemoveDebuffAction(DebuffEnum debuff){
		this.debuff = debuff;
	}

	public DebuffEnum getDebuff(){
		return debuff;
	}

}