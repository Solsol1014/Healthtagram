using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(ToggleVisibility))]
public class ToggleVisibilityEditor : Editor
{
    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();

        ToggleVisibility script = (ToggleVisibility)target;

        if (GUILayout.Button("Hide Object"))
        {
            script.HideObject();
        }

        if (GUILayout.Button("Show Object"))
        {
            script.ShowObject();
        }
    }
}
