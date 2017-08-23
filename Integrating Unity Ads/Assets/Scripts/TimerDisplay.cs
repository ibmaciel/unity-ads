using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimerDisplay : MonoBehaviour {

	Text text;

	void Start () {
		text = GetComponent<Text> ();
	}

	void Update () {
		text.text = ((int)Time.time).ToString ();
	}
}
