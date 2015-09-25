using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class fu : Koma {


	
	public override void movePoint(long x,long y)
	{
		if(y != 1)
		{
			SprCreate (new Vector2 (0,1));
		}
	}

	void Start () {	
		canvas = GameObject.Find ("Canvas") as GameObject;
		Board = GameObject.Find ("Board") as GameObject;

		Button button = this.GetComponent <Button> ();
		button.onClick.AddListener (() => {
			Debug.Log(UserManager.Instance.UserData ["user_id"].ToString());
			Debug.Log(this.owner.ToString());
			if (this.owner.ToString() != UserManager.Instance.UserData ["user_id"].ToString()) {
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
