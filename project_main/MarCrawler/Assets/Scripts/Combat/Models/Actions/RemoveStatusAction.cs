
public class RemoveStatusAction : CombatAction{

	private StatusEnum status;

	public RemoveStatusAction(StatusEnum status){
		this.status = status;
	}

	public StatusEnum getStatus(){
		return status;
	}
}