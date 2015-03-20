using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(EasyUnityAds))]
public class EasyUnityAdsInspector : Editor
{
	public override void OnInspectorGUI ()
	{
		GUILayout.Label ("Press the button if you'd like to change the settings");
		if (GUILayout.Button ("Open EasyUnityAds window")) {
			EasyUnityAdsWindow.Init ();
		}
	}
}
