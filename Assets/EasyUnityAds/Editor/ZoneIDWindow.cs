using UnityEditor;
using UnityEngine;
using System.Collections;

public class ZoneIDWindow : EditorWindow
{
	private GUIStyle headerGUIStyle = new GUIStyle();
	private Texture2D texture;
	
	public static void Init ()
	{
		ZoneIDWindow window = (ZoneIDWindow)EditorWindow.GetWindow<ZoneIDWindow> ();
		window.minSize = new Vector2 (966f, 400f);
		window.maxSize = new Vector2 (966f, 450f);
		window.Show ();
	}
	
	void OnEnable ()
	{
		texture = (Texture2D) AssetDatabase.LoadAssetAtPath("Assets/EasyUnityAds/Editor/images/ZoneID.png", typeof(Texture2D));
		headerGUIStyle.fontStyle = FontStyle.Bold;
		headerGUIStyle.fontSize = 20;
	}
	
	void OnGUI ()
	{
		GUILayout.Label ("What is Zone ID?", headerGUIStyle);
		EditorGUILayout.Separator ();
		EditorGUILayout.BeginHorizontal ();
		EditorGUILayout.SelectableLabel ("defaultVideoAndPictureZone");
		EditorGUILayout.SelectableLabel ("rewardedVideoZone");
		EditorGUILayout.EndHorizontal ();
		EditorGUI.DrawPreviewTexture (new Rect (0, 60f, EditorGUIUtility.currentViewWidth, 338f), texture, null, ScaleMode.ScaleToFit,  966/310);
	}}
