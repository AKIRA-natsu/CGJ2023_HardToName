using System;
using UnityEngine;
using UnityEditor;
using Object = UnityEngine.Object;
using AKIRA.Data;
using Modules.Item;

[CustomEditor(typeof(DialogConfig))]
public class DialogConfigInspector : Editor {
    public override void OnInspectorGUI() {
        base.OnInspectorGUI();

        var config = target as DialogConfig;
        
        if (GUILayout.Button("Update Xlsx Props")) {
            var path = config.excelPath;
            if (String.IsNullOrEmpty(path) || !path.Contains(".xlsx")) {
                $"{path} 路径错误".Error();
                return;
            }

            config.SetDialogs(path.ExcelConvertToClass<Dialog>(GameData.DLL.Default).ToArray());
            config.SetCharacters(path.ExcelConvertToClass<Character>(GameData.DLL.Default, 1).ToArray());
            config.SetItems(path.ExcelConvertToClass<ItemInfo>(GameData.DLL.Default, 2).ToArray());
        }
    }
}