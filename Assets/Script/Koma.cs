using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;

public class Koma: MonoBehaviour  {
	public long Posx{ get; private set;}
	public long Posy{ get; private set;}
	public string owner{ get; private set;}
	public string num{ get; private set;}
	public bool nari{ get; private set;}
	public GameObject canvas;
	public GameObject Board;
	public GameObject komaPrefab{ get; private set;}
	private bool Click = false;

	
	public virtual void movePoint(long x,long y)
	{
			
	}

	public void SetKoma(data data)
	{
		//(long)koma["posx"],(long)koma["posy"],koma["owner"].ToString(),num,(bool)koma["promote"]
		Debug.Log ("koma"+data.koma["owner"]);
		this.Posx = (long)data.koma["posx"];
		this.Posy = (long)data.koma["posy"];
		this.num = data.num.ToString();	
		this.owner = data.koma["owner"].ToString();	
		this.nari = (bool)data.koma["promote"];
	}



	
	public void SprCreate(Vector2 Point)
	{
	
	
		GameObject sprPrefab = Resources.Load ("Prefab/AoPrefab") as GameObject;

		GameObject Prefab = Instantiate(sprPrefab,new Vector2(0,0),
		                                    Quaternion.identity) as GameObject;
		Prefab.transform.SetParent (gameObject.transform);
		Debug.Log ((Vector2)gameObject.GetComponent<RectTransform> ().position);
		Debug.Log (new ScreentoboradChange().ScreentoboardInSpr(Board));
		Debug.Log ((Vector2)gameObject.GetComponent<RectTransform> ().position+
			new ScreentoboradChange().ScreentoboardInSpr(Board));

		Prefab.GetComponent<RectTransform> ().anchoredPosition = (Vector2)gameObject.GetComponent<RectTransform> ().position;

		Prefab.GetComponent<RectTransform> ().localPosition = 
			new ScreentoboradChange().Screentoboard((long)Point.x + 1,(-(long)Point.y)+1,Board);

		if (UserPlayerID (UserManager.Instance.plyerID) == "first_player") {
			Prefab.GetComponent<SprPosition> ().Pos = new Vector2 (Posx + Point.x, Posy - Point.y);
		}
		else if (UserPlayerID (UserManager.Instance.plyerID) == "last_player") 
		{
			Prefab.GetComponent<SprPosition> ().Pos = new Vector2 (Posx - Point.x, Posy + Point.y);
		}


		Prefab.GetComponent<SprPosition> ().komaSelf = gameObject;
		Prefab.GetComponent<SprPosition> ().Komadata = this;
	}

	public string UserPlayerID(Dictionary<string,object> data)
	{
		foreach (KeyValuePair <string, object>kvp in data)
		{
			Dictionary<string,object> UserId= kvp.Value as Dictionary<string,object>;

			if(UserId["user_id"].ToString() == owner)
			{
				return kvp.Key.ToString();
			}
		}
		return "watcher";
	}


	public void SprDelete()
	{
		Debug.Log ("daleteoooooooooooooo");
		if (gameObject != null) 
		{
			foreach ( Transform n in gameObject.transform)
			{
				GameObject.Destroy(n.gameObject);
			}

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
		Debug.Log (P);
		GetComponent<RectTransform>().anchoredPosition = new ScreentoboradChange().Screentoboard((long)P.x,(long)P.y,Board);
		Posx = (long)P.x;
		Posy = (long)P.y;
		SprDelete ();
		isSprActive ();
	}
}
