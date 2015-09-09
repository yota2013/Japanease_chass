using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using MiniJSON;

public class Json_analays : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	public Dictionary<string,object> Json_Dictionary(string www_take_text){
		return	MiniJSON.Json.Deserialize(www_take_text) as Dictionary<string,object>;
		//ex)string result = (string) json["result"];
		}

}
