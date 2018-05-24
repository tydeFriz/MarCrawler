using System;
using System.Collections.Generic;

public class HealAction : CombatAction{

	private List<Die> damage;

	public HealAction(List<Die> damage){
		this.damage = damage;
	}

	public DamageResult getDamage(){
		
		Die supportDie = performer.getDie(StatEnum.SUPPORT);
		if (supportDie != null)
			damage.Add(supportDie);

		Die[] rolledDice = new Die[damage.Count];
		int totalDamage = 0;
		int i = 0;
		foreach (Die d in damage) {
			totalDamage += d.roll();
			rolledDice[i] = d;
			i++;
		}

		Random rand = new Random();
		bool crit = rand.Next () % 100 < performer.getStat(StatEnum.CRIT);
		if (crit)
			totalDamage = Convert.ToInt32(Constants.SUPPORT_CRIT_MULTIPLIER * totalDamage);

		//TODO: add buff/debuff/status alterations

		totalDamage = totalDamage > 0 ? totalDamage : 0;

		DamageResult result = new DamageResult(false, rolledDice, totalDamage, crit);

		return result;
	}

}

