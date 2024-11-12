using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager : MonoBehaviour
{
    private AndroidInput inputActions;
    public void Awake()
    {
         inputActions = new AndroidInput();
    }
    private void OnEnable()
    {
        inputActions.Enable();
    }
    public void OnDisable()
    {
        inputActions.Disable();
    }
    public void Start()
    {
        inputActions.Move.touchpress.started += ctx => Startouch(ctx);
        inputActions.Move.touchpress.canceled += ctx => Endtouch(ctx);
    }

    private void Endtouch(InputAction.CallbackContext ctx)
    {
        Debug.Log("untouched ");
    }

    private void Startouch(InputAction.CallbackContext ctx)
    {
        Debug.Log("touched ");
    }
}
