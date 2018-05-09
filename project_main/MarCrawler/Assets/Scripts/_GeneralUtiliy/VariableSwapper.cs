
public static class VariableSwapper{

	public static void Swap<T> (ref T lhs, ref T rhs) {
		T temp = lhs;
		lhs = rhs;
		rhs = temp;
	}
}
