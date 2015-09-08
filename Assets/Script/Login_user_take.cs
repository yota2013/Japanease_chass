using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;
using MiniJSON;

public class Login_user_take : MonoBehaviour {
	string url;
	string www_take_text;
	public string user_id{ get; private set;}
	public string play_id{ get; private set;}
	public string state{ get; private set;}
	public string role{ get; private set;}

	//string Json_text;
	//public InputField Input_data;

	// Use this for initialization
	void Start () {
	
	}
	// Update is called once per frame
	void Update () {
	
	}
	public void OnClick_InputFiled(Text Input_data){
		url = Input_data.text;
		url = "http://192.168.33.11:3000/users/login";
		//Debug.Log (url);
		//Login_User_Take ();
		StartCoroutine(Login_User_Take());
	}

	private IEnumerator Login_User_Take()
	{
		Debug.Log ("OK");
		WWWForm Form = new WWWForm ();
		Form.AddField ("name","1");
		Form.AddField( "room_no", "1" );
		WWW www = new WWW(url, Form);
		yield return www;
		www_take_text = www.text;
		Json_Anlays ();
		if (www.error == null) {
			Debug.Log(www.text);
		}
	}
	private	void Json_Anlays (){
		IDictionary json_analys_text = 
		MiniJSON.Json.Deserialize(www_take_text) as IDictionary;
		user_id = json_analys_text["user_id"] as string;
		state = json_analys_text["state"] as string;
		user_id = json_analys_text["role"]as string;

	}
		

}
