using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Colorizer : MonoBehaviour
{
    [SerializeField] private SpriteRenderer objectToColor;

    private void Start()
    {
        ObtainRandomColor();
    }

    private void ObtainRandomColor()
    {
        var randomColor = Random.ColorHSV(0, 1f, .25f, .25f, .75f, .75f);
        objectToColor.color = randomColor;
    }
    
}