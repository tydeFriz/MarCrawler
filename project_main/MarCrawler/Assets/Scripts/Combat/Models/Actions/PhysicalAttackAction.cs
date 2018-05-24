using System;
using System.Collections.Generic;

public class PhysicalAttackAction : CombatAction{

	public PhysicalAttackTypesEnum type;
	private List<Die> damage;

	public PhysicalAttackAction(Die[] damage, PhysicalAttackTypesEnum type){
		this.damage = new List<Die>();
		foreach(Die d in damage){
			this.damage.Add(d);
		}
		this.type = type;
	}

	public DamageResult getDamage(){

		Random rand = new Random();

		bool avoided = rand.Next () % 100 < target.getStat(StatEnum.AVOIDANCE);

		Die strengthDie = performer.getDie(StatEnum.ATTACK);
		if (strengthDie != null)
			damage.Add(strengthDie);
		int resistance = target.getStat(TypeToResistanceTranslator.translate(type));

		Die[] rolledDice = new Die[damage.Count];
		int totalDamage = 0;
		int i = 0;
		foreach (Die d in damage) {
			totalDamage += d.roll();
			rolledDice[i] = d;
			i++;
		}

		bool crit = rand.Next () % 100 < performer.getStat(StatEnum.CRIT);
		if (crit)
			totalDamage = Convert.ToInt32(Constants.PHYSICAL_CRIT_MULTIPLIER * totalDamage);

		totalDamage -= resistance;
		//TODO: add buff/debuff/status alterations

		totalDamage = totalDamage > 0 ? totalDamage : 0;

		DamageResult result = new DamageResult(avoided, rolledDice, totalDamage, crit);

		return result;
	}

}

