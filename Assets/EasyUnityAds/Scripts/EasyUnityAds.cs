using UnityEngine;
using System.Collections;
using UnityEngine.Advertisements;

public class EasyUnityAds : MonoBehaviour
{
	public string gameID_iOS = "26870";
	public string gameID_Android = "26871";
	public string zoneID = null;

	void Awake ()
	{
		if (Advertisement.isSupported) {
			string gameID;
#if (UNITY_EDITOR && UNITY_ANDROID) || UNITY_ANDROID
			gameID = gameID_Android;
#elif (UNITY_EDITOR && UNITY_IOS) || UNITY_IOS
			gameID = gameID_iOS;
#endif
			if (gameID != "" && gameID != null) {
				Advertisement.Initialize (gameID);
			} else {
				Debug.LogWarning (string.Format("{0} : Does not set User ID!", this.name));
			}
		} else {
			Debug.LogWarning (string.Format("{0} : not supported!", this.name));
		}
	}

	public void ShowUnityAds ()
	{
		if (Advertisement.isInitialized) {
			Advertisement.Show (zoneID);
		} else {
			Debug.LogWarning (string.Format("{0} : not initialized yet!", this.name));
		}
	}

	public bool IsInitialized ()
	{
		return Advertisement.isInitialized;
	}
}