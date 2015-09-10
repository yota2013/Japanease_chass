using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
public class Shougi_data : GET  {
	private UserManager User_Login_data;
	public Dictionary<string,object> Piece{ get; private set;}//<ID(key),nakami> Peiece data
	private GameObject Board;

	// Use this for initialization
	void Start () {
		//User_Login_data = GameObject.Find("UserManager").GetComponent<UserManager>();
		Board = GameObject.Find("Board");
		SetKoma ();

	}
	
	// Update is called once per frame
	void Update () 
	{


	}

	void SetKoma()
	{
		Koma_Create (2,3,"Koma/sgl01",1);

	}

	public Vector2 Screentoboard(float x,float y)
	{
		float Board_widith = Board.GetComponent<RectTransform> ().sizeDelta.x;
		float Board_high = Board.GetComponent<RectTransform> ().sizeDelta.y;
		Debug.Log (Board_widith);
		return new Vector2(-(Board_widith/10f) * (x - 1) + x, -(Board_high/10f) * (y - 1) + y);
	}

	void Koma_Create(float x,float y,string koma_path,int koma_nun)
	{
		Vector2 koma_Screen_postion = Screentoboard (x,y);
		GameObject spremty_prefab = Resources.Load ("Prefab/koma") as GameObject;
		Sprite koma_spr =Resources.Load<Sprite>(koma_path);
		Debug.Log (koma_spr);
		GameObject koma = Instantiate(spremty_prefab,new Vector2(0f,0f),Quaternion.identity) as GameObject;
		koma.GetComponent<Image>().sprite = koma_spr;
		RectTransform main_Board = GameObject.Find ("Board").GetComponent<RectTransform> ();
		koma.transform.SetParent (main_Board.transform);
		koma.GetComponent<RectTransform>().anchoredPosition = koma_Screen_postion;
	}


	void PieceGet()
	{
		Piece_take ();

	}
	private void Piece_take()
	{

		if ((Piece = Take_Json ("User_Login_data/対戦ID/pieces")) != null) {
			Debug.Log ("OK");
		} else {
			Debug.Log ("data nothing");
		}
	}

}
