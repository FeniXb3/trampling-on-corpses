using UnityEngine;

public class GrayOut : MonoBehaviour
{
    [Range(0.1f, 10f)]
    [SerializeField] private float grayOutDuration = 1f;
    [SerializeField] private SpriteRenderer objectToColor;

    private Color initialColor;
    private Color finalColor;
    private UnityTimeService timeService;

    private float hue;
    private float saturation;
    private float value;
    private float time;

    private void Start()
    {
        LoadServices();
        initialColor = objectToColor.color;
        Color.RGBToHSV(initialColor, out hue, out saturation, out value);
        finalColor = Color.HSVToRGB(hue, 0, .25f);
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
}