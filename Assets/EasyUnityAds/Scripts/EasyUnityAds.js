#pragma strict
import UnityEngine.Advertisements;

var gameID_iOS : String = "26870";
var gameID_Android : String = "26871";
var isTest : boolean = false;
var zoneID : String = null;

function Awake ()
{
	if (Advertisement.isSupported) {
		var gameID : String;
#if (UNITY_EDITOR && UNITY_ANDROID) || UNITY_ANDROID
		gameID = gameID_Android;
#elif (UNITY_EDITOR && UNITY_IOS) || UNITY_IOS
		gameID = gameID_iOS;
#endif
		if (gameID != "" && gameID != null) {
			Advertisement.Initialize (gameID, isTest);
		}
	}
}

function ShowUnityAds ()
{
	if (Advertisement.isInitialized) {
		Advertisement.Show (zoneID, null);
	}
}