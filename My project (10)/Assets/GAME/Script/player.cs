using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class player : MonoBehaviour
{
    public delegate void OnDropAction(int scoreAmount);
    public static event OnDropAction OnDrop;
    public FruitGen FruitGen;
    public GameObject Heldfruit;
    public Transform fruithandle;


    // Start is called before the first frame update
    void Awake ()
    {
        StartCoroutine(FruitGen.Genfruit());
    
    }

    // Update is called once per frame
    void Update()
    {
       
 

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
            Fruitinfo fruitinfo = Heldfruit.GetComponent<Fruitinfo>();
            if (fruitinfo != null)
            {
                OnDrop?.Invoke(fruitinfo.fruitindex);
            }
            
            Heldfruit.transform.SetParent(null);
            Heldfruit = null;
            
            StartCoroutine(FruitGen.Genfruit());    
        }
    }
}
