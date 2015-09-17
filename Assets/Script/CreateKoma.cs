using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using MiniJSON;
	
public class CreateKoma : MonoBehaviour {
	/*
	public void KomaCreate(long x,long y,string name,string owner)
	{
		Vector3  Koma_angle  = new Vector3( 0,0,EnemyOrAlly (owner));
		Vector2 koma_Screen_postion = new ScreentoboradChange().Screentoboard(x,y);
		GameObject spremty_prefab = Resources.Load ("Prefab/koma") as GameObject;
		Sprite koma_spr =Resources.Load<Sprite>("Koma/"+name);
		Debug.Log ("Shougi_data"+koma_spr);
		GameObject koma = Instantiate(spremty_prefab,new Vector2(0f,0f),Quaternion.Euler(Koma_angle)) as GameObject;
		koma.GetComponent<Image>().sprite = koma_spr;
		RectTransform main_Board = GameObject.Find ("Board").GetComponent<RectTransform> ();
		koma.transform.SetParent (main_Board.transform);
		koma.GetComponent<RectTransform>().anchoredPosition = koma_Screen_postion;
	}
	//kokodeenemy hanntei si kakudo kimeru
	private float EnemyOrAlly(string owner)
	{
		if(owner == "2")
		{
			return 180f;
		}
		return 0f;
	}
	*/
}
