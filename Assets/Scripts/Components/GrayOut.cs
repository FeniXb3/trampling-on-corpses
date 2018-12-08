using UnityEngine;

public class GrayOut : MonoBehaviour
{
    [Range(0.1f, 10f)]
    [SerializeField] private float grayOutDuration = 1f;
    [SerializeField] private SpriteRenderer objectToColor;

    private Color initialColor;
    private Color finalColor;
    private UnityTimeService timeService;

    private float time;

    private void Start()
    {
        LoadServices();
        initialColor = objectToColor.color;
        finalColor = GenerateFinalColor(initialColor);
    }

    private void Update()
    {
        objectToColor.color = Color.Lerp(initialColor, finalColor, time);
        if (time < 1)
        {
            time += timeService.GetDeltaTime() / grayOutDuration;
        }
    }
    
    private void LoadServices()
    {
        if (timeService == null)
        {
            timeService = new UnityTimeService();
        }
    }

    private Color GenerateFinalColor(Color initialColor)
    {
        float hue;
        float saturation;
        float value;
        
        Color.RGBToHSV(initialColor, out hue, out saturation, out value);
        
        return Color.HSVToRGB(hue, 0, .20f);
    }
}