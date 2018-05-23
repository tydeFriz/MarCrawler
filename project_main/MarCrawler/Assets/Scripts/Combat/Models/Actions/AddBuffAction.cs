
public class AddBuffAction : CombatAction{

	private BuffEnum buff;

	public AddBuffAction(BuffEnum buff){
		this.buff = buff;
	}

	public BuffEnum getBuff(){
		return buff;
	}

}