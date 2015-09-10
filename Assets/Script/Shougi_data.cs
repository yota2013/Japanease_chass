using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
public class Shougi_data : GET  {
	private UserManager User_Login_data;
	public Dictionary<string,object> Piece{ get; private set;}//<ID(key),nakami> Peiece data
	//private List<string> koma;
	//public GameObject prefab;
	// Use this for initialization
	void Start () {
		//User_Login_data = GameObject.Find("UserManager").GetComponent<UserManager>();
	//	koma = new List<string> ();
		SetKoma (0,0,"Koma/sgl02",1);

	}
	
	// Update is called once per frame
	void Update () 
	{

	}

	void SetKoma(int x,int y,string koma_path,int koma_nun)
	{
		GameObject spremty_prefab = Resources.Load ("Prefab/koma") as GameObject;
		Sprite koma_spr =Resources.Load<Sprite>(koma_path);
		Debug.Log (koma_spr);
		GameObject koma = Instantiate(spremty_prefab,new Vector3(x,y,0),Quaternion.identity) as GameObject;
		koma.GetComponent<Image>().sprite = koma_spr;
		RectTransform main_Board = GameObject.Find ("Board").GetComponent<RectTransform> ();
		koma.transform.SetParent (main_Board.transform);
		koma.GetComponent<RectTransform>().anchoredPosition = Vector2.zero;


	}

	void PieceGet()
	{
		Piece_take ();

	}
	private void Piece_take()
	{
		if ((Piece = Take_Json ("http://192.168.33.11:3000/plays/対戦ID/pieces")) != null) {

			Debug.Log ("OK");
		} else {
			Debug.Log ("data nothing");
		}
	}
	void init_postion(){
		//foreach ( int i in Piece.Keys[][][])
		//
		//switch(変数)
	//	{case :
		// break;
	//	}
	}

}
