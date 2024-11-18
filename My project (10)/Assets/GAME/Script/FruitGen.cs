using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public  class FruitGen : MonoBehaviour
{
    public GameObject fruittemplate;
    public int[] fruitinfo;
    public Transform pos;
    public GameObject newfruit;

    public SpriteRenderer spriteRenderer;
    public float timer = 5f;

    public player player;

   public IEnumerator  Genfruit( )
    {
       int fruitindex =  Random.Range(0, fruitinfo.Length);//random fruit from fruit array
        if (newfruit != null)
        {
            yield return new WaitForSeconds(1f);
        }
        newfruit = Instantiate(fruittemplate, pos.position, Quaternion.identity);
        newfruit.GetComponent<Rigidbody2D>().simulated =false;

        spriteRenderer = newfruit.GetComponent<SpriteRenderer>();

        switch (fruitindex)
        {
            case 0:
                spriteRenderer.color = Color.red;
                newfruit.transform.localScale = new Vector3(0.25f, 0.25f, 0.25f);
                break;

            case 1:

                spriteRenderer.color = Color.green;
                newfruit.transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
                break;

            case 2:

                spriteRenderer.color = Color.blue;
                newfruit.transform.localScale = new Vector3(0.75f, 0.75f, 0.75f);
                break;
            case 3:

                spriteRenderer.color = Color.white;
                newfruit.transform.localScale = new Vector3(1f, 1f, 1f);
                break;
            case 4:

                spriteRenderer.color = Color.black;
                newfruit.transform.localScale = new Vector3(1.25f, 1.25f, 1.25f);
                break;
      


            default:
                break;

            
        }
       player.Heldfruit = newfruit; 
       player.Heldfruit.transform.SetParent(player.transform);
        yield return newfruit;
       

    }



}
