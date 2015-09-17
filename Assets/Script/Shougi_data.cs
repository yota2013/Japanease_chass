using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class Shougi_data : MonoBehaviour {
	private UserManager Userdata;
	public Dictionary<string,object> Pieceall{ get; private set;}//<ID(key),nakami> Peiece data
	private GameObject Board;
	private string FOrL;
	// Use this for initialization
	void Start () {
		Userdata = GameObject.Find ("UserManager").GetComponent<UserManager> ();
		Board = GameObject.Find ("Board");
	}
	
	public void Piece_Get()
	{
		Piece_take ();

	}
	private void Piece_take()
	{
			//GET (plyerId + "/plays/"+plyerId+"/pieces");
		URL url= Userdata.GetUserUrl ();
		//StartCoroutine (Get (url.piece() ));
	/*Communication.Instance.setUrl(userUrl().room_state());
		Communication.Instance.OnDone((Dictionary<string,object> data) => {
			roomstate = (string)data["state"];
			Debug.Log (userdata.GetplyerID());
		});
		*/
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
/*
	private IEnumerator Get(string url)
	{
		WWW www = new WWW(url);
		yield return www;
		if (www.error == null) {
			Debug.Log ("Pieces"+www.text);
			Pieceall = new Json_analays().Json_Dictionary(www.text);
			Debug.Log (Pieceall);
			foreach (KeyValuePair <string, object>kvp in Pieceall)
			{
				Dictionary<string,object> koma = kvp.Value as Dictionary<string,object>;
				KomaCreate(koma,kvp.Key);
			}
		} else {	
			Debug.Log ("Jsonanalays data nothing");
		}

	}
*/
	public void KomaCreate(Dictionary<string,object> koma,string num)
	{
		if (isPlyer (Userdata.GetplyerID ())) 
		{


		}
		GameObject spremtyPrefab = Resources.Load ("Prefab/koma") as GameObject;
		RectTransform main_Board = GameObject.Find ("Board").GetComponent<RectTransform> ();

		GameObject komaPrefab = Instantiate(spremtyPrefab,new Vector2(0f,0f),
		                                    Quaternion.Euler(new Vector3( 0,0,EnemyOrAlly (koma,Userdata.GetplyerID ())))) as GameObject;
		komaPrefab.GetComponent<Image>().sprite = Resources.Load<Sprite>("Koma/"+(string)koma["name"]);
		komaPrefab.transform.SetParent (main_Board.transform);
		komaPrefab.GetComponent<RectTransform>().anchoredPosition = new ScreentoboradChange().Screentoboard((long)koma["posx"],(long)koma["posy"],Board);
		komaPrefab.GetComponent<Koma> ().SetKoma ((long)koma["posx"],(long)koma["posy"],koma["name"].ToString(),num,(bool)koma["promote"]);
	}
	//kokodeenemy hanntei si kakudo kimeru

	private float EnemyOrAlly(Dictionary<string,object> koma,Dictionary<string,object> player)
	{
		Dictionary<string,object> playerLast = player["last_player"] as Dictionary<string,object>;
		Debug.Log ("koma"+koma["owner"]);
		Debug.Log ("player"+playerLast["user_id"]);
		if(playerLast["user_id"].ToString() == koma["owner"].ToString())
		{	
			Debug.Log ("weeeeeeeeeeeeeeeeeeeeeeeee");
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
			if (PlayerId["user_id"].ToString() == Userdata.UserData["user_id"].ToString() ) {
				return true;
			} 
		}
		return false;
	}
}
