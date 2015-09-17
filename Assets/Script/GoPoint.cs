using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class GoPoint : MonoBehaviour {

	public GameObject spr;
	public GameObject board;

	// Use this for initialization
	void Start () {
		GameObject spremtyPrefab = Resources.Load ("Prefab/koma") as GameObject;
		RectTransform board = GameObject.Find ("Board").GetComponent<RectTransform> ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	public void CreateSpr(int x, int y)
	{


		
		GameObject komaPrefab = Instantiate(spr,new Vector2(0f,0f),
		                                    Quaternion.Euler(new Vector3( 0,0,Quaternion.identity))) as GameObject;
		//komaPrefab.GetComponent<Image>().sprite = Resources.Load<Sprite>("Koma/"+(string)koma["name"]);
		komaPrefab.transform.SetParent (main_Board.transform);
		komaPrefab.GetComponent<RectTransform>().anchoredPosition = new ScreentoboradChange().Screentoboard((long)x,(long)y,board);
		komaPrefab.GetComponent<Koma> ().SetKoma ((long)koma["posx"],(long)koma["posy"],koma["name"].ToString(),num,(bool)koma["promote"]);
	}

}
