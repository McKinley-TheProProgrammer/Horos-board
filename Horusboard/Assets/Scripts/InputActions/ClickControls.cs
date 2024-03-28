//------------------------------------------------------------------------------
// <auto-generated>
//     This code was auto-generated by com.unity.inputsystem:InputActionCodeGenerator
//     version 1.7.0
//     from Assets/Scripts/InputActions/ClickControls.inputactions
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public partial class @ClickControls: IInputActionCollection2, IDisposable
{
    public InputActionAsset asset { get; }
    public @ClickControls()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""ClickControls"",
    ""maps"": [
        {
            ""name"": ""Cursor"",
            ""id"": ""b23f51bf-07a7-4206-ac6a-16ea694d24f2"",
            ""actions"": [
                {
                    ""name"": ""Click"",
                    ""type"": ""PassThrough"",
                    ""id"": ""416ac138-81b0-4293-97aa-5736eb57a560"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Holding"",
                    ""type"": ""PassThrough"",
                    ""id"": ""9e447978-ef97-414e-94d3-3329c18c7cc2"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""ClickPosition"",
                    ""type"": ""Value"",
                    ""id"": ""04a31070-c9f2-4159-930e-c40ee12402fd"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""5fad052b-7fda-4e5d-9654-e4c1ac38f6da"",
                    ""path"": ""<Touchscreen>/primaryTouch/press"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Click"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""81233b82-6bb1-4cb1-9f22-de761b852efc"",
                    ""path"": ""<Mouse>/leftButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Click"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""de6b627a-20a8-4bbd-b5bd-20ec5de288b5"",
                    ""path"": ""<Touchscreen>/primaryTouch/press"",
                    ""interactions"": ""Hold"",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Holding"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""446a19c4-dfa1-43de-b847-ebc3e29753ee"",
                    ""path"": ""<Mouse>/leftButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Holding"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""aee3ebe6-e9d1-46fa-8bca-a7cfc8a91cff"",
                    ""path"": ""<Touchscreen>/touch0/position"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""ClickPosition"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""9d1e0368-44b4-41ed-bf67-cf58db06b9f8"",
                    ""path"": ""<Mouse>/position"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""ClickPosition"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // Cursor
        m_Cursor = asset.FindActionMap("Cursor", throwIfNotFound: true);
        m_Cursor_Click = m_Cursor.FindAction("Click", throwIfNotFound: true);
        m_Cursor_Holding = m_Cursor.FindAction("Holding", throwIfNotFound: true);
        m_Cursor_ClickPosition = m_Cursor.FindAction("ClickPosition", throwIfNotFound: true);
    }

    public void Dispose()
    {
        UnityEngine.Object.Destroy(asset);
    }

    public InputBinding? bindingMask
    {
        get => asset.bindingMask;
        set => asset.bindingMask = value;
    }

    public ReadOnlyArray<InputDevice>? devices
    {
        get => asset.devices;
        set => asset.devices = value;
    }

    public ReadOnlyArray<InputControlScheme> controlSchemes => asset.controlSchemes;

    public bool Contains(InputAction action)
    {
        return asset.Contains(action);
    }

    public IEnumerator<InputAction> GetEnumerator()
    {
        return asset.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }

    public void Enable()
    {
        asset.Enable();
    }

    public void Disable()
    {
        asset.Disable();
    }

    public IEnumerable<InputBinding> bindings => asset.bindings;

    public InputAction FindAction(string actionNameOrId, bool throwIfNotFound = false)
    {
        return asset.FindAction(actionNameOrId, throwIfNotFound);
    }

    public int FindBinding(InputBinding bindingMask, out InputAction action)
    {
        return asset.FindBinding(bindingMask, out action);
    }

    // Cursor
    private readonly InputActionMap m_Cursor;
    private List<ICursorActions> m_CursorActionsCallbackInterfaces = new List<ICursorActions>();
    private readonly InputAction m_Cursor_Click;
    private readonly InputAction m_Cursor_Holding;
    private readonly InputAction m_Cursor_ClickPosition;
    public struct CursorActions
    {
        private @ClickControls m_Wrapper;
        public CursorActions(@ClickControls wrapper) { m_Wrapper = wrapper; }
        public InputAction @Click => m_Wrapper.m_Cursor_Click;
        public InputAction @Holding => m_Wrapper.m_Cursor_Holding;
        public InputAction @ClickPosition => m_Wrapper.m_Cursor_ClickPosition;
        public InputActionMap Get() { return m_Wrapper.m_Cursor; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(CursorActions set) { return set.Get(); }
        public void AddCallbacks(ICursorActions instance)
        {
            if (instance == null || m_Wrapper.m_CursorActionsCallbackInterfaces.Contains(instance)) return;
            m_Wrapper.m_CursorActionsCallbackInterfaces.Add(instance);
            @Click.started += instance.OnClick;
            @Click.performed += instance.OnClick;
            @Click.canceled += instance.OnClick;
            @Holding.started += instance.OnHolding;
            @Holding.performed += instance.OnHolding;
            @Holding.canceled += instance.OnHolding;
            @ClickPosition.started += instance.OnClickPosition;
            @ClickPosition.performed += instance.OnClickPosition;
            @ClickPosition.canceled += instance.OnClickPosition;
        }

        private void UnregisterCallbacks(ICursorActions instance)
        {
            @Click.started -= instance.OnClick;
            @Click.performed -= instance.OnClick;
            @Click.canceled -= instance.OnClick;
            @Holding.started -= instance.OnHolding;
            @Holding.performed -= instance.OnHolding;
            @Holding.canceled -= instance.OnHolding;
            @ClickPosition.started -= instance.OnClickPosition;
            @ClickPosition.performed -= instance.OnClickPosition;
            @ClickPosition.canceled -= instance.OnClickPosition;
        }

        public void RemoveCallbacks(ICursorActions instance)
        {
            if (m_Wrapper.m_CursorActionsCallbackInterfaces.Remove(instance))
                UnregisterCallbacks(instance);
        }

        public void SetCallbacks(ICursorActions instance)
        {
            foreach (var item in m_Wrapper.m_CursorActionsCallbackInterfaces)
                UnregisterCallbacks(item);
            m_Wrapper.m_CursorActionsCallbackInterfaces.Clear();
            AddCallbacks(instance);
        }
    }
    public CursorActions @Cursor => new CursorActions(this);
    public interface ICursorActions
    {
        void OnClick(InputAction.CallbackContext context);
        void OnHolding(InputAction.CallbackContext context);
        void OnClickPosition(InputAction.CallbackContext context);
    }
}
