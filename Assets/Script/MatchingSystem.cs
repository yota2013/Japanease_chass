using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class MatchingSystem : MonoBehaviour {

	private  UserManager userdata;
	private Shougi_data shougiData;
	public Text plyerstate;
	Situation _situation = new Situation ();
	string roomstate;
	private const float INTERVAL = 1.0f;
	private float timer = INTERVAL;
	private bool isConectting = true;



	
	void Start ()
	{
		userdata = GameObject.Find("UserManager").GetComponent<UserManager>();
		shougiData= GameObject.Find("Match_Manager").GetComponent<Shougi_data>();
		Communication.Instance.setUrl(userUrl().room_state());
		Communication.Instance.OnDone((Dictionary<string,object> data) => {
			roomstate = (string)data["state"];
		//	Debug.Log (userdata.GetplyerID());
		});
	}
	// Update is called once per frame
	void Update () {

		timer -= Time.deltaTime;
		if (timer <= 0)
		{

			// 任意の処理
			if(_situation.roomSituation(roomstate)== true&&isConectting ==true)
			{
				Debug.Log("Battle START");
				plyerstate.text = "ROOM:START";
				Communication.Instance.setUrl(userUrl().users());
				Communication.Instance.OnDone((Dictionary<string,object> data) => {
					userdata.SetPlyerID(data);
					Debug.Log (userdata.GetplyerID());
					shougiData.Piece_Get();
				});
				isConectting = false;
				Communication.Instance.RequestGet ();

			}else if(!(_situation.roomSituation(roomstate)))
			{	

				plyerstate.text = "ROOM:Waiting";
				Communication.Instance.RequestGet ();
			}
			timer = INTERVAL;
		}
		//kokoderu-pu time

	}
	// return wating or 
	private URL userUrl()
	{
		return userdata.userurl;
	}

}
