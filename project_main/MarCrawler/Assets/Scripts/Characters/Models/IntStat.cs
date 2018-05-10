using System;

public class IntStat : Stat{

	int _base;
	double _increment;

	public IntStat(int _base, double _increment, char rank){
		this._base = _base;
		this._increment = _increment;
		this.rank = rank;
	}

	public int getByLevel(int level){
		return (_base + Convert.ToInt32(_increment * level));
	}
}

