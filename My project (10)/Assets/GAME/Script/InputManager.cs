using UnityEngine;
using UnityEngine.EventSystems;

public class InputManager : MonoBehaviour
{
    
    public delegate void OnDropAction(int scoreAmount);
    public static event OnDropAction OnDrop;
    [Header("REFERENCES")]
    private AndroidInput inputActions;
    private FruitGen fruitGen;
    public player player;
    private Vector3 screenBounds;

    public float pixoffsetx;
    public float pixoffsety;
    public int widthspace;
    public void Awake()
    {
        // inputActions = new AndroidInput();
        fruitGen = GetComponent<FruitGen>();
    }
    private void OnEnable()
    {
       // inputActions.Enable();
    }
    public void OnDisable()
    {
       // inputActions.Disable();
    }
  
    public void Start()
    {
        Camera mainCamera = Camera.main;
        screenBounds = mainCamera.ScreenToWorldPoint(new Vector3(Screen.width*2, Screen.height, -1));

    }
    public void Dropfruit()
    {
        player.Heldfruit.GetComponent<Rigidbody2D>().simulated = true;
        Fruitinfo fruitinfo = player.Heldfruit.GetComponent<Fruitinfo>();
        if (fruitinfo != null)
        {
            Debug.Log("score inc");
            OnDrop?.Invoke(fruitinfo.fruitindex);
        }
        player.Heldfruit.transform.SetParent(null);
        player.Heldfruit = null;
        StartCoroutine(fruitGen.Genfruit());
       
    }
    public void Update()
    {
      
        if (Input.touchCount > 0)
        {
           Touch touch = Input.GetTouch(0);
            if (touch.phase == TouchPhase.Began)
            {
                Debug.Log("began touch");
                //Ray ray = Camera.main.ScreenPointToRay(touch.position);
                if (EventSystem.current.IsPointerOverGameObject(touch.fingerId))
                {
                    Debug.Log("Touch is over a UI element!");
                }
                else { 

                Vector3 worldPosition = Camera.main.ScreenToWorldPoint(new Vector3(touch.position.x, touch.position.y, 0f));
                player.transform.position = ClampToScreenBounds(new Vector3(worldPosition.x, player.transform.position.y, 0f));
                }
            }
            if (touch.phase == UnityEngine.TouchPhase.Moved)
            {

                Vector3 worldPosition = Camera.main.ScreenToWorldPoint(new Vector3(touch.position.x, touch.position.y, 0f));
                player.transform.position = ClampToScreenBounds(new Vector3(worldPosition.x, player.transform.position.y, 0f));

            }
            if (touch.phase == UnityEngine.TouchPhase.Ended || touch.phase == UnityEngine.TouchPhase.Canceled)
                {
                    Debug.Log("end touch");
                if ( player.Heldfruit != null && player.Heldfruit.activeInHierarchy ==true ) {Dropfruit(); }
                    
                }
        }
    }

    private Vector3 ClampToScreenBounds(Vector3 position)
    {
        float clampedY; float clampedX;
        if (fruitGen.offsetx < player.transform.localScale.x)
        {

            clampedX = Mathf.Clamp(position.x, screenBounds.x * -1 + player.transform.localScale.x - pixoffsetx, screenBounds.x - player.transform.localScale.x + pixoffsetx);
            clampedY = Mathf.Clamp(position.y, screenBounds.y * -1 + player.transform.localScale.y - pixoffsety, screenBounds.y - player.transform.localScale.y + pixoffsety);

            return new Vector3(clampedX, clampedY, 0f);
        }
        else
            clampedX = Mathf.Clamp(position.x, screenBounds.x * -1 + fruitGen.offsetx - pixoffsetx, screenBounds.x - fruitGen.offsetx + pixoffsetx);
        clampedY = Mathf.Clamp(position.y, screenBounds.y * -1 + fruitGen.offsety-pixoffsety, screenBounds.y - fruitGen.offsety+pixoffsety);

        return new Vector3(clampedX, clampedY, 0f);
    }

    
}

