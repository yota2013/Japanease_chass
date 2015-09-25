using UnityEngine;
using System.Collections;
using UnityEngine.UI;
//hisha scirpt

public class kyosha : Koma {
	public override void movePoint(long x,long y)
	{
		//ue hidari
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
