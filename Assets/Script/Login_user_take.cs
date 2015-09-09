using UnityEngine;
using System.Collections;
using MiniJSON;
using System.Collections.Generic;
using UnityEngine.UI;

public class Login_user_take : MonoBehaviour {
	// Use this for initialization
	private UserManager User_Login_data;
	string room;
	string username;
	string url;
	void Start () {
		User_Login_data = GameObject.Find("UserManager").GetComponent<UserManager>();

	}

	public void OnClick_InputFiled(){
		room =(GameObject.Find("Canvas/room/room").GetComponent<Text>()).text;	
		username = (GameObject.Find("Canvas/Username/Username").GetComponent<Text>()).text;
		url = (GameObject.Find("Canvas/Link/Link").GetComponent<Text>()).text;
		User_Login_data.User_Login(room,username,url);
	}
}
