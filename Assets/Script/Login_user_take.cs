using UnityEngine;
using System.Collections;
using MiniJSON;
using System.Collections.Generic;
using UnityEngine.UI;

public class Login_user_take : MonoBehaviour {
	// Use this for initialization
	private UserManager UserLoginData;
	string room;
	string username;
	string url;

	void Start () {
		UserLoginData = GameObject.Find("UserManager").GetComponent<UserManager>();
	}

	public void OnClick_InputFiled(){
		room =(GameObject.Find("Canvas/room/room").GetComponent<Text>()).text;	
		username = (GameObject.Find("Canvas/Username/Username").GetComponent<Text>()).text;
		url = (GameObject.Find("Canvas/Link/Link").GetComponent<Text>()).text;
		UserLogin(room,username,url);
	}

	public void UserLogin(string room,string username,string url){
	//	url = "192.168.33.11:3000";
		//3.83
		Debug.Log (url);
		Debug.Log (username);
		Debug.Log (room);
		userUrl ().SetUrl (url);
		StartCoroutine(Login_User_Take(room,username,userUrl().login()));
	}
	private URL userUrl()
	{
		return UserLoginData.userurl;
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
			Dictionary<string,object> data = new Json_analays().Json_Dictionary(www.text);
			UserLoginData.SetUserData(data);
			userUrl().SetPlayerID(data["play_id"].ToString());
			Application.LoadLevel("gamemode");
		} else {
			Debug.Log(" data nothing");
			//debug yatu

		}
	}
}
