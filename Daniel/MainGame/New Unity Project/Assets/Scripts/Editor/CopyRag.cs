using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class CopyRag : EditorWindow
{
    GameObject source;
    GameObject target;

    [MenuItem("Window/CopyComponents")]

    public static void ShowWindow()
    {
        GetWindow<CopyRag>("CopyComponents");
    }

    void OnGUI()
    {
        GUILayout.Label("I suck", EditorStyles.boldLabel);

        source = EditorGUILayout.ObjectField(new GUIContent("Source Object"), source, typeof(GameObject),  true) as GameObject;
        target = EditorGUILayout.ObjectField(new GUIContent("Target Object"), target, typeof(GameObject), true) as GameObject;

        

        if (GUILayout.Button("Copy"))
        {
            CopySpecialComponents(source,target);
        }
        
    }


    private void CopySpecialComponents(GameObject _sourceGO, GameObject _targetGO)
    {
        foreach (var component in _sourceGO.GetComponents<Component>())
        {
            var componentType = component.GetType();
            Debug.Log(componentType);

            if (componentType != typeof(Transform) &&
                componentType != typeof(MeshFilter) &&
                componentType != typeof(MeshRenderer)
                //componentType != typeof(BoxCollider) &&
                //componentType != typeof(SphereCollider) &&
                //componentType != typeof(CapsuleCollider)
                )
            {
                Debug.Log("Found a component of type " + component.GetType());
                UnityEditorInternal.ComponentUtility.CopyComponent(component);
                UnityEditorInternal.ComponentUtility.PasteComponentAsNew(_targetGO);
                Debug.Log("Copied " + component.GetType() + " from " + _sourceGO.name + " to " + _targetGO.name);
            }
        }
    }
}
