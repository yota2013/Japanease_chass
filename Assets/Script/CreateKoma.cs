using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class CreateKoma : MonoBehaviour {

	public void Koma_Create(float x,float y,string koma_path,int koma_nun)
	{
		Vector2 koma_Screen_postion = new ScreentoboradChange().Screentoboard(x,y);
		GameObject spremty_prefab = Resources.Load ("Prefab/koma") as GameObject;
		Sprite koma_spr =Resources.Load<Sprite>(koma_path);
		Debug.Log ("Shougi_data"+koma_spr);
		GameObject koma = Instantiate(spremty_prefab,new Vector2(0f,0f),Quaternion.identity) as GameObject;
		koma.GetComponent<Image>().sprite = koma_spr;
		RectTransform main_Board = GameObject.Find ("Board").GetComponent<RectTransform> ();
		koma.transform.SetParent (main_Board.transform);
		koma.GetComponent<RectTransform>().anchoredPosition = koma_Screen_postion;
	}

}
