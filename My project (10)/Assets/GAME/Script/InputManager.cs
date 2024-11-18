using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager : MonoBehaviour
{
    private AndroidInput inputActions;
    private FruitGen fruitGen;
    [SerializeField]private player player;
    private Vector3 screenBounds;
    private float playerWidth ;
    private float playerHeight;
    private Renderer playerRenderer;
    public void Awake()
    {
         inputActions = new AndroidInput();
        fruitGen = GetComponent<FruitGen>();
    }
    private void OnEnable()
    {
        inputActions.Enable();
    }
    public void OnDisable()
    {
        inputActions.Disable();
    }
    //public void Start()
    //{
    //    inputActions.Move.touchpress.started += ctx => Startouch(ctx);
    //    inputActions.Move.touchpress.canceled += ctx => Endtouch(ctx);
    //}

    //private void Endtouch(InputAction.CallbackContext ctx)
    //{
    //    Debug.Log("untouched ");
    //    if (player.Heldfruit != null) 
    //    { 
    //    Dropfruit();
    //     }
    //}

    //private void Startouch(InputAction.CallbackContext ctx)
    //{
    //    Debug.Log("touched ");

    //}
    public void Start()
    {
        Camera mainCamera = Camera.main;
        screenBounds = mainCamera.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, mainCamera.transform.position.z));
        playerRenderer = player.Heldfruit.GetComponent<Renderer>();
    }
    public void Dropfruit()
    {
        player.Heldfruit.GetComponent<Rigidbody2D>().simulated = true;
        player.Heldfruit.transform.SetParent(null);
        player.Heldfruit = null;
        StartCoroutine(fruitGen.Genfruit());
    }
    public void Update()
    {
        if(Input.touchCount > 0)
        {
           Touch touch = Input.GetTouch(0);
            if(touch.phase == UnityEngine.TouchPhase.Began )
            {
                Debug.Log("began touch");
                //touch.phase == UnityEngine.TouchPhase.Stationary
               // Vector2 touchPos = touch.position;
                Vector3 worldPosition = Camera.main.ScreenToWorldPoint(new Vector3(touch.position.x, 5f, 0f));
                player.transform.position = new Vector3(worldPosition.x, 5f, 0f);
                if (player.Heldfruit != null)
                {
                    playerWidth = playerRenderer.bounds.extents.x; // Half the width
                    playerHeight = playerRenderer.bounds.extents.y; // Half the height
                }
                player.transform.position = ClampToScreenBounds(new Vector3(worldPosition.x, 5f, 0f));
            }
            if (touch.phase == UnityEngine.TouchPhase.Moved)
            {
                Debug.Log("began moving");
                Vector2 deltaposition = touch.deltaPosition;

                // move the player based on the delta
                Vector3 move = new Vector3(deltaposition.x, 0, 0) * Time.deltaTime;

                player.transform.position = ClampToScreenBounds(player.transform.position + move);
            }
            if (touch.phase == UnityEngine.TouchPhase.Ended || touch.phase == UnityEngine.TouchPhase.Canceled)
                {
                    Debug.Log("end touch");
                if ( player.Heldfruit != null ) {Dropfruit(); }
                    
                }
        }
    }

    private Vector3 ClampToScreenBounds(Vector3 position)
    {
        float clampedX = Mathf.Clamp(position.x, screenBounds.x * -1 + playerWidth, screenBounds.x - playerWidth);
        float clampedY = Mathf.Clamp(position.y, screenBounds.y * -1 + playerHeight, screenBounds.y - playerHeight);
        return new Vector3(clampedX, clampedY, position.z);
    }
}
