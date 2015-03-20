using UnityEditor;
using UnityEngine;
using System.Collections;

public class EasyUnityAdsWindow : EditorWindow
{
	const string LABEL_GAME_ID = "Game ID";
	const string LABEL_IOS = "iOS";
	const string LABEL_ANDROID = "Android";
	const string LABEL_ZONE_ID = "Zone ID";
	const string LABEL_CLOSE = "Close";
	const string LABEL_CREATE_UNITYADS_OBJECT = "Create UnityAds Object";
	const string GAMEOBJECT_NAME = "UnityAds";
	private UnityAdsSettings unityAdsSettings;
	private Texture logo;

	/// <summary>
	/// Init this instance.
	/// </summary>
	[MenuItem("Unity Ads/Settings")]
	public static void Init ()
	{
		getSettings ();
		EasyUnityAdsWindow window = (EasyUnityAdsWindow)GetWindow<EasyUnityAdsWindow> ();
		window.minSize = new Vector2 (300f, 400f);
		window.Show ();
	}

	/// <summary>
	/// Gets UnityAds settings.
	/// </summary>
	/// <returns>Returns the <see cref="UnityAdsSettings"/> class</returns>
	private static UnityAdsSettings getSettings ()
	{
		UnityAdsSettings _unityAdsSettings = UnityAdsSettingsUtility.Load ();
		if (_unityAdsSettings == null) {
			_unityAdsSettings = ScriptableObject.CreateInstance<UnityAdsSettings> ();
			AssetDatabase.CreateAsset (
				_unityAdsSettings,
				string.Format ("{0}{1}{2}", UnityAdsSettings.DATA_SAVE_PATH, UnityAdsSettings.DATA_FILENAME, UnityAdsSettings.DATA_EXT)
			);
			AssetDatabase.Refresh ();
		}
		return _unityAdsSettings;
	}

	void OnEnable ()
	{
		logo = (Texture)AssetDatabase.LoadAssetAtPath (
			"Assets/EasyUnityAds/Editor/images/UnityAdsLogo.png",
			typeof(Texture)
		);
		unityAdsSettings = getSettings ();
	}

	void OnGUI ()
	{
		GUI.changed = false;
		float currentViewWidth = EditorGUIUtility.currentViewWidth;
		GUI.DrawTexture (new Rect ((currentViewWidth - 276f) / 2, 10f, 276f, 72f), logo);
			
		GUILayout.Space (100f);

		GUILayout.Label ("Setting UnityAds");

		GUILayout.Space (20f);

		GUILayout.Label (LABEL_GAME_ID);
		EditorGUI.indentLevel++;
		unityAdsSettings.gameID_iOS = EditorGUILayout.TextField (LABEL_IOS, unityAdsSettings.gameID_iOS);
		unityAdsSettings.gameID_Android = EditorGUILayout.TextField (LABEL_ANDROID, unityAdsSettings.gameID_Android);
		EditorGUI.indentLevel--;
		if (GUILayout.Button ("What is Game ID?")) {
			GameIDWindow.Init ();
		}

		GUILayout.Space (20f);

		GUILayout.Label (LABEL_ZONE_ID);
		EditorGUI.indentLevel++;
		unityAdsSettings.zoneID = EditorGUILayout.TextField (LABEL_ZONE_ID, unityAdsSettings.zoneID);
		EditorGUI.indentLevel--;
		if (GUILayout.Button ("What is Zone ID?")) {
			ZoneIDWindow.Init ();
		}

		if (GUI.changed)
			EditorUtility.SetDirty (unityAdsSettings);

		GUILayout.Space (20f);

		if (GUILayout.Button (LABEL_CREATE_UNITYADS_OBJECT)) {
			CreateUnityAdsObject ();
		}

		if (GUILayout.Button (LABEL_CLOSE)) {
			this.Close ();
		}
	}

	/// <summary>
	/// Creates GameObject into current scene.
	/// </summary>
	void CreateUnityAdsObject ()
	{
		GameObject go = new GameObject ();
		go.AddComponent<EasyUnityAds> ();
		go.name = GAMEOBJECT_NAME;
	}
}