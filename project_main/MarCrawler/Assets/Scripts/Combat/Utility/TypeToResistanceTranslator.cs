
public static class TypeToResistanceTranslator{

	public static StatEnum translate(PhysicalAttackTypesEnum type){
		switch(type){
		case PhysicalAttackTypesEnum.SLASH:
			return StatEnum.SLASH_RES;
		case PhysicalAttackTypesEnum.BASH:
			return StatEnum.BASH_RES;
		case PhysicalAttackTypesEnum.PIERCE:
			return StatEnum.PIERCE_RES;
		default:
			throw new InvalidStatException("not a physical attack type. code: "+type);	
		}
	}

	public static StatEnum translate(MagicAttackTypesEnum type){
		switch(type){
		case MagicAttackTypesEnum.FIRE:
			return StatEnum.FIRE_RES;
		case MagicAttackTypesEnum.ICE:
			return StatEnum.ICE_RES;
		case MagicAttackTypesEnum.THUNDER:
			return StatEnum.THUNDER_RES;
		default:
			throw new InvalidStatException("not a magical attack type. code: "+type);	
		}
	}

}

