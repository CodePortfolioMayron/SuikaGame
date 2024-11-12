using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour
{
    public FruitGen FruitGen;
    public GameObject Heldfruit;
    // Start is called before the first frame update
    void Start()
    {
        if (Heldfruit == null)
        {
            Heldfruit = FruitGen.Genfruit();
            Heldfruit.transform.SetParent(transform);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Heldfruit == null)
        {
            Heldfruit = FruitGen.Genfruit();
            Heldfruit.transform.SetParent(transform);
        }

        if (Input.GetKey(KeyCode.A))
        {
            transform.Translate(Vector3.left * 1f * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.Translate(Vector3.right * 1f * Time.deltaTime);
        }
        if(Input.GetKeyDown(KeyCode.E)) {
           Heldfruit.GetComponent<Rigidbody2D>().simulated = true;
            Heldfruit.transform.SetParent(null);
            Heldfruit = null;
        }
    }
}
