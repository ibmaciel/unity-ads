using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Advertisements;

public class SimpleAds : MonoBehaviour {
	
	void Start () {
		Advertisement.Initialize ("1521150", true);

		StartCoroutine (ShowAdWhenReady ());
	}

	IEnumerator ShowAdWhenReady () {
		while (!Advertisement.IsReady ())
			yield return null;

		Advertisement.Show ();
	}
}
