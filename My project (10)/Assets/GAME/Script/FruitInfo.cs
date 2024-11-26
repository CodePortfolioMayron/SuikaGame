
using UnityEngine;

public class Fruitinfo : MonoBehaviour
{
    public int fruitindex;
    public int pointswhenmerged;
    public float fruitmass;

    private Rigidbody2D rb;

    public bool timer=false;
    public float timers=3;

    public void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.mass = fruitmass;
    }
    public void Update()
    {
        if (timer)
        {
            timers -= Time.deltaTime;
            if(timers < 0) { Debug.Log("gone over "); GameObject.Find("Square").GetComponent<topboxtrigger>().restart(); }

        }else { timers = 3; }

    }

}
