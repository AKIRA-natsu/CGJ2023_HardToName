using System;
using UnityEngine;
using UnityEditor;
using Object = UnityEngine.Object;
using AKIRA.Data;
using System.Collections.Generic;

[CustomEditor(typeof(DialogConfig))]
public class DialogConfigInspector : Editor {
    // excel 物体
    private Object excel;

    public override void OnInspectorGUI() {
        base.OnInspectorGUI();

        var config = target as DialogConfig;

        if (config.excelPath != null)
            excel = AssetDatabase.LoadAssetAtPath<Object>(config.excelPath);
        excel = EditorGUILayout.ObjectField("Excel", excel, typeof(Object), true);
        config.excelPath = AssetDatabase.GetAssetPath(excel);

        if (!config.excelPath.Contains(".xlsx")) {
            config.excelPath = default;
            excel = default;
        }
        
        if (GUILayout.Button("Update Dialogs")) {
            config.SetDialogs(config.excelPath.ExcelConvertToClass<Dialog>(GameData.DLL.Default).ToArray());
        }

        if (GUILayout.Button("Update Charactors")) {
            config.SetCharacters(config.excelPath.ExcelConvertToClass<Character>(GameData.DLL.Default, 1).ToArray());
        }
    }
}