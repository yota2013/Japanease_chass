using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class URL  {
	//http://192.168.33.11:3000
	//public string url {get;private set};
	UserManager User_Login_data;
	public string url;

	public void SetManager(UserManager User_Login_data)
	{
	
		this.User_Login_data = User_Login_data;
	}

	public void SetUrl(string url)
	{
		this.url = url;
	
	}

	public string piece( )
	{	
		return	(User_Login_data.url + "/plays/" + User_Login_data.User_data["play_id"] + "/pieces");
	}
	public string login()
	{	
		return url+"/users/login";
	}
	public string room_state()
	{	
		return	(User_Login_data.url + "/plays/" + User_Login_data.User_data ["play_id"] + "/state");
		// /plays/対戦ID/state
	}
	public string Users()
	{	
		return	(User_Login_data.url + "/plays/" + User_Login_data.User_data ["play_id"] + "/users");
		// /plays/対戦ID/users
	}
	public string winner( )
	{	
		return	(User_Login_data.url + "/plays/" + User_Login_data.User_data ["play_id"] + "/users");
		// /plays/対戦ID/winner
	}
	public string Battle_sitation( )
	{	
		return	(User_Login_data.url + "/plays/" + User_Login_data.User_data ["play_id"]);
		// /plays/対戦ID
	}
	public string plays_update( )
	{	
		return	(User_Login_data.url + "/plays/update");
		// /plays/update
	}
	public string plays_logout( )
	{	
		return	(User_Login_data.url + "/plays/logout");
		///users/logout
	}

	
}
