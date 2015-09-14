using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using MiniJSON;

public class UserManager : MonoBehaviour{
	public Dictionary<string,object> User_data{get; private set;}
	public string room{ get; private set;}
	public string username{ get; private set;}
	public string url{ get; private set;}
	private URL userurl;

	// Use this for initialization
	void Awake(){
		DontDestroyOnLoad (this.gameObject);// DontDestroy gameobject
	}
	void Start () {
		userurl = new URL();
	}

	// Update is called once per frame
	void Update () {

	}
	public URL GetUserUrl()
	{
		return this.userurl;
	}
	public void User_Login(string room,string username,string url){
		this.room = room;
		this.username = username;
		this.url = url;
		this.url = "192.168.33.11:3000";
		Debug.Log (this.url);
		Debug.Log (this.username);
		Debug.Log (this.room);
		userurl.SetUrl (this.url);
		Debug.Log (userurl.login());
		StartCoroutine(Login_User_Take(this.room,this.username,userurl.login()));
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
			User_data = new Json_analays().Json_Dictionary (www.text);
			userurl.SetManager (this);
			Application.LoadLevel("gamemode");
		} else {
			Debug.Log(" data nothing");
			//debug yatu
		}
	}

}
