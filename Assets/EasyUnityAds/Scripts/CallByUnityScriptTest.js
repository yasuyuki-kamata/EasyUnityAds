#pragma strict
// Sample script how to call "ShowUnityAds" by UnityScript

function OnGUI ()
{
	// TEST: GUI Button
	if (GUILayout.Button("Show UnityAds by UnityScript"))
	{
		// Calling a method "ShowUnityAds()" in EasyUnityAds component that is attached same game object.
		gameObject.SendMessage("ShowUnityAds");
	}
}