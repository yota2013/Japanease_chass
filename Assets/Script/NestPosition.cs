using UnityEngine;
using System.Collections;

public class NestPostin : MonoBehaviour {

	public long Posx{ get; private set;}
	public long Posy{ get; private set;}

	public void SetKoma(long x,long y)
	{
		this.Posx = x;
		this.Posy = y;

	}

	public void OnClick()
	{
		SendMessageKoma ();
	}
	//kono kannsuu de www ni sousi idou saseru saigoni x y ni dainyuu
   void	SendMessageKoma ()
	{

	}


}
