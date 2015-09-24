using UnityEngine;
using System.Collections;
using UnityEngine.UI;

//keima script

public class keima : Koma {

	//SprCreate (Vector2D(Posx, Posy),Prefab);
	public override void movePoint(long x,long y)
	{
		long Y = (long)2;
		long X = (long)1;
		//ue hidari
		if(Posy - Y > 0)
		{
			SprCreate(new Vector2(X,Y));
			SprCreate(new Vector2(-X,Y));
		}

	}



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
