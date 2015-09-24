using UnityEngine;
using System.Collections;

public class SprPosition : MonoBehaviour {

	public Vector2 pos;
 	public GameObject komaSelf;
	public Koma komaData;

	public Vector2 Pos
	{
		set{this.pos = value;}
		get{return this.pos;}
	}

	public GameObject KomaSelf
	{
		set{this.komaSelf = value;}
		get{return this.komaSelf;}
	}

	public Koma Komadata
	{
		set{this.komaData = value;}
		get{return this.komaData;}
	}

	public void OnSprClick()
	{
	
		//koredesprSyu wo keseru
		komaData.KomaSprMove(Pos);

	}
	private void OnTriggerStay2D(Collider2D other)
	{	
	//	Debug.Log (other.GetComponent<Koma>().owner);
		if(other.tag =="koma"&&other.GetComponent<Koma>().owner == "a")
		{
			Debug.Log("uyoooooooooooo");
			Destroy(gameObject);
		}
	}

}