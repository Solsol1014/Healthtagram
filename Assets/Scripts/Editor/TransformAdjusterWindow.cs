using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class TransformAdjusterWindow : EditorWindow
{
    private GameObject selectedObject;
    private Vector3 position;
    private Vector3 rotation;
    private Vector3 scale = Vector3.one;

    [MenuItem("Window/Transform Adjuster")]
    public static void ShowWindow()
    {
        GetWindow<TransformAdjusterWindow>("Transform Adjuster");
    }

    private void OnGUI()
    {
        GUILayout.Label("Select an Object", EditorStyles.boldLabel);

        selectedObject = (GameObject)EditorGUILayout.ObjectField("Object", selectedObject, typeof(GameObject), true);

        if (selectedObject != null)
        {
            position = EditorGUILayout.Vector3Field("Position", position);
            rotation = EditorGUILayout.Vector3Field("Rotation", rotation);
            scale = EditorGUILayout.Vector3Field("Scale", scale);

            if (GUILayout.Button("Apply Transform"))
            {
                ApplyTransform();
            }

            if (GUILayout.Button("Reset Transform"))
            {
                ResetTransform();
            }
        }
    }

    private void ApplyTransform()
    {
        if (selectedObject != null)
        {
            Undo.RecordObject(selectedObject.transform, "Apply Transform");
            selectedObject.transform.localPosition = position;
            selectedObject.transform.localRotation = Quaternion.Euler(rotation);
            selectedObject.transform.localScale = scale;
        }
    }

    private void ResetTransform()
    {
        if (selectedObject != null)
        {
            Undo.RecordObject(selectedObject.transform, "Reset Transform");
            position = Vector3.zero;
            rotation = Vector3.zero;
            scale = Vector3.one;

            selectedObject.transform.localPosition = position;
            selectedObject.transform.localRotation = Quaternion.Euler(rotation);
            selectedObject.transform.localScale = scale;
        }
    }
}
