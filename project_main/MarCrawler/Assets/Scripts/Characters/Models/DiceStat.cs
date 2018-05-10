
public class DiceStat : Stat{

	private Die[] definition = new Die[Constants.MAX_LEVEL];

	public DiceStat(Die[] definition, char rank){
		this.definition = definition;
		this.rank = rank;
	}

	public Die getByLevel(int level){
		return definition[level];
	}
}

