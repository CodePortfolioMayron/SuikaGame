using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class topboxtrigger : MonoBehaviour
{
    public static topboxtrigger instace;

    public void Awake()
    {
        if (instace == null) 
        { instace = this; }
       
    }

    public void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.transform.position.y > this.transform.position.y)
        {
            Debug.Log("gone above?" + collision.name);
            collision.gameObject.GetComponent<Fruitinfo>().timer = true;
        }
        else
            collision.gameObject.GetComponent<Fruitinfo>().timer = false;

    }

   public void restart()
    {
        SceneManager.LoadScene(0);
    }
}


