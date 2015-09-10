using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using MiniJSON;

public class UserManager : Json_analays {
	public Dictionary<string,object> User_data{get; private set;}
	private string room;
	private string username;
	private string url;
	/*
	public string user_id{ get; private set;}
	public string play_id{ get; private set;}
	public string state{ get; private set;}
	public string role{ get; private set;} 
	*/
	// Use this for initialization
	void Awake(){
		DontDestroyOnLoad (this.gameObject);// DontDestroy gameobject
	}
	void Start () {
	}

	// Update is called once per frame
	void Update () {

	}
	public void User_Login(string room,string username,string url){
		this.room = room;
		this.username = username;
		this.url = url +"/users/login";
		//url = "http://192.168.33.11:3000/users/login";
		Debug.Log (url);
		Debug.Log (username);
		Debug.Log (room);
		//Login_User_Take ();
		StartCoroutine(Login_User_Take(room,username,url));
	}

	private IEnumerator Login_User_Take(string room,string username,string url)
	{
		WWWForm Form = new WWWForm ();
		Form.AddField ("name",username);
		Form.AddField( "room_no",room);
		WWW www = new WWW(url, Form);
		yield return www;
		if (www.error == null) {
			Debug.Log ("UserManager"+www.text);
			User_data = Json_Dictionary (www.text);
			Application.LoadLevel("gamemode");
		} else {
			Debug.Log(" deta nothing");
			//debug yatu
		}
	}

}
