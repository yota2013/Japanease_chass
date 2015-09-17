using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using MiniJSON;

public class UserManager : MonoBehaviour{
	public Dictionary<string,object> UserData{get; private set;}
	public Dictionary<string,object> plyerID;
	public URL userurl;

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
	public Dictionary<string,object> GetUserData()
	{
		return this.UserData;
	}

	public void SetUserData(Dictionary<string,object> data)
	{
		this.UserData = data;
	}
	public URL GetUserUrl()
	{
		return this.userurl;
	}
	
	public void SetPlyerID(Dictionary<string,object> data)
	{
		this.plyerID = data;
	}
	public Dictionary<string,object> GetplyerID()
	{
		return this.plyerID;
	}
	
}
