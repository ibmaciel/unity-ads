using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Advertisements;
using UnityEngine.SceneManagement;

public class AdManager : MonoBehaviour {

	[SerializeField]
	string gameID = "1521150";
	[SerializeField]
	string placementID = "rewardedVideo";

	void Awake () {
		Advertisement.Initialize (gameID, true);

		Debug.Log("Unity Ads initialized: " + Advertisement.isInitialized);
		Debug.Log("Unity Ads is supported: " + Advertisement.isSupported);
		Debug.Log("Unity Ads test mode enabled: " + Advertisement.testMode);
		Debug.Log("Unity Ads game id: " + Advertisement.gameId);
		Debug.Log("Unity Ads is ready: " + Advertisement.IsReady(null));
		Debug.Log("Unity Ads placement state: " + Advertisement.GetPlacementState(placementID));
	}

	public void ShowAd (string zone = "") {

		#if UNITY_EDITOR
			StartCoroutine (WaitForAd ());
		#endif

		if (string.Equals (zone, ""))
			zone = null;

		ShowOptions options = new ShowOptions ();
		options.resultCallback = AdCallbackhandler;

		if (Advertisement.IsReady(zone)) {
			Advertisement.Show (zone, options);
		}
		print (Advertisement.IsReady (zone));

		SceneManager.LoadScene ("Main2");
//		Application.LoadLevel ("Main2");
	}

	void AdCallbackhandler (ShowResult result)
	{
		switch(result)
		{
		case ShowResult.Finished:
			Debug.Log ("Ad Finished. Rewarding player...");
			break;
		case ShowResult.Skipped:
			Debug.Log ("Ad skipped. Son, I am dissapointed in you");
			break;
		case ShowResult.Failed:
			Debug.Log("I swear this has never happened to me before");
			break;
		}
	}

	IEnumerator WaitForAd () {
		float currentTimeScale = Time.timeScale;
		Time.timeScale = 0f;
		yield return null;

		while (Advertisement.isShowing)
			yield return null;

		Time.timeScale = currentTimeScale;
	}
}
