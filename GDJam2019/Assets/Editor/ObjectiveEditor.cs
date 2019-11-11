using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
[CustomEditor(typeof(Objective))]
public class ObjectiveEditor : Editor
{
    int choice_index = 0;//the indexed choice
  
   
    public override void OnInspectorGUI()
    {
      
        DrawDefaultInspector();//draw all the default inspector elements (the things that would normally be there)
        Objective objective = target as Objective;//Gets the class you are inspecting
        if (!objective.GetIsLast())//if this is not the last objective
        {
            for (int x = 0; x < objective.GetCount(); x++) {
                List<string> objectives = new List<string>();//will contain the names of all the objectives
                Objective[] temp;//a temporary variable that holds all the objectives
                temp = FindObjectsOfType<Objective>();//getting all the objects in the scene
                if (objective.GetNext(x) != null)//if the objective already knows what its next objective is
                {
                    for (int i = 0; i < temp.Length; i++)
                    {
                        if (objective.GetNext(x) == temp[i])//if the next objective of the inspected objective is found in the list of objective
                        {
                            choice_index = i;//record the index
                        }
                    }
                }
                for (int i = 0; i < temp.Length; i++)
                {
                    objectives.Add(temp[i].GetName().ToUpper());//get and add all the names of the objectives to the list of names
                }
                EditorGUILayout.LabelField("Next Objective ("+(x+1)+"):" , temp[choice_index].GetName());//notify the user what the next objective is
                choice_index = EditorGUILayout.Popup(choice_index, objectives.ToArray());//create dropdown list and get selection
                objective.SetNext(temp[choice_index],x);//set the next objective of the inspected objective to whatever was chosen in the dropdown
            }
            EditorGUILayout.LabelField("Add/Remove Branches");
            if (GUILayout.Button("          -           "))
            {
                objective.DecreaseBranches();
            }
           
            if (GUILayout.Button("          +           "))
            {
                objective.IncreaseBranches();
            }
            EditorGUILayout.LabelField("____________________________________________________________ ");
            if (GUILayout.Button("SET AS LAST OBJECTIVE"))
            {
                objective.SetLast(true);
            }
            EditorUtility.SetDirty(target);//since the objective is being changed by something outside the unity editor,
            //setting it to dirty notifies unity to save the changes and create undo option
        }
        else
        {
            if (GUILayout.Button("SET NEXT OBJECTIVE"))
            {
                objective.SetLast(false);
            }
            EditorGUILayout.LabelField("LINK BROKEN:", "THIS IS THE FINAL OBJECTIVE!");
        }
    }
}
