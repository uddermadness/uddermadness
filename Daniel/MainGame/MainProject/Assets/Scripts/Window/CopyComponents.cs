using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System;

public class CopyComponents : EditorWindow
{

    Component[] components;

    public GameObject SourceGameObject;
    public GameObject TargetGameObjec;
    static Type CompType;

    [MenuItem("Window/Copy")]
    public static void ShowWindow()
    {
        GetWindow<CopyComponents>("Copy");
    }

    void OnGUI()
    {
        //Window Code
        GUILayout.Label("Copy Components.", EditorStyles.boldLabel);

        if(GUILayout.Button("Copy"))
        {
            Copy();
        }
    }

    void Colorize()
    {
        foreach (GameObject obj in Selection.gameObjects)
        {
            Renderer renderer = obj.GetComponent<Renderer>();
            if (renderer != null)
            {
                //renderer.sharedMaterial.color = color;
            }
        }
    }
    
    void Copy()
    {
        //if (SourceGameObject == null) SourceGameObject = gameObject;

        components = SourceGameObject.GetComponents<Component>();
        for (int i = 0; i < components.Length; ++i)
        {
            if (components[i] != null && components[i] != this)
            {


                CompType = components[i].GetType();
                TargetGameObjec.AddComponent(CompType);

                //print(CompType);
            }

            if (components[i] == null)
                Debug.LogWarning("Warning, component n° " + i + " not found in this project");
        }
    }
}
