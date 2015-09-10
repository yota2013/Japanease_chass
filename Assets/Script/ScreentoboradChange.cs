using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ScreentoboradChange : MonoBehaviour {

	GameObject Board;

	void Start()
	{
		Board = GameObject.Find("Board");
	}

	public Vector2 Screentoborad(float x,float y)
	{
	  float Board_x = Board.GetComponent<RectTransform> ().sizeDelta.x;
	  float Board_y = Board.GetComponent<RectTransform> ().sizeDelta.y;
		return new Vector2((Board_x/10f) * x , (Board_y/10f) * y);
	}
}
