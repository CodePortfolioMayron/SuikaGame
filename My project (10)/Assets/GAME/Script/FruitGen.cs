using System.Collections;
using UnityEngine;
using static UnityEditor.Experimental.GraphView.GraphView;

public  class FruitGen : MonoBehaviour
{
    public GameObject fruittemplate;
 
    public Transform pos;
    public GameObject newfruit;
    public float resetime;

    public SpriteRenderer spriteRenderer;
    public float timer = 5f;

    public player player;
    public InputManager inputManager;

    public IEnumerator Genfruit()
    {
        int fruitindex = Random.Range(0, 4);//random fruit from fruit array
       
        newfruit = Instantiate(FruitArray.Instance.fruitArray[fruitindex], pos.position, Quaternion.identity);
        newfruit.GetComponent<Rigidbody2D>().simulated = false;
        spriteRenderer = newfruit.GetComponent<SpriteRenderer>();
        player.Heldfruit = newfruit;

        float playersize = player.transform.localScale.y;
        float fruitsize = newfruit.transform.localScale.y;
        float offset= playersize + fruitsize;
        offset *=-1;
      
        Debug.Log("offset"+offset);
       
        Vector2 fruitposwithplayer = new Vector2 (player.transform.position.x, offset);
        newfruit.transform.SetParent(player.transform);
        //newfruit.transform.position = fruitposwithplayer;
        newfruit.transform.localPosition = new Vector3(0, offset, 0);

        
        
        
        newfruit.SetActive(false);
      
        if (newfruit != null)
        {
            yield return new WaitForSeconds(resetime);
        }
        newfruit.SetActive(true);
        

        
        yield return newfruit;
       

    }



}
