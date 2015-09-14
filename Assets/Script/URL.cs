using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class URL  {
	//192.168.33.11:3000
	//public string url {get;private set};

	public string piece( UserManager User_Login_data)
	{	
		return	(User_Login_data.url + "/plays/" + User_Login_data.User_data ["play_id"] + "/pieces");
	}
	public string login( string url)
	{	
		return url+"/users/login";
	}
	public string room_state( UserManager User_Login_data)
	{	
		return	(User_Login_data.url + "/plays/" + User_Login_data.User_data ["play_id"] + "/state");
		// /plays/対戦ID/state
	}
	public string Users( UserManager User_Login_data)
	{	
		return	(User_Login_data.url + "/plays/" + User_Login_data.User_data ["play_id"] + "/users");
		// /plays/対戦ID/users
	}
	public string winner( UserManager User_Login_data)
	{	
		return	(User_Login_data.url + "/plays/" + User_Login_data.User_data ["play_id"] + "/users");
		// /plays/対戦ID/winner
	}
	public string Battle_sitation( UserManager User_Login_data)
	{	
		return	(User_Login_data.url + "/plays/" + User_Login_data.User_data ["play_id"]);
		// /plays/対戦ID
	}
	public string plays_update( UserManager User_Login_data)
	{	
		return	(User_Login_data.url + "/plays/update");
		// /plays/update
	}
	public string plays_logout( UserManager User_Login_data)
	{	
		return	(User_Login_data.url + "/plays/logout");
		///users/logout
	}

	
}
