using System;
using System.Collections;
using System.Collections.Generic;
using UnityAtoms.BaseAtoms;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager : Singleton<InputManager>
{
    public ClickControls clickControls { get; private set; }

    public ClickControls.CursorActions cursorActions;
    
    [SerializeField]
    public Vector2Reference cursorPosition;
    
    [SerializeField]
    private Camera mainCamera;

    public event Action<Vector2> OnStartClick, OnEndClick;

    public bool debugMode;
    protected void Awake()
    {
        clickControls = new ClickControls();
    }
    
    private void OnEnable()
    {
        clickControls.Enable();
    }

    private void OnDisable()
    {
        clickControls.Disable();
    }

    private void Start()
    {
        mainCamera = GameObject.FindWithTag("MainCamera").GetComponent<Camera>();
        
        cursorActions = clickControls.Cursor;
        
        cursorActions.Click.started += PrimaryStartClick;
        cursorActions.Click.canceled += PrimaryEndClick;
    }
    
    private void Update()
    {
        cursorPosition.Value = CamUtils.ScreenToWorldCustom(mainCamera,cursorActions.ClickPosition.ReadValue<Vector2>());
        
        if(debugMode)
            Debug.Log($"{cursorPosition.Value}");
    }

    void PrimaryStartClick(InputAction.CallbackContext ctx)
    {
        OnStartClick?.Invoke(cursorPosition.Value);
        
        if(debugMode)
            Debug.Log($"Start Clicked on {cursorPosition.Value}");
    }

    void PrimaryEndClick(InputAction.CallbackContext ctx)
    {
        OnEndClick?.Invoke(cursorPosition.Value);
        
        if(debugMode)
            Debug.Log($"End Clicked on {cursorPosition.Value}");
    }
    
    
}
