using UnityEngine;
using System.Collections;

[System.Serializable]
public class UnityAdsSettings : ScriptableObject
{
	public const string DATA_SAVE_PATH = "Assets/EasyUnityAds/Resources/";
	public const string DATA_FILENAME = "UnityAdsSettings";
	public const string DATA_EXT = ".asset";
	public string gameID_iOS;
	public string gameID_Android;
	public string zoneID;

	/// <summary>
	/// Initializes a new instance of the <see cref="UnityAdsSettings"/> class.
	/// </summary>
	public UnityAdsSettings ()
	{
		gameID_iOS = "26870";
		gameID_Android = "26871";
		zoneID = null;
	}
}

public class UnityAdsSettingsUtility
{
	/// <summary>
	/// Load UnityAdsSettings from "Resources" folder.
	/// </summary>
	public static UnityAdsSettings Load ()
	{
		return Resources.Load<UnityAdsSettings> (UnityAdsSettings.DATA_FILENAME);
	}
}