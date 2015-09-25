using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using System;

public struct data
{
	public	Dictionary<string,object> koma;
	public string num;
}
public class Shougi_data : MonoBehaviour {

	private bool init = true;
	private UserManager Userdata;
	public Dictionary<string,object> Pieceall{ get; private set;}//<ID(key),nakami> Peiece data
	private GameObject Board;
	private string FOrL;
	// Use this for initialization

	void Start () {
		//Userdata = GameObject.Find ("UserManager").GetComponent<UserManager> ();
		Board = GameObject.Find ("Board");
	}

	public void Piece_Get()
	{
		if(init)
		{
			Piece_take ();
			init = false;
		}
		else 
		{
			komatransform();
		}
	}
	private void komatransform()
	{
		URL url= UserManager.Instance.GetUserUrl ();
		Communication.Instance.setUrl (url.piece());
		Communication.Instance.OnDone((Dictionary<string,object> data) => {
			Debug.Log (data);
			foreach (KeyValuePair <string, object>kvp in data)
			{
				Dictionary<string,object> koma = kvp.Value as Dictionary<string,object>;
				//KomaTra(koma,kvp.Key);
			}
		});
		Communication.Instance.RequestGet ();
	}

	private void Piece_take()
	{
			//GET (plyerId + "/plays/"+plyerId+"/pieces");
		URL url= UserManager.Instance.GetUserUrl ();
		Communication.Instance.setUrl (url.piece());
		Communication.Instance.OnDone((Dictionary<string,object> data) => {
			Debug.Log (data);
			foreach (KeyValuePair <string, object>kvp in data)
			{
				Dictionary<string,object> koma = kvp.Value as Dictionary<string,object>;
				KomaCreate(koma,kvp.Key);
			}
		});
		Communication.Instance.RequestGet ();

	}

	public void KomaCreate(Dictionary<string,object> koma,string num)
	{
		GameObject spremtyPrefab = Resources.Load ("Prefab/koma") as GameObject;
		GameObject canvas = GameObject.Find ("Canvas") as GameObject;

		GameObject komaPrefab = Instantiate(spremtyPrefab,new Vector2(0f,0f),
		                                    Quaternion.Euler(new Vector3( 0,0,EnemyOrAlly (koma,UserManager.Instance.GetplyerID ())))) as GameObject;

		komaPrefab.GetComponent<Image>().sprite = Resources.Load<Sprite>("Koma/"+(string)koma["name"]);
		komaPrefab.transform.SetParent (canvas.transform);
		komaPrefab.GetComponent<RectTransform>().anchoredPosition = new ScreentoboradChange().Screentoboard((long)koma["posx"],(long)koma["posy"],Board);
		Type ClassName = Type.GetType((string)koma["name"]);
		var component = komaPrefab.AddComponent(ClassName);
		Debug.Log ("Shougidata:"+koma["owner"].ToString());
		//koma setting
		data komaData = new data (); 
		komaData.koma = koma;
		komaData.num = num;
		komaPrefab.SendMessage ("SetKoma",komaData);

	}
	//kokodeenemy hanntei si kakudo kimeru

	private float EnemyOrAlly(Dictionary<string,object> koma,Dictionary<string,object> player)
	{
		Dictionary<string,object> playerLast = player["last_player"] as Dictionary<string,object>;
		Debug.Log ("koma"+koma["owner"]);
		Debug.Log ("player"+playerLast["user_id"]);
		if(playerLast["user_id"].ToString() == koma["owner"].ToString())
		{	

			return 180f;
		}
		return 0f;
	}
	//IsForwardPiece
	//player ka douka
	private bool isPlyer(Dictionary<string,object> player) {

		foreach (KeyValuePair <string, object>kvp in player)
		{
			Dictionary<string,object> PlayerId = kvp.Value as Dictionary<string,object>;
			FOrL = kvp.Key;
			if (PlayerId["user_id"].ToString() == UserManager.Instance.UserData["user_id"].ToString() ) {
				return true;
			} 
		}
		return false;
	}
}
