using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(InspectorButton))]
public class InspectorButton_Editor : Editor
{
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();
        
        InspectorButton script = target as InspectorButton;
        
        if(GUILayout.Button("Find Child Transform") && script != null)
            script.FindChildAndAddToList();
        if(GUILayout.Button("Clear") && script != null)
            script.ClearList();
    }
}
