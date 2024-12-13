using System.Collections;
using UnityEngine;

public  class FruitGen : MonoBehaviour
{
 
    public Transform pos;
    public GameObject newfruit;
    public float resetime;
    

    public SpriteRenderer spriteRenderer;
    public float timer = 5f;

    public player player;
    public InputManager inputManager;
    public float offsety;
    public float offsetx;
    
    public IEnumerator Genfruit()
    {
        int fruitindex = Random.Range(0, 4);//random fruit from fruit array
       
        newfruit = Instantiate(FruitArray.Instance.fruitArray[fruitindex], pos.position, Quaternion.identity);
        newfruit.transform.SetParent(player.transform);
        newfruit.GetComponent<Rigidbody2D>().simulated = false;
        spriteRenderer = newfruit.GetComponent<SpriteRenderer>();
        player.Heldfruit = newfruit;

        float playersize = player.transform.localScale.y;
        float fruitsizey = newfruit.transform.localScale.y/2;
        offsetx = newfruit.transform.localScale.x/2;
        offsety= (playersize + fruitsizey);
        offsety *=-1;
      
        Debug.Log("playersize"+playersize+"fruisize"+fruitsizey+"offsety"+offsety);
        //fruitposwithplayer
        //newfruit.transform.position.Set(player.transform.position.x,player.transform.position.y+offsety,player.transform.position.z);
        newfruit.transform.localPosition =new Vector3(0, offsety, 0);

        
        
        
        newfruit.SetActive(false);
      
        if (newfruit != null)
        {
            yield return new WaitForSeconds(resetime);
        }
        newfruit.SetActive(true);
        

        
        yield return newfruit;
       

    }



}
