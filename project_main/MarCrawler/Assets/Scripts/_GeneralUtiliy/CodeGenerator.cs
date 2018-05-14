using System;
using System.Linq;

public static class CodeGenerator{

	private static Random rand = new Random();

	public static string getCode(){
		const string chars = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
		return new string(Enumerable.Repeat(chars, Constants.CODES_LENGHT).Select(s => s[rand.Next(s.Length)]).ToArray());
	}

}

