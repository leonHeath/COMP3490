using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class UserData {

	private static string userName;

	public static void setUserName(string name){
		userName = name;	
	}

	public static string getUserName(){
		return userName;
	}
}
