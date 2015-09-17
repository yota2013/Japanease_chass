using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class URL  {
	//http://192.168.33.11:3000
	//public string url {get;private set};
	public string plyerId { get; private set;}
	public string url { get; private set;}

	public void SetPlayerID(string plyerId)
	{
	
		this.plyerId = plyerId;
	}

	public void SetUrl(string url)
	{
		this.url = url;
	
	}

	public string piece( )
	{		
		Debug.Log (url + "/plays/" + plyerId+ "/pieces");
		return	(url + "/plays/" + plyerId + "/pieces");
	}
	public string login()
	{	
		return url+"/users/login";
	}
	public string room_state()
	{	
		return	(url + "/plays/" + plyerId + "/state");
		// /plays/対戦ID/state
	}
	public string users()
	{	
		return	(url + "/plays/" + plyerId + "/users");
		// /plays/対戦ID/users
	}
	public string winner( )
	{	
		return	(url + "/plays/" + plyerId + "/users");
		// /plays/対戦ID/winner
	}
	public string Battle_sitation( )
	{	
		Debug.Log (plyerId + "/plays/" + plyerId);
		return	(url + "/plays/" + plyerId);
		// /plays/対戦ID
	}
	public string plays_update( )
	{	
		return	(url+plyerId + "/plays/update");
		// /plays/update
	}
	public string plays_logout( )
	{	
		return	(url+plyerId + "/plays/logout");
		///users/logout
	}

	
}
