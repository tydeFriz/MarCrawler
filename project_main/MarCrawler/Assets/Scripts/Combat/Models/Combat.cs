
public class Combat{

	public Team team;
	public MobTeam mobs;
	public CombatStateEnum state;

	public Combat(Team team, MobTeam mobs){
		this.team = team;
		this.mobs = mobs;
		this.state = CombatStateEnum.START;
	}
}