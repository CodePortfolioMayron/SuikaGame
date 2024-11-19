using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fruitinfo : MonoBehaviour
{
    public int fruitindex;
    public int pointswhenmerged;
    public float fruitmass;

    private Rigidbody2D rb;

    public void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.mass = fruitmass;
    }

}
