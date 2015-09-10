using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
public class MatchingSystem : MonoBehaviour {
	private  Dictionary<string,object>data;
	public Text plyer_state;

	// Use this for initialization
	void Awake () {
		data = GameObject.Find("UserManager").GetComponent<UserManager>().User_data;
	}
	void Start () {
		if(Game_stiation() == true)
		{
			plyer_state.text = "YOU:Waiting";
		}
		else{
			plyer_state.text = "YOU:Playing";
		}
	}
	// Update is called once per frame
	void Update () {
		if(Room_sitation()== true)
		{
			Debug.Log("Battle START");
			plyer_state.text = "YOU:START";
		}
	}
	// return wating or 
	public bool Game_stiation(){
		if ((string)data ["state"] == "waiting") {
			Debug.Log ("MatchingSystem" + data ["state"]+"Matching OK"+"Game Start");
			return true;
		}
		Debug.Log("MatchingSystem" + "ERROR");
		return false; 
	}
	// return Dctionary
	public bool battle_sitation(){
		if ((string)data ["role"] == "player") {
			Debug.Log ("MatchingSystem" + data ["role"]+"Player");
			return true;
		}
		Debug.Log("MatchingSystem" + "watcher");
		return false; 
	}
	public bool Room_sitation()
	{
		if((string)data["role"]== "waiting")
		{
			return true;
		}
		else  return false;
	}

}
