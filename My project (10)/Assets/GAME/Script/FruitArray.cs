using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class FruitArray : MonoBehaviour
{
    public static FruitArray Instance;  
    public GameObject[] fruitArray;
    public void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
        }
    }
}
