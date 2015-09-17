using UnityEngine;
using System.Collections;
using System.Collections.Generic;

// Usage:
// Communication comm = new Communication('http://localhost:3000')
// comm.OnDone = (dictionary) => { this.room_no = data['room_no']; }
// comm.Request();

public class Communication :  SingletonMonoBehaviour<Communication> {
	MyGet method;
	string url;

	public void setUrl(string url)
	{
		this.url = url;
		//StartCoroutine (wait(url,/**/ ));
	}

	public delegate void MyGet(Dictionary<string,object> data);

	public void OnDone(MyGet method) {
		this.method = method;
	}

	public void RequestGet() {
		StartCoroutine (waitGET ());
	}
	
	public void RequestPost() {
		StartCoroutine (waitPost ());
	}

	private IEnumerator waitGET()
	{	
		WWW www = new WWW(url);
		yield return www;
		if (www.error == null) {
			Debug.Log (www.text);
			Dictionary <string,object> data = new Json_analays ().Json_Dictionary (www.text);
			method(data);
		} else {	
			Debug.Log ("Jsonanalays data nothing");
		}
	}
	//mada
	private IEnumerator waitPost()
	{	
		WWW www = new WWW(url);
		yield return www;
		if (www.error == null) {
			Debug.Log (www.text);
			Dictionary <string,object> data = new Json_analays ().Json_Dictionary (www.text);
			method(data);
		} else {	
			Debug.Log ("Jsonanalays data nothing");
		}
	}
	public void Awake()
	{
		if(this != Instance){
			Destroy(this);
			return;
		}
		DontDestroyOnLoad(this.gameObject);
	}
	// Update is called once per frame

}
