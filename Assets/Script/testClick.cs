using UnityEngine;
using System.Collections;
using UnityEngine.UI;


public class testClick : MonoBehaviour {

		// ositara hannnou
		void Start () {
			Button button = this.GetComponent <Button> ();
			button.onClick.AddListener (() => {
				Debug.Log ("Clicked.");
			});
		}
}
