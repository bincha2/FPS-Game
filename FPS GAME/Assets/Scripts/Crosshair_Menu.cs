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
}
