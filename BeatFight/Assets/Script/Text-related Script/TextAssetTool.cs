using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class TextAssetTool
{
    public static string[] ReadTextAssetData(string filePath)
    {
        TextAsset textAsset = Resources.Load<TextAsset>(filePath);

        return ReadTextAssetData(textAsset);
    }

    public static string[] ReadTextAssetData(TextAsset textAsset)
    {
        if (textAsset == null) return null;

        string textData = textAsset.text;

        string[] rows = textData.Split('\n');

        return rows;
    }
}
