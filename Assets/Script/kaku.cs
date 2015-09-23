using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class kaku : Koma {

	
	
	public override Vector2 movePoint(long x,long y)
	{
		if(y != 9)
		{
			//(y - _y)=(x-_x)
			Debug.Log();
			return new Vector2 (x - 1,y-1);
		}
		return new Vector2 (x, y);
		
	}
	
	/*
	public void OnClick ()
	{
		if (owner != UserManager.Instance.UserData ["user_id"]) {
			return;
		}
		if (isSprActive ()) {
			SprCretate (movePoint (Posx, Posy));
		} 
		else {
			SprDelete();
		}
	}
	*/
	void Start () {
		
		Posx = 2;
		Posy = 2;
		canvas = GameObject.Find ("Canvas") as GameObject;
		Board = GameObject.Find ("Board") as GameObject;
		
		Button button = this.GetComponent <Button> ();
		button.onClick.AddListener (() => {
			Debug.Log ("Clicked.");
			GameObject obj =  Resources.Load ("Prefab/Sprsyu") as GameObject;
			GameObject Prefab = Instantiate(obj, new Vector2(0,0),
			                                Quaternion.identity) as GameObject;
			Prefab.transform.SetParent (canvas.transform);
			//kokode positon make
			Prefab.GetComponent<RectTransform>().position = canvas.transform.position;
			
			/*
			if (owner != (string)UserManager.Instance.UserData ["user_id"]) {
				return;
			}
		*/
			if (isSprActive ()) {
				SprCretate (movePoint (Posx, Posy),Prefab);
			} 
			else {
				SprDelete();
			}
		});
	}

}
