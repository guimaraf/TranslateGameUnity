﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System.IO;

public class LocalizeTextEditor : EditorWindow {

    public LocalizationData localizationData;

    [MenuItem("Window/Localized Text Editor")]
    static void Init()
    {
        GetWindow(typeof(LocalizeTextEditor)).Show();
    }

    private void OnGUI()
    {
        if(localizationData != null)
        {
            SerializedObject serializedObject = new SerializedObject(this);
            SerializedProperty serializedProperty = serializedObject.FindProperty("localizationData");
            EditorGUILayout.PropertyField(serializedProperty, true);
            serializedObject.ApplyModifiedProperties();

            if(GUILayout.Button("Save Data"))
            {
                SaveGameData();
            }
        }

        if(GUILayout.Button("Load Data"))
        {
            LoadGameData();
        }

        if(GUILayout.Button("Create New Data"))
        {
            CreateNewData();
        }
    }

    private void CreateNewData()
    {
        localizationData = new LocalizationData();
    }

    private void SaveGameData()
    {
        string filePath = EditorUtility.SaveFilePanel("Save Data File", Application.streamingAssetsPath, "", "json");
        if (!string.IsNullOrEmpty(filePath))
        {
            string dataAsJson = JsonUtility.ToJson(localizationData);
            File.WriteAllText(filePath, dataAsJson);
        }
    }

    private void LoadGameData()
    {
        string filePath = EditorUtility.OpenFilePanel("Select Data File", Application.streamingAssetsPath, "json");
        if (!string.IsNullOrEmpty(filePath))
        {
            string dataAsJson = File.ReadAllText(filePath);
            localizationData = JsonUtility.FromJson<LocalizationData>(dataAsJson);
        }
    }
}
