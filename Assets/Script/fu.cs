using UnityEngine;
using System.Collections;

public class fu : Koma {


	
	public override Vector2 movePoint(long x,long y)
	{
		if(y != 9)
		{
			return new Vector2(x,y);
		}
		return new Vector2 (x,y+1);

	}
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

}
