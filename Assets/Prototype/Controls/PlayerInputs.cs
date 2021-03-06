//------------------------------------------------------------------------------
// <auto-generated>
//     This code was auto-generated by com.unity.inputsystem:InputActionCodeGenerator
//     version 1.3.0
//     from Assets/Prototype/Controls/PlayerInputs.inputactions
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

public partial class @PlayerInputs : IInputActionCollection2, IDisposable
{
    public InputActionAsset asset { get; }
    public @PlayerInputs()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""PlayerInputs"",
    ""maps"": [
        {
            ""name"": ""Land"",
            ""id"": ""5bc1e13d-61c6-42c1-8cdc-71af7a1e5e66"",
            ""actions"": [
                {
                    ""name"": ""Move"",
                    ""type"": ""Value"",
                    ""id"": ""d42f1ba1-b846-4ee4-841a-7f5d09245d00"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                },
                {
                    ""name"": ""Interact"",
                    ""type"": ""Button"",
                    ""id"": ""f6725619-45c4-4f19-a573-61dc0fe6f634"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Dash"",
                    ""type"": ""Button"",
                    ""id"": ""dc6375fd-77ec-4b0e-9477-bac447e72a2a"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Attack"",
                    ""type"": ""Button"",
                    ""id"": ""c7b44490-6147-4185-8a3c-fa51c8d12272"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Inventory"",
                    ""type"": ""Button"",
                    ""id"": ""a0bea0b9-227c-43a0-889d-72c9c9865d7e"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""MenuRight"",
                    ""type"": ""Button"",
                    ""id"": ""ec9edb23-6618-432a-8b3e-c48b083f919a"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""MenuLeft"",
                    ""type"": ""Button"",
                    ""id"": ""b897dcb4-4931-44b1-b1ac-19af5f64a7cf"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""NextPage"",
                    ""type"": ""Button"",
                    ""id"": ""d517c24d-369b-402f-8b43-b0cb3914c773"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""PreviousPage"",
                    ""type"": ""Button"",
                    ""id"": ""9a749e0c-9aad-4132-a42b-10061845b3ef"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                }
            ],
            ""bindings"": [
                {
                    ""name"": ""WASD"",
                    ""id"": ""b615ab23-6127-49b9-bf6c-52ee9ffabde5"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""2a9e2049-678d-4a75-a171-2c4fdb0c160d"",
                    ""path"": ""<Keyboard>/z"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Desktop"",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""576fc125-e5ba-413d-943e-a01f83a08646"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Desktop"",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""60570bbf-b9d3-4f92-8934-0c8d9c06d950"",
                    ""path"": ""<Keyboard>/q"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Desktop"",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""54c34162-10b4-44f2-ba2c-5686b38becf7"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Desktop"",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""Arrows"",
                    ""id"": ""4d30888f-0886-4f19-8475-36438abb2395"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""1fb65f86-a0da-40ec-88bd-7fdc6929124e"",
                    ""path"": ""<Keyboard>/upArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Desktop"",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""5d996611-8ba5-44a3-9cb5-3b89b7df4daa"",
                    ""path"": ""<Keyboard>/downArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Desktop"",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""9eb0fbae-de8f-4cc0-a3c7-d831a638dfd8"",
                    ""path"": ""<Keyboard>/leftArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Desktop"",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""68967238-70a2-4f20-a7e7-a976c4a4367a"",
                    ""path"": ""<Keyboard>/rightArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Desktop"",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""Stick"",
                    ""id"": ""ecb655f2-79c1-48e3-84bb-939ae970e41f"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""b141075c-6972-4853-a058-c9bd25173a50"",
                    ""path"": ""<Gamepad>/leftStick"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Desktop"",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""024be343-b0a8-4377-b52d-d7e65f1f78e4"",
                    ""path"": ""<Gamepad>/buttonSouth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Desktop"",
                    ""action"": ""Interact"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""77619d52-56ad-4d07-a910-4b163ee59dbb"",
                    ""path"": ""<Keyboard>/f"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Desktop"",
                    ""action"": ""Interact"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""b17b456a-c20f-46b1-ba9e-eb7c978c48b5"",
                    ""path"": ""<Keyboard>/space"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Desktop"",
                    ""action"": ""Dash"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""adfb11c7-a9cd-4264-bc55-ac75e3b80b17"",
                    ""path"": ""<Gamepad>/buttonEast"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Desktop"",
                    ""action"": ""Dash"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""94e489e1-7016-4940-8241-5959d290ea92"",
                    ""path"": ""<Gamepad>/buttonWest"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Desktop"",
                    ""action"": ""Attack"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""d950b4e9-352a-44d9-bbd2-84f8ee952c08"",
                    ""path"": ""<Keyboard>/k"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Desktop"",
                    ""action"": ""Attack"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""3e97fbda-1f5e-4a74-aead-2f4146e5dc8c"",
                    ""path"": ""<Keyboard>/i"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Desktop"",
                    ""action"": ""Inventory"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""f41bd923-3494-4930-9baa-949184575242"",
                    ""path"": ""<Gamepad>/select"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Desktop"",
                    ""action"": ""Inventory"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""04bb60d3-fd4c-4d52-989d-8588ce1474c7"",
                    ""path"": ""<Keyboard>/n"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Desktop"",
                    ""action"": ""MenuRight"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""b8e0d3e6-86c0-4110-a59c-79994c1b987e"",
                    ""path"": ""<Gamepad>/rightStick/right"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Desktop"",
                    ""action"": ""MenuRight"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""27124253-4a55-4c9e-860b-28920287e5da"",
                    ""path"": ""<Keyboard>/b"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Desktop"",
                    ""action"": ""MenuLeft"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""4e4d780b-6f8c-4b8e-b9d5-3ca86e95fb63"",
                    ""path"": ""<Gamepad>/rightStick/left"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Desktop"",
                    ""action"": ""MenuLeft"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""a7370f15-523b-486a-94a5-bf715233ca37"",
                    ""path"": ""<Keyboard>/e"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Desktop"",
                    ""action"": ""NextPage"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""a4be0044-a73e-4ac9-8fdd-6540558d21ae"",
                    ""path"": ""<Gamepad>/rightShoulder"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""NextPage"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""4f414601-5ff9-4456-8bbd-c593264bc85c"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Desktop"",
                    ""action"": ""PreviousPage"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""27c667e4-b60a-47c9-afc1-b6d1dbc327f1"",
                    ""path"": ""<Gamepad>/leftShoulder"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""PreviousPage"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": [
        {
            ""name"": ""Desktop"",
            ""bindingGroup"": ""Desktop"",
            ""devices"": [
                {
                    ""devicePath"": ""<Keyboard>"",
                    ""isOptional"": false,
                    ""isOR"": false
                },
                {
                    ""devicePath"": ""<Mouse>"",
                    ""isOptional"": false,
                    ""isOR"": false
                },
                {
                    ""devicePath"": ""<Gamepad>"",
                    ""isOptional"": false,
                    ""isOR"": false
                }
            ]
        }
    ]
}");
        // Land
        m_Land = asset.FindActionMap("Land", throwIfNotFound: true);
        m_Land_Move = m_Land.FindAction("Move", throwIfNotFound: true);
        m_Land_Interact = m_Land.FindAction("Interact", throwIfNotFound: true);
        m_Land_Dash = m_Land.FindAction("Dash", throwIfNotFound: true);
        m_Land_Attack = m_Land.FindAction("Attack", throwIfNotFound: true);
        m_Land_Inventory = m_Land.FindAction("Inventory", throwIfNotFound: true);
        m_Land_MenuRight = m_Land.FindAction("MenuRight", throwIfNotFound: true);
        m_Land_MenuLeft = m_Land.FindAction("MenuLeft", throwIfNotFound: true);
        m_Land_NextPage = m_Land.FindAction("NextPage", throwIfNotFound: true);
        m_Land_PreviousPage = m_Land.FindAction("PreviousPage", throwIfNotFound: true);
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

    // Land
    private readonly InputActionMap m_Land;
    private ILandActions m_LandActionsCallbackInterface;
    private readonly InputAction m_Land_Move;
    private readonly InputAction m_Land_Interact;
    private readonly InputAction m_Land_Dash;
    private readonly InputAction m_Land_Attack;
    private readonly InputAction m_Land_Inventory;
    private readonly InputAction m_Land_MenuRight;
    private readonly InputAction m_Land_MenuLeft;
    private readonly InputAction m_Land_NextPage;
    private readonly InputAction m_Land_PreviousPage;
    public struct LandActions
    {
        private @PlayerInputs m_Wrapper;
        public LandActions(@PlayerInputs wrapper) { m_Wrapper = wrapper; }
        public InputAction @Move => m_Wrapper.m_Land_Move;
        public InputAction @Interact => m_Wrapper.m_Land_Interact;
        public InputAction @Dash => m_Wrapper.m_Land_Dash;
        public InputAction @Attack => m_Wrapper.m_Land_Attack;
        public InputAction @Inventory => m_Wrapper.m_Land_Inventory;
        public InputAction @MenuRight => m_Wrapper.m_Land_MenuRight;
        public InputAction @MenuLeft => m_Wrapper.m_Land_MenuLeft;
        public InputAction @NextPage => m_Wrapper.m_Land_NextPage;
        public InputAction @PreviousPage => m_Wrapper.m_Land_PreviousPage;
        public InputActionMap Get() { return m_Wrapper.m_Land; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(LandActions set) { return set.Get(); }
        public void SetCallbacks(ILandActions instance)
        {
            if (m_Wrapper.m_LandActionsCallbackInterface != null)
            {
                @Move.started -= m_Wrapper.m_LandActionsCallbackInterface.OnMove;
                @Move.performed -= m_Wrapper.m_LandActionsCallbackInterface.OnMove;
                @Move.canceled -= m_Wrapper.m_LandActionsCallbackInterface.OnMove;
                @Interact.started -= m_Wrapper.m_LandActionsCallbackInterface.OnInteract;
                @Interact.performed -= m_Wrapper.m_LandActionsCallbackInterface.OnInteract;
                @Interact.canceled -= m_Wrapper.m_LandActionsCallbackInterface.OnInteract;
                @Dash.started -= m_Wrapper.m_LandActionsCallbackInterface.OnDash;
                @Dash.performed -= m_Wrapper.m_LandActionsCallbackInterface.OnDash;
                @Dash.canceled -= m_Wrapper.m_LandActionsCallbackInterface.OnDash;
                @Attack.started -= m_Wrapper.m_LandActionsCallbackInterface.OnAttack;
                @Attack.performed -= m_Wrapper.m_LandActionsCallbackInterface.OnAttack;
                @Attack.canceled -= m_Wrapper.m_LandActionsCallbackInterface.OnAttack;
                @Inventory.started -= m_Wrapper.m_LandActionsCallbackInterface.OnInventory;
                @Inventory.performed -= m_Wrapper.m_LandActionsCallbackInterface.OnInventory;
                @Inventory.canceled -= m_Wrapper.m_LandActionsCallbackInterface.OnInventory;
                @MenuRight.started -= m_Wrapper.m_LandActionsCallbackInterface.OnMenuRight;
                @MenuRight.performed -= m_Wrapper.m_LandActionsCallbackInterface.OnMenuRight;
                @MenuRight.canceled -= m_Wrapper.m_LandActionsCallbackInterface.OnMenuRight;
                @MenuLeft.started -= m_Wrapper.m_LandActionsCallbackInterface.OnMenuLeft;
                @MenuLeft.performed -= m_Wrapper.m_LandActionsCallbackInterface.OnMenuLeft;
                @MenuLeft.canceled -= m_Wrapper.m_LandActionsCallbackInterface.OnMenuLeft;
                @NextPage.started -= m_Wrapper.m_LandActionsCallbackInterface.OnNextPage;
                @NextPage.performed -= m_Wrapper.m_LandActionsCallbackInterface.OnNextPage;
                @NextPage.canceled -= m_Wrapper.m_LandActionsCallbackInterface.OnNextPage;
                @PreviousPage.started -= m_Wrapper.m_LandActionsCallbackInterface.OnPreviousPage;
                @PreviousPage.performed -= m_Wrapper.m_LandActionsCallbackInterface.OnPreviousPage;
                @PreviousPage.canceled -= m_Wrapper.m_LandActionsCallbackInterface.OnPreviousPage;
            }
            m_Wrapper.m_LandActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Move.started += instance.OnMove;
                @Move.performed += instance.OnMove;
                @Move.canceled += instance.OnMove;
                @Interact.started += instance.OnInteract;
                @Interact.performed += instance.OnInteract;
                @Interact.canceled += instance.OnInteract;
                @Dash.started += instance.OnDash;
                @Dash.performed += instance.OnDash;
                @Dash.canceled += instance.OnDash;
                @Attack.started += instance.OnAttack;
                @Attack.performed += instance.OnAttack;
                @Attack.canceled += instance.OnAttack;
                @Inventory.started += instance.OnInventory;
                @Inventory.performed += instance.OnInventory;
                @Inventory.canceled += instance.OnInventory;
                @MenuRight.started += instance.OnMenuRight;
                @MenuRight.performed += instance.OnMenuRight;
                @MenuRight.canceled += instance.OnMenuRight;
                @MenuLeft.started += instance.OnMenuLeft;
                @MenuLeft.performed += instance.OnMenuLeft;
                @MenuLeft.canceled += instance.OnMenuLeft;
                @NextPage.started += instance.OnNextPage;
                @NextPage.performed += instance.OnNextPage;
                @NextPage.canceled += instance.OnNextPage;
                @PreviousPage.started += instance.OnPreviousPage;
                @PreviousPage.performed += instance.OnPreviousPage;
                @PreviousPage.canceled += instance.OnPreviousPage;
            }
        }
    }
    public LandActions @Land => new LandActions(this);
    private int m_DesktopSchemeIndex = -1;
    public InputControlScheme DesktopScheme
    {
        get
        {
            if (m_DesktopSchemeIndex == -1) m_DesktopSchemeIndex = asset.FindControlSchemeIndex("Desktop");
            return asset.controlSchemes[m_DesktopSchemeIndex];
        }
    }
    public interface ILandActions
    {
        void OnMove(InputAction.CallbackContext context);
        void OnInteract(InputAction.CallbackContext context);
        void OnDash(InputAction.CallbackContext context);
        void OnAttack(InputAction.CallbackContext context);
        void OnInventory(InputAction.CallbackContext context);
        void OnMenuRight(InputAction.CallbackContext context);
        void OnMenuLeft(InputAction.CallbackContext context);
        void OnNextPage(InputAction.CallbackContext context);
        void OnPreviousPage(InputAction.CallbackContext context);
    }
}
