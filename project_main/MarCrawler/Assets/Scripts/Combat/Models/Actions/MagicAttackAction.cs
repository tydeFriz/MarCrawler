using System;
using System.Collections.Generic;

public class MagicAttackAction : CombatAction{

	public MagicAttackTypesEnum type;
	private List<Die> damage;

	public MagicAttackAction(List<Die> damage, MagicAttackTypesEnum type){
		this.damage = damage;
		this.type = type;
	}

	public DamageResult getDamage(){

		Random rand = new Random();

		bool avoided = rand.Next () % 100 < target.getStat(StatEnum.AVOIDANCE);

		Die magicDie = performer.getDie(StatEnum.MAGIC);
		if (magicDie != null)
			damage.Add(magicDie);
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
			totalDamage = Convert.ToInt32(Constants.MAGIC_CRIT_MULTIPLIER * totalDamage);

		totalDamage -= resistance;
		//TODO: add buff/debuff/status alterations

		totalDamage = totalDamage > 0 ? totalDamage : 0;

		DamageResult result = new DamageResult(avoided, rolledDice, totalDamage, crit);

		return result;
	}

}

