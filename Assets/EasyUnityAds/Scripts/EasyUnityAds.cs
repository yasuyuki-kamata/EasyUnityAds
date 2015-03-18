using UnityEngine;
using System.Collections;
using UnityEngine.Advertisements;

public class EasyUnityAds : MonoBehaviour
{
	[SerializeField]
	private string gameID_iOS;
	[SerializeField]
	private string gameID_Android;

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
			Advertisement.Show ();
		} else {
			Debug.LogWarning (string.Format("{0} : not initialized yet!", this.name));
		}
	}

	public bool IsInitialized ()
	{
		return Advertisement.isInitialized;
	}
}