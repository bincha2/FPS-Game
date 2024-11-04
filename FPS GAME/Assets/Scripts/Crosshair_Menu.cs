using System.Collections;
using System.Collections.Generic;
using Microsoft.Unity.VisualStudio.Editor;
using UnityEngine;
using UnityEngine.UI;
using UnityEditor;

public class Crosshair_Menu : MonoBehaviour
{
    public GameObject crosshairMenu;
    public UnityEngine.UI.Image crosshairIMG;

    public Slider size_slider;

    //slider for rgb
    public Slider red_slider;
    public Slider green_slider;
    public Slider blue_slider;

    //playerprefs keys to for the crosshair
    private const string SIZE_KEY = "Size";
    private const string RED_KEY = "Red";
    private const string GREEN_KEY = "Green";
    private const string BLUE_KEY = "Blue";
    private const string SPRITE_KEY = "Sprite";


    //crosshair options
    public void Option1()
    {
        SetCrosshair("Assets/SMC Pack 1/Pack/3.png");
    }

    public void Option2()
    {
        SetCrosshair("Assets/SMC Pack 1/Pack/22.png");
    }

    public void Option3()
    {
        SetCrosshair("Assets/SMC Pack 1/Pack/12.png");
    }

    private void SetCrosshair(string spritePath)
    {
        Sprite newCrosshairSprite = AssetDatabase.LoadAssetAtPath<Sprite>(spritePath);
        if (newCrosshairSprite != null)
        {
            crosshairIMG.sprite = newCrosshairSprite;
        }
        else
        {
            Debug.LogError("Failed to load crosshair sprite: " + spritePath);
        }
    }

    private void Start()
    {
        //so that the crosshair cant be too small or too big
        size_slider.minValue = 0.5f;
        size_slider.maxValue = 5f;
        size_slider.onValueChanged.AddListener(SetSize);

        //rgb sliders
        red_slider.minValue = 0f;
        red_slider.maxValue = 255f;
        green_slider.minValue = 0f;
        green_slider.maxValue = 255f;
        blue_slider.minValue = 0f;
        blue_slider.maxValue = 255f;

        red_slider.onValueChanged.AddListener(SetColor);
        green_slider.onValueChanged.AddListener(SetColor);
        blue_slider.onValueChanged.AddListener(SetColor);

    }


    //set siae of the crosshair
    public void SetSize(float value)
    {
        crosshairIMG.rectTransform.localScale = new Vector3(value, value, 1f);
    }

    //set color of crosshair using rgb values
    public void SetColor(float value)
    {
        crosshairIMG.color = new Color(red_slider.value / 255f, green_slider.value / 255f, blue_slider.value / 255f, 1f);
    }

    //save, load, and resets
    public void SaveXHAIR()
    {
        PlayerPrefs.SetFloat(SIZE_KEY, size_slider.value);
        PlayerPrefs.SetFloat(RED_KEY, red_slider.value);
        PlayerPrefs.SetFloat(GREEN_KEY, green_slider.value);
        PlayerPrefs.SetFloat(BLUE_KEY, blue_slider.value);
        string spritePath = AssetDatabase.GetAssetPath(crosshairIMG.sprite);
        PlayerPrefs.SetString(SPRITE_KEY, spritePath);
        PlayerPrefs.Save();
    }

    public void LoadXHAIR()
    {
        float size = PlayerPrefs.GetFloat(SIZE_KEY, size_slider.value);
        float red = PlayerPrefs.GetFloat(RED_KEY, red_slider.value);
        float green = PlayerPrefs.GetFloat(GREEN_KEY, green_slider.value);
        float blue = PlayerPrefs.GetFloat(BLUE_KEY, blue_slider.value);
        string spritePath = PlayerPrefs.GetString(SPRITE_KEY, AssetDatabase.GetAssetPath(crosshairIMG.sprite));

        size_slider.value = size;
        red_slider.value = red;
        green_slider.value = green;
        blue_slider.value = blue;

        crosshairIMG.color = new Color(red / 255f, green / 255f, blue / 255f, 1f);

        // Load the sprite
        Sprite sprite = AssetDatabase.LoadAssetAtPath<Sprite>(spritePath);
        if (sprite != null)
        {
            crosshairIMG.sprite = sprite;
        }
    }

    public void ResetXHAIR()
    {
        size_slider.value = 1f;
        red_slider.value = 255f;
        green_slider.value = 255f;
        blue_slider.value = 255f;
        crosshairIMG.color = new Color(red_slider.value / 255f, green_slider.value / 255f, blue_slider.value / 255f, 1f);
        crosshairIMG.sprite = AssetDatabase.LoadAssetAtPath<Sprite>("Assets/SMC Pack 1/Pack/1.png");
    }

}
