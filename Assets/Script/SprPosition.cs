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
		Debug.Log (komaData.sprSyuObject);
		Debug.Log (komaSelf.GetComponent <Koma> ().sprSyuObject);
		//koredesprSyu wo keseru
		komaData.KomaSprMove(Pos);

	}

}