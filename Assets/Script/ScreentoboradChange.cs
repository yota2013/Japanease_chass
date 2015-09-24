using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ScreentoboradChange {

	public Vector2 Screentoboard(long x,long y,GameObject Board)
	{
		float Board_widith = Board.GetComponent<RectTransform> ().sizeDelta.x;
		float Board_high = Board.GetComponent<RectTransform> ().sizeDelta.y;
		return new Vector2(-(Board_widith/10f) * (x - 1), - (Board_high/10f) * (y - 1));
	}

	public Vector2 ScreentoboardInSpr(GameObject Board)
	{
		float Board_widith = Board.GetComponent<RectTransform> ().sizeDelta.x;
		float Board_high = Board.GetComponent<RectTransform> ().sizeDelta.y;
		return new Vector2(-(Board_widith/10f)/2, -(Board_high/10f)/2);
	}

}
