using UnityEngine;
using System.Collections;

public class Koma: MonoBehaviour  {
	public long Posx{ get; private set;}
	public long Posy{ get; private set;}
	public string owner{ get; private set;}
	public string num{ get; private set;}
	public bool nari{ get; private set;}

	public void SetKoma(long x,long y,string num,string owner,bool nari)
	{
		this.Posx = x;
		this.Posy = y;		
		this.num = num;		
		this.owner = owner;
		this.nari = nari;
	}

}
