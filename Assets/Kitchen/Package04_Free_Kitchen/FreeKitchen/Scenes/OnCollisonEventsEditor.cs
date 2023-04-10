using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(OnCollisonEvents))]
public class OnCollisonEventsEditor : Editor
{
    SerializedProperty hungerControllerProperty;

    void OnEnable()
    {
        hungerControllerProperty = serializedObject.FindProperty("hungerController");
    }

    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();

        EditorGUILayout.PropertyField(hungerControllerProperty, new GUIContent("Hunger Controller"));

        serializedObject.ApplyModifiedProperties();
    }
}