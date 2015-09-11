using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class MatchingSystem : MonoBehaviour {
	private  Dictionary<string,object>data;
	public Text plyer_state;
	private Shougi_data shougi_data;
	string is_room = "waiting";
	// Use this for initialization
	void Awake () {
		data = GameObject.Find("UserManager").GetComponent<UserManager>().User_data;

		shougi_data= GameObject.Find("Match_Manager").GetComponent<Shougi_data>();
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
			shougi_data.Piece_Get();
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
		if(is_room == "waiting")
		{
			return false;
		}
		else  return true;
	}
//mada
	private IEnumerator Login_User_Take(string room,string username,string url)
	{
		WWWForm Form = new WWWForm ();
		Form.AddField ("name", username);
		Form.AddField ("room_no", room);
		WWW www = new WWW (url, Form);
		yield return www;
		if (www.error == null) {
			Dictionary<string,object> room_data = Json_Dictionary (www.text);
			is_room = (string)room_data ["state"];
			Application.LoadLevel ("gamemode");
		} else {
			Debug.Log (" deta nothing");
			//debug yatu
		}
	}
}
