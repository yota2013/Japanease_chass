using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ScreentoboradChange {
	/*
	GameObject Board;

	void Start()
	{
		Board = GameObject.Find("Board");
	}
	*/
	public Vector2 Screentoboard(long x,long y,GameObject Board)
	{
		float Board_widith = Board.GetComponent<RectTransform> ().sizeDelta.x;
		float Board_high = Board.GetComponent<RectTransform> ().sizeDelta.y;

		return new Vector2(-(Board_widith/10f) * (x - 1) + x, - (Board_high/10f) * (y - 1) + y);
	}
}
