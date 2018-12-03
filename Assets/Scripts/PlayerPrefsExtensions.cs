using UnityEngine;

public static class PlayerPrefsExtensions
{
    public static void SetColor(string name, Color value)
    {
        PlayerPrefs.SetFloat(string.Format("{0}_r", name), value.r);
        PlayerPrefs.SetFloat(string.Format("{0}_g", name), value.g);
        PlayerPrefs.SetFloat(string.Format("{0}_b", name), value.b);
    }
    
    public static Color GetColor(string name)
    {
        var r = PlayerPrefs.GetFloat(string.Format("{0}_r", name));
        var g = PlayerPrefs.GetFloat(string.Format("{0}_g", name));
        var b = PlayerPrefs.GetFloat(string.Format("{0}_b", name));
        
        return new Color(r, g, b);
    }

    public static bool HasColorKey(string key)
    {
        var rKey = PlayerPrefs.HasKey(string.Format("{0}_r", key));
        var gKey = PlayerPrefs.HasKey(string.Format("{0}_g", key));
        var bKey = PlayerPrefs.HasKey(string.Format("{0}_b", key));

        return rKey && gKey && bKey;
    }
}