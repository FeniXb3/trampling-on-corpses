﻿using UnityEngine;

public static class PlayerPrefsExtensions
{
    public static void SetColor(string name, Color value)
    {
        PlayerPrefs.SetFloat($"{name}_r", value.r);
        PlayerPrefs.SetFloat($"{name}_g", value.g);
        PlayerPrefs.SetFloat($"{name}_b", value.b);
    }
    
    public static Color GetColor(string name)
    {
        var r = PlayerPrefs.GetFloat($"{name}_r");
        var g = PlayerPrefs.GetFloat($"{name}_g");
        var b = PlayerPrefs.GetFloat($"{name}_b");
        
        return new Color(r, g, b);
    }

    public static bool HasColorKey(string key)
    {
        var rKey = PlayerPrefs.HasKey($"{key}_r");
        var gKey = PlayerPrefs.HasKey($"{key}_g");
        var bKey = PlayerPrefs.HasKey($"{key}_b");

        return rKey && gKey && bKey;
    }

    public static void DeleteColorKey(string key)
    {
        PlayerPrefs.DeleteKey($"{key}_r");
        PlayerPrefs.DeleteKey($"{key}_g");
        PlayerPrefs.DeleteKey($"{key}_b");
    }
}
