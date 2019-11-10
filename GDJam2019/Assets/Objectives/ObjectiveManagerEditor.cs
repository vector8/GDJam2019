using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(ObjectiveManager))]
public class ObjectiveManagerEditor : Editor
{
    public override void OnInspectorGUI()
    {
        ObjectiveManager objectiveManager = target as ObjectiveManager;
        DrawDefaultInspector();
        EditorUtility.SetDirty(target);
        if (GUILayout.Button("ADD OBJECTIVE"))
        {
           Objective objective = objectiveManager.gameObject.AddComponent<Objective>();
            if (!objectiveManager.HasStarter())
            {
                objectiveManager.SetStarter(objective);
            }

        }
        EditorUtility.SetDirty(target);
    }
 }
