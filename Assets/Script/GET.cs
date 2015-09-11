using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class GET : MonoBehaviour{

	bool isDone  =false;

	public  Dictionary <string,object> : (string url)
	{
		WWW www = new WWW(url);
			StartCoroutine (wait(www));
		while(!isDone)
		{
			if(isDone)  return Json_Dictionary(www.text); 
		}
		return null;
	}
	private IEnumerator wait(WWW www)
	{
		yield return www;


		if (www.error == null) {
			Debug.Log (www.text);
		} else {	
			Debug.Log ("Jsonanalays data nothing");
				}
		isDone = true;
	}
	// Update is called once per frame

}
