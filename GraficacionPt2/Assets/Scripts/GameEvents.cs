using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameEvents : MonoBehaviour
{
    public static GameEvents Current;
    // Start is called before the first frame update
    public event Action<String> OnPixel;
    public event Action<Color> SetColor;
    private Color colorEntrance = Color.white;
    [SerializeField] private TextMeshProUGUI coordinatesText;
    private void Awake()
    {
        Current = this;
    }
    private void Start()
    {
        GameEvents.Current.OnPixel += ShowCoordinates;
    }

    public void MouseOnPixel(String coord)
    {
        if (OnPixel != null)
        {
            OnPixel(coord);
        }
    }
    private void ShowCoordinates(string text)
    {
        coordinatesText.text = text;
    }
}
