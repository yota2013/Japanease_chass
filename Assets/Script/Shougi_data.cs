using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class Shougi_data : Json_analays {
	private UserManager User_Login_data;
	public Dictionary<string,object> Piece{ get; private set;}//<ID(key),nakami> Peiece data
	private List<string> koma;
	public GameObject prefab;
	private int[,] board;
	// Use this for initialization
	void Start () {
	//	User_Login_data = GameObject.Find("UserManager").GetComponent<UserManager>();
		//Koma = new List<string> ();
		SetKoma ();
		board = new int[9,9];
		for (int i = 0; i < board.GetLength(0); i++)
		{

			for (int j = 0; j < board.GetLength(1); j++)
			{
				board[i,j] = 0;
				Debug.Log(board[i,j]);
			}            
		}
	}
	
	// Update is called once per frame
	void Update () 
	{

	}
	void SetKoma()
	{
		//Koma.Add ("Assets/Resource/60x64/sgl01");
		//Debug.Log (Koma[1]);
		//GameObject prefab = Resources.Load ("/60x64/sgl01.png") as GameObject;
		Instantiate(prefab, new Vector3(1f,1f,1f),Quaternion.identity);
	}
	void PieceGet()
	{
		StartCoroutine(Piece_take());

	}
	private IEnumerator Piece_take()
	{
		string url = "http://192.168.33.11:3000/plays/対戦ID/pieces";
		WWW www = new WWW(url);
		yield return www;
		if (www.error == null) {
			Debug.Log (www.text);
			Piece = Json_Dictionary(www.text); 
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
