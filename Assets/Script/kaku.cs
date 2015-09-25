using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class kaku : Koma {

	
	//SprCreate (Vector2D(Posx, Posy),Prefab);
	public override void movePoint(long x,long y)
	{
		//ue hidari
		for(int i = 1; (i + Posx) <= 9 &&(-i+Posy) > 0;i++)
		{
			SprCreate(new Vector2(i,i));
		}

		for(int i = 1; (-i + Posx) > 0 &&(i+Posy) <= 9;i++)
		{
			SprCreate(new Vector2(-i,-i));
		}
		for(int i = 1; (i + Posx) <= 9 &&(i+Posy) <= 9;i++)
		{
			SprCreate(new Vector2(i,-i));
		}
		for(int i = 1; (-i + Posx) > 0 &&(-i+Posy) > 0;i++)
		{
			SprCreate(new Vector2(-i,i));
		}
	}
	/*
	public void OnClick ()
	{
		if (owner != UserManager.Instance.UserData ["user_id"]) {
			return;
		}
		if (isSprActive ()) {
			SprCreate (movePoint (Posx, Posy));
		} 
		else {
			SprDelete();
		}
	}
	*/
	void moveKoma()
	{

	}

	void Start () {

		/*----------------------------------------------------------------*/
		canvas = GameObject.Find ("Canvas") as GameObject;
		Board = GameObject.Find ("Board") as GameObject;
	
		Button button = this.GetComponent <Button> ();
		button.onClick.AddListener (() => {
			Debug.Log ("Clicked.");

			if (owner != UserManager.Instance.UserData ["user_id"].ToString()) {
				return;
			}


			if (isSprActive ()) {
				movePoint (Posx, Posy);
			} 
			else {
				SprDelete();
		
			}
		});
	}

}
