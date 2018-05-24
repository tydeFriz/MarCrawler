#pragma warning disable 0162

using System;
using UnityEngine;
using System.IO;

public static class TestLogger{

	public static void log(string message){
		
		if(Constants.DEBUG_WRITE_CONSOLE)
			Debug.Log(message); //console logging

		if (Constants.DEBUG_WRITE_FILE) {
			StreamWriter sw = new StreamWriter(@"log.txt", true); //file logging
			sw.WriteLine(message);
			sw.Close();
		}
	
	}

}

