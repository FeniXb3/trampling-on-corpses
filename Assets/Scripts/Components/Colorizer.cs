using Services;
using Services.Implementations;
using UnityEngine;

public class Colorizer : MonoBehaviour
{
    [SerializeField] private SpriteRenderer objectToColor;

    private ILocalStorageService localStorageService;
    private static readonly string colorPrefName = "playerColor";

    private void Start()
    {
        LoadServices();
        
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
        return localStorageService.HasColorKey(colorPrefName);
    }

    private void LoadColor()
    {
        objectToColor.color = localStorageService.GetColor(colorPrefName);
    }

    private void ObtainRandomColor()
    {
        var randomColor = Random.ColorHSV(0, 1f, .25f, .25f, .75f, .75f);
        objectToColor.color = randomColor;

        localStorageService.SetColor(colorPrefName, randomColor);
    }

    private void LoadServices()
    {
        if (localStorageService == null)
        {
            localStorageService = new PlayerPrefsLocalStorageService();
        }
    }
    
}