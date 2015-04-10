using UnityEngine;
using System.Collections;
using UnityEngine.Advertisements;

public class EasyUnityAds : MonoBehaviour
{
	private static bool isCreated = false;
	private UnityAdsSettings unityAdsSettings;

	/// <summary>
	/// Awake this instance.
	/// </summary>
	void Awake ()
	{
		DeadOrAlive ();

		unityAdsSettings = UnityAdsSettingsUtility.Load ();
		if (unityAdsSettings == null) {
			Debug.LogWarning ("UnityAds Settings File is null!");
		}

		if (Advertisement.isSupported) {
			string gameID = GetGameID ();
			if (!string.IsNullOrEmpty (gameID)) {
				Advertisement.Initialize (gameID);
			} else {
				Debug.LogWarning (string.Format ("{0} : Does not set User ID!", this.name));
			}
		} else {
			Debug.LogWarning (string.Format ("{0} : not supported!", this.name));
		}
	}

	/// <summary>
	/// Show UnityAds.
	/// </summary>
	public void ShowUnityAds ()
	{
		if (Advertisement.isInitialized) {
			Advertisement.Show (unityAdsSettings.zoneID);
		} else {
			Debug.LogWarning (string.Format ("{0} : not initialized yet!", this.name));
		}
	}

	/// <summary>
	/// Determines whether UnityAds is initialized.
	/// </summary>
	/// <returns><c>true</c> if UnityAds is initialized; otherwise, <c>false</c>.</returns>
	public bool IsInitialized ()
	{
		return Advertisement.isInitialized;
	}

	/// <summary>
	/// this gameobject dead/alive
	/// </summary>
	private void DeadOrAlive ()
	{
		if (! isCreated) {
			DontDestroyOnLoad (gameObject);
			isCreated = true;
		} else {
			Destroy (gameObject);
		}
	}

	/// <summary>
	/// Get the gameID
	/// </summary>
	/// <returns>gameID</returns>
	private string GetGameID ()
	{
		string _gameID = string.Empty;
#if (UNITY_EDITOR && UNITY_ANDROID) || UNITY_ANDROID
		_gameID = unityAdsSettings.gameID_Android;
#elif (UNITY_EDITOR && UNITY_IOS) || UNITY_IOS
		_gameID = unityAdsSettings.gameID_iOS;
#endif
		return _gameID;
	}
}