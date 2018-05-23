
public class AddStatusAction : CombatAction{

	private StatusEnum status;

	public AddStatusAction(StatusEnum status){
		this.status = status;
	}

	public StatusEnum getStatus(){
		return status;
	}
}