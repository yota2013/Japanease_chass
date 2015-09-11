using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
public class Shougi_data : MonoBehaviour {
	private UserManager User_Login_data;
	public Dictionary<string,object> Pieceall{ get; private set;}//<ID(key),nakami> Peiece data
	private GameObject Board;

	// Use this for initialization
	void Start () {
		User_Login_data = GameObject.Find ("UserManager").GetComponent<UserManager> ();
		Board = GameObject.Find ("Board");
	}
	
	// Update is called once per frame
	void Update () 
	{


	}


	public Vector2 Screentoboard(float x,float y)
	{
		float Board_widith = Board.GetComponent<RectTransform> ().sizeDelta.x;
		float Board_high = Board.GetComponent<RectTransform> ().sizeDelta.y;
		Debug.Log (Board_widith);
		return new Vector2(-(Board_widith/10f) * (x - 1) + x, - (Board_high/10f) * (y - 1) + y);
	}

	void Koma_Create(float x,float y,string koma_path,int koma_nun)
	{
		Vector2 koma_Screen_postion = Screentoboard (x,y);
		GameObject spremty_prefab = Resources.Load ("Prefab/koma") as GameObject;
		Sprite koma_spr =Resources.Load<Sprite>(koma_path);
		Debug.Log ("Shougi_data"+koma_spr);
		GameObject koma = Instantiate(spremty_prefab,new Vector2(0f,0f),Quaternion.identity) as GameObject;
		koma.GetComponent<Image>().sprite = koma_spr;
		RectTransform main_Board = GameObject.Find ("Board").GetComponent<RectTransform> ();
		koma.transform.SetParent (main_Board.transform);
		koma.GetComponent<RectTransform>().anchoredPosition = koma_Screen_postion;
	}


	public void Piece_Get()
	{
		Piece_take ();
	}
	private void Piece_take()
	{
		StartCoroutine (GET (User_Login_data.url + "/plays/"+User_Login_data.User_data ["play_id"]+"/pieces"));
	}
	private IEnumerator GET(string url)
	{
		WWW www = new WWW(url);
		yield return www;
		if (www.error == null) {
			Debug.Log ("Pieces"+www.text);
			Pieceall =Json_Dictionary(www.text);
			Debug.Log (Pieceall);
	  		Dictionary<string,object> Piece = Pieceall["1"] as Dictionary<string,object>;
			Debug.Log (Pieceall);
			Koma_Create ( (float)Piece["posx"],(float)Piece["posy"],"Koma/sgl01",1);
			//Koma_Create (2,3,"Koma/sgl01",1);
		} else {	
			Debug.Log ("Jsonanalays data nothing");
		}

	}

}
