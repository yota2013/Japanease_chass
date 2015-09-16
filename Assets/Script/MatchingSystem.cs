using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class MatchingSystem : MonoBehaviour {

	private  UserManager userdata;
	public Text plyerstate;
	private Shougi_data shougidata;
	Situation _situation = new Situation ();
	string roomstate;
	public const float INTERVAL = 5.0f;
	public float timer = INTERVAL;

	 // Json_analays json= new Json_analays();
	// Use this for initialization
	void Awake () {

		userdata = GameObject.Find("UserManager").GetComponent<UserManager>();
		shougidata= GameObject.Find("Match_Manager").GetComponent<Shougi_data>();
		//StartCoroutine (Login_User_Take(user_data.room,user_data.username,user_data.url)); 
		//AddComponent<test>();



	}

	
	void Start ()
	{
		/*
		GameObject Match_Manager = new GameObject("Matchsystem");
		Communication comm = Match_Manager.AddComponent<Communication>();
		while (true) {

			URL url_data = userdata.GetUserUrl ();
			comm.setUrl(url_data.room_state());
			comm.OnDone((Dictionary<string,object> data) => {
				roomstate = data;
			});
			comm.Request ();
			if(roomstate = "playing") break;
			yield return   new WaitForSeconds(2.0f);
		}
		*/

	}
	// Update is called once per frame
	void Update () {

		timer -= Time.deltaTime;
		if (timer <= 0)
		{
			// 任意の処理
			timer = INTERVAL;
		}

		if(_situation.roomSituation(userdata.User_data)== true)
		{
			Debug.Log("Battle START");
			plyerstate.text = "YOU:START";
			shougidata.Piece_Get();
		}
		//kokoderu-pu time

	}
	// return wating or 


//mada
	private IEnumerator Login_User_Take(string room,string username,string url)
	{
		WWWForm Form = new WWWForm ();
		Form.AddField ("name", username);
		Form.AddField ("room_no", room);
		WWW www = new WWW (url, Form);
		yield return www;
		if (www.error == null) {
			Json_analays json = new Json_analays();
		//	Dictionary<string,object> room_data =  json.Json_Dictionary (www.text);
		//	is_room = (string)room_data ["state"];
			Application.LoadLevel ("gamemode");
		} 
		Debug.Log (" deta nothing");
		//debug yatu

	}

}
