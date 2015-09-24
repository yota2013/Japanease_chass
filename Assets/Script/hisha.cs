using UnityEngine;
using System.Collections;
using UnityEngine.UI;
//hisha scirpt

public class hisha : Koma {
	public override void movePoint(long x,long y)
	{
		//ue hidari
		for(int i = 1; (i + Posx) <= 9;i++)
		{
			SprCreate(new Vector2(i,0));
		}
		
		for(int i = 1; (-i + Posx) > 0;i++)
		{
			SprCreate(new Vector2(-i,0));
		}
		for(int i = 1; (i+Posy) <= 9;i++)
		{
			SprCreate(new Vector2(0,-i));
		}
		for(int i = 1; (-i+Posy) > 0;i++)
		{
			SprCreate(new Vector2(0,i));
		}
	}

	
	void Start () {

		/*----------------------------------------------------------------*/
		canvas = GameObject.Find ("Canvas") as GameObject;
		Board = GameObject.Find ("Board") as GameObject;
		
		Button button = this.GetComponent <Button> ();
		button.onClick.AddListener (() => {
			Debug.Log ("Clicked.");

			if (owner != (string)UserManager.Instance.UserData ["user_id"]) {
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
