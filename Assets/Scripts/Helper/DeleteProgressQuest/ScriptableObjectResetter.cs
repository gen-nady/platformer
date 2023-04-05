using Infastructure;
using UnityEngine;
using UnityEditor;

public class ScriptableObjectResetter : EditorWindow
{
    private ScriptableObjectList _scriptableObjectList;

    [MenuItem("Tools/Reset Scriptable Objects")]
    private static void ShowWindow()
    {
        GetWindow<ScriptableObjectResetter>("Reset Scriptable Objects");
    }
    
    private void OnGUI()
    {
        EditorGUILayout.LabelField($"Reset Fields to {_scriptableObjectList.Quests.Count} for Selected ScriptableObjects");
        _scriptableObjectList = EditorGUILayout.ObjectField("ScriptableObjects List", _scriptableObjectList, typeof(ScriptableObjectList), true) as ScriptableObjectList;

        if (GUILayout.Button("Reset"))
        {
            if (_scriptableObjectList == null)
            {
                Debug.LogError("ScriptableObjectList not set");
                return;
            }

            foreach (var scriptableObject in _scriptableObjectList.Quests)
            {
                scriptableObject.ResetValue();
            }
        }
    }
}