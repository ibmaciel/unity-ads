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
		Debug.Log("Unity Ads is ready: " + Advertisement.IsReady(placementID));
		Debug.Log("Unity Ads is ready: " + Advertisement.GetPlacementState(placementID));
	}

	public void ShowAd () {

		#if UNITY_EDITOR
			StartCoroutine (WaitForAd ());
		#endif
		if (Advertisement.IsReady()) {
			Advertisement.Show ();
		}
		print (Advertisement.IsReady ());

		SceneManager.LoadScene ("Main2");
//		Application.LoadLevel ("Main2");
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
