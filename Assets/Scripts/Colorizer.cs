using UnityEngine;

public class Colorizer : MonoBehaviour
{
    [SerializeField] private SpriteRenderer objectToColor;

    private static readonly string colorPrefName = "playerColor";

    private void Start()
    {
        if (HasColorToSet())
        {
            LoadColor();
        }
        else
        {
            ObtainRandomColor();
        }
    }

    private bool HasColorToSet()
    {
        return PlayerPrefsExtensions.HasColorKey(colorPrefName);
    }

    private void LoadColor()
    {
        objectToColor.color = PlayerPrefsExtensions.GetColor(colorPrefName);
    }

    private void ObtainRandomColor()
    {
        var randomColor = Random.ColorHSV(0, 1f, .25f, .25f, .75f, .75f);
        objectToColor.color = randomColor;

        PlayerPrefsExtensions.SetColor(colorPrefName, randomColor);
    }
    
}