using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(EasyUnityAds))]
public class EasyUnityAdsInspector : Editor
{
	public override void OnInspectorGUI ()
	{
		GUILayout.Label ("Press the button if change UnityAds Setting");
		if (GUILayout.Button ("Open UnityAds Setting")) {
			EasyUnityAdsWindow.Init ();
		}
	}
}
