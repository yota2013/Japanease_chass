using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
public class Shougi_data : MonoBehaviour {
	private UserManager UserLogindata;
	public Dictionary<string,object> Pieceall{ get; private set;}//<ID(key),nakami> Peiece data
	private GameObject Board;

	// Use this for initialization
	void Start () {
		UserLogindata = GameObject.Find ("UserManager").GetComponent<UserManager> ();
		Board = GameObject.Find ("Board");
	}
	
	public void Piece_Get()
	{
		Piece_take ();

	}
	private void Piece_take()
	{
			//GET (User_Login_data.url + "/plays/"+User_Login_data.User_data ["play_id"]+"/pieces");
		URL url= UserLogindata.GetUserUrl ();
		StartCoroutine (POST (url.piece() ));
	}

	private IEnumerator POST(string url)
	{
		WWW www = new WWW(url);
		yield return www;
		if (www.error == null) {
			Debug.Log ("Pieces"+www.text);
			Pieceall = new Json_analays().Json_Dictionary(www.text);
			Debug.Log (Pieceall);
	  		Dictionary<string,object> Piece = Pieceall["1"] as Dictionary<string,object>;
			Debug.Log (Pieceall);
			new CreateKoma().Koma_Create ( (float)Piece["posx"],(float)Piece["posy"],"Koma/sgl01",1);
			//Koma_Create (2,3,"Koma/sgl01",1);
		} else {	
			Debug.Log ("Jsonanalays data nothing");
		}

	}
}
