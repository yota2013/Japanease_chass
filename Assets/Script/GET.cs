using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class GET : Json_analays{


	public  Dictionary <string,object> Take_Json(string url)
	{
		WWW www = new WWW(url);
		StartCoroutine (wait(www));
		if (www.error == null) {
			Debug.Log (www.text);
			return Json_Dictionary(www.text); 
		} else {
			Debug.Log ("Jsonanalays data nothing");
			return null;
		}
	}
	private IEnumerator wait(WWW www)
	{
		yield return www;
	}
	// Update is called once per frame

}
