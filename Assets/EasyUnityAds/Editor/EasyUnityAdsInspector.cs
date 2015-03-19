using UnityEditor;
using UnityEngine;
using System.Collections;

[CustomEditor(typeof(EasyUnityAds))]
public class EasyUnityAdsInspector : Editor
{
	private GUIStyle headerGUIStyle = new GUIStyle();
	private GUILayoutOption headerGUILayout = GUILayout.Height(20f);

	public override void OnInspectorGUI ()
	{
		headerGUIStyle.fontSize = 15;
		headerGUIStyle.fontStyle = FontStyle.Bold;

		EasyUnityAds easyUnityAds = target as EasyUnityAds;

		EditorGUILayout.Separator ();
		EditorGUILayout.LabelField ("Game ID", headerGUIStyle, headerGUILayout);
		EditorGUI.indentLevel++;
		easyUnityAds.gameID_iOS = EditorGUILayout.TextField ("iOS", easyUnityAds.gameID_iOS);
		easyUnityAds.gameID_Android = EditorGUILayout.TextField ("Android", easyUnityAds.gameID_Android);
		EditorGUILayout.BeginHorizontal ();
		GUILayout.FlexibleSpace ();
		if (GUILayout.Button ("Where is Game ID?")) {
			GameIDWindow.Init();
		}
		EditorGUILayout.EndHorizontal ();
		EditorGUI.indentLevel--;

		EditorGUILayout.Separator ();

		EditorGUILayout.LabelField ("Zone ID", headerGUIStyle, headerGUILayout);
		EditorGUI.indentLevel++;
		easyUnityAds.zoneID = EditorGUILayout.TextField ("Zone ID", easyUnityAds.zoneID);
		EditorGUILayout.BeginHorizontal ();
		GUILayout.FlexibleSpace ();
		if (GUILayout.Button ("Where is Zone ID?")) {
			ZoneIDWindow.Init();
		}
		EditorGUILayout.EndHorizontal ();
		EditorGUI.indentLevel--;
	}
}
