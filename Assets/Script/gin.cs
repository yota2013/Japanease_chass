using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class gin : Koma {
	
	//SprCreate (Vector2D(Posx, Posy),Prefab);
	public override void movePoint(long x,long y)
	{
		//ue hidari
		long xy = (long)1;
		SprCreate(new Vector2(xy,xy));
		SprCreate(new Vector2(-xy,-xy));
		SprCreate(new Vector2(-xy,xy));
		SprCreate(new Vector2(xy,-xy));
		SprCreate(new Vector2(0,xy));
	
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