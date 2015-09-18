using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Koma: MonoBehaviour  {
	public long Posx{ get; private set;}
	public long Posy{ get; private set;}
	public string owner{ get; private set;}
	public string num{ get; private set;}
	public bool nari{ get; private set;}
	public GameObject canvas;
	public GameObject Board;
	public GameObject komaPrefab{ get; private set;}
	public GameObject SprObject{ get; private set;}
	private bool Click = false;

	public virtual Vector2 movePoint(long x,long y)
	{

			return new Vector2(x,y);
	}
	

	public void SetKoma(long x,long y,string num,string owner,bool nari)
	{
		this.Posx = x;
		this.Posy = y;
		this.num = num;		
		this.owner = owner;
		this.nari = nari;
	}

	public void SprCretate(Vector2 Point)
	{

		canvas = GameObject.Find ("Canvas") as GameObject;
		Board = GameObject.Find ("Board") as GameObject;
		GameObject	sprPrefab = Resources.Load ("Prefab/AoPrefab") as GameObject;
		GameObject komaPrefab = Instantiate(sprPrefab,new Vector2(0f,0f),
		                                    Quaternion.identity) as GameObject;
		komaPrefab.transform.SetParent (canvas.transform);
		komaPrefab.GetComponent<RectTransform>().anchoredPosition = new ScreentoboradChange().Screentoboard((long)Point.x,(long)Point.y,Board);
	}
	public void SprDelete()
	{
		if (SprObject != null) 
		{
			Destroy(SprObject);
		}
	}
	public bool isSprActive()
	{
		if (Click) {
			Click = false;
		}
		else if (Click == false) 
		{
			Click = true;
		}
		return Click;
	}
}
