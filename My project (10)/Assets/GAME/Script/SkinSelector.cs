using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkinSelector : MonoBehaviour
{
    [Header ("SKIN SPRITES")]
    public Sprite[] DefaultSprite;
    public Sprite[] TempSkin;
    [Header("BOOLS")]
    public bool UseSkin;
    public bool Paused;
    [Header("References")]
    public InputManager inputManager;
      public FruitArray FruitArray;

    public void Start ()
    {
        if (inputManager.player.Heldfruit.GetComponent<SpriteRenderer>().sprite = TempSkin[0])
        {
            UseSkin = true;
        }
    }


    public void Pause()
    {
        Paused = !Paused;
        if (Paused)
        {
            Time.timeScale = 0;
            inputManager.enabled = false;
        }else
        {
            Time.timeScale = 1f;
            inputManager.enabled = true;
        }
    }

    public void ChangeSkin()
    {
        UseSkin = !UseSkin;
        GameObject[] fruits = GameObject.FindGameObjectsWithTag("Fruits");
        Sprite usedsprite;
        if(UseSkin) { usedsprite = TempSkin[0]; }
        else { usedsprite = DefaultSprite[0]; }

        foreach (GameObject fruit in fruits)
        {
            // Access the SpriteRenderer component
            SpriteRenderer spriteRenderer = fruit.GetComponent<SpriteRenderer>();
            if (spriteRenderer != null)
            {
                // Change the sprite to the new one
                spriteRenderer.sprite = usedsprite;
            }

        }
        for (int i = 0; i < FruitArray.fruitArray.Length ; i++)
        {
            SpriteRenderer spriteRenderer = FruitArray.fruitArray[i].GetComponent<SpriteRenderer>();
            spriteRenderer.sprite = usedsprite;
        }

    }


}
