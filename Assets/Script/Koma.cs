using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Koma: MonoBehaviour  {
	public long Posx;//{ get; private set;}
	public long Posy;//{ get; private set;}
	public string owner{ get; private set;}
	public string num{ get; private set;}
	public bool nari{ get; private set;}
	public GameObject canvas;
	public GameObject Board;
	public GameObject komaPrefab{ get; private set;}
	//public GameObject SprObject{ get; private set;}
	public GameObject sprSyuObject;
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
	
	public void SprCretate(Vector2 Point,GameObject obj)
	{
	
		this.sprSyuObject = obj;
	
		GameObject sprPrefab = Resources.Load ("Prefab/AoPrefab") as GameObject;
		GameObject Prefab = Instantiate(sprPrefab,new Vector2(0,0),
		                                    Quaternion.identity) as GameObject;
		Prefab.transform.SetParent (obj.transform);
		Prefab.GetComponent<RectTransform>().anchoredPosition = new ScreentoboradChange().Screentoboard((long)Point.x,(long)Point.y,Board);
		Prefab.GetComponent<SprPosition> ().Pos = Point;
		Prefab.GetComponent<SprPosition> ().komaSelf = gameObject;
		Prefab.GetComponent<SprPosition> ().Komadata = this;
	}

	public void SprDelete()
	{
		Debug.Log (sprSyuObject);
		if (sprSyuObject != null) 
		{
			Destroy(sprSyuObject);
			sprSyuObject = null;
		}

	}

	public bool isSprActive()
	{
		if (Click)
		{
			Click = false;
		}
		else if (Click == false) 
		{
			Click = true;
		}
		return Click;
	}

	//kokomove
	public void KomaSprMove(Vector2 P)
	{
		//Vector2 pos = GetComponent<RectTransform>().anchoredPosition;
		//pos = P;
		Debug.Log (P);
		GetComponent<RectTransform>().anchoredPosition = new ScreentoboradChange().Screentoboard((long)P.x,(long)P.y,Board);
		Posx = (long)P.x;
		Posy = (long)P.y;
		SprDelete ();
	}
}
