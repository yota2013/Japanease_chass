using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class oh : Koma {

	//SprCreate (Vector2D(Posx, Posy),Prefab);
	public override void movePoint(long x,long y)
	{
		//ue hidari
		long xy = (long)1;
		SprCreate(new Vector2(xy,xy));
		SprCreate(new Vector2(-xy,-xy));
		SprCreate(new Vector2(-xy,xy));
		SprCreate(new Vector2(xy,-xy));
		SprCreate(new Vector2(xy,0));
		SprCreate(new Vector2(-xy,0));
		SprCreate(new Vector2(0,xy));
		SprCreate(new Vector2(0,-xy));
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
