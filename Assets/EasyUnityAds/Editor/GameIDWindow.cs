using UnityEditor;
using UnityEngine;
using System.Collections;

public class GameIDWindow : EditorWindow
{
	private GUIStyle headerGUIStyle = new GUIStyle();
	private Texture2D texture;

	public static void Init ()
	{
		GameIDWindow window = (GameIDWindow)EditorWindow.GetWindow<GameIDWindow> ();
		window.minSize = new Vector2 (967f, 218f);
		window.maxSize = new Vector2 (967f, 250f);
		window.Show ();
	}

	void OnEnable ()
	{
		texture = (Texture2D) AssetDatabase.LoadAssetAtPath("Assets/EasyUnityAds/Editor/images/GameID.png", typeof(Texture2D));
		headerGUIStyle.fontStyle = FontStyle.Bold;
		headerGUIStyle.fontSize = 20;
	}

	void OnGUI ()
	{
		GUILayout.Label ("What is Game ID?", headerGUIStyle);
		EditorGUI.DrawPreviewTexture (new Rect (0, 30f, EditorGUIUtility.currentViewWidth, 218f), texture, null, ScaleMode.ScaleToFit,  967/218);
	}
}
