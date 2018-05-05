using System;
using UnityEngine;
using System.IO;

public static class TestLogger{

	public static void log(string message){
		
		Debug.Log(message); //console logging

		StreamWriter sw = new StreamWriter(@"log.txt", true); //file logging
		sw.WriteLine(message);
		sw.Close();
	}

}

