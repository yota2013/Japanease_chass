﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Situation{

	public bool Game_stiation( Dictionary<string,object> data){

		if ((string)data ["state"] == "waiting") {
			Debug.Log ("MatchingSystem" + data ["state"]+"Matching OK"+"Game Start");
			return true;
		}
		Debug.Log("MatchingSystem" + "ERROR");
		return false; 
	}


	public bool battleSituation(Dictionary<string,object> data){
		if ((string)data ["role"] == "player") {
			Debug.Log ("MatchingSystem" + data ["role"]+"Player");
			return true;
		}
		Debug.Log("MatchingSystem" + "watcher");
		return false; 
	}

	public bool roomSituation(string room_data)
	{
		Debug.Log (room_data);
		if (room_data == null) 
		{
			return false;
		}
		if((string)room_data == "waiting")
		{
			return false;
		}
		else  return true;
	}
}
