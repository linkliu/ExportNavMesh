using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(LevelGenerator))]
public class LevelGenerateEditor : Editor
{

    private LevelGenerator generator;

    private void OnEnable()
    {
        this.generator = (LevelGenerator)target;
    }

    public override void OnInspectorGUI()
    {
        GUILayout.BeginHorizontal();
        if (GUILayout.Button("Generate"))
        {
            Debug.Log("Generate");
            if (generator.buildRoot != null && generator.wall != null && generator.surface != null)
            {
                if (generator.buildRoot.childCount > 0)
                {
                    for (int i = 0; i < generator.buildRoot.childCount; i++)
                    {
                        DestroyImmediate(generator.buildRoot.GetChild(i).gameObject);
                    }
                }

                generator.GenerateLevel();
            }
        }

        if (GUILayout.Button("Bake"))
        {
            generator.surface.BuildNavMesh();
        }

        GUILayout.EndHorizontal();

        DrawDefaultInspector();
    }

}
