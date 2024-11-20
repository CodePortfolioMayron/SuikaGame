using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FruitCombiner : MonoBehaviour
{
    public delegate void onCombineAction(int mergeScore);
    public static event onCombineAction OnCombine;
    private int fruitindex;
    private Fruitinfo Fruitinfo;

    // Start is called before the first frame update
    void Awake()
    {
        Fruitinfo = GetComponent<Fruitinfo>();
        fruitindex = Fruitinfo.fruitindex;
    }

    public void OnCollisionEnter2D(Collision2D other)
    {
        Fruitinfo info = other.collider.GetComponent<Fruitinfo>();
        if (info != null)
        {
            if(info.fruitindex == fruitindex)
            {
                int thisid = gameObject.GetInstanceID();
                int otherid = other.gameObject.GetInstanceID();
                OnCombine?.Invoke(info.pointswhenmerged);
                if(thisid > otherid) {
                
                    //watermelon
                    if(FruitArray.Instance.fruitArray.Length == fruitindex)
                    {
                        Destroy(gameObject);
                        Destroy(other.gameObject);

                    }
                    else
                    {//middle point of 2 fruits
                        Vector3 middlepoint = (transform.position+ other.transform.position)/2;
                        Instantiate(Combinefruit(fruitindex),middlepoint,Quaternion.identity);
                        Destroy(gameObject);
                        Destroy(other.gameObject) ;
                    }
                }
            }

        }
        {
            
        }
       
    }

    private GameObject Combinefruit(int index)
    {
        GameObject go = FruitArray.Instance.fruitArray[index++];
        return go;  
    }

}
