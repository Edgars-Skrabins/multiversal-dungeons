using MultiversalDungeons.Utilities;
using Unity.Plastic.Newtonsoft.Json.Serialization;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager : Singleton<InputManager>
{
    private InputActions m_inputActions;

    // Input events
    public event Action OnShootPerformed;
    public event Action OnInteractPerformed;

    // Input actions
    private InputAction m_playerMovementIA;
    private InputAction m_playerShootIA;
    private InputAction m_playerInteractIA;

    protected override void Awake()
    {
        base.Awake();
        InitializeInputActions();
        InitializeInputEvents();
        HideMouse();
    }

    public void HideMouse()
    {
        Cursor.visible = false;
    }

    public void ShowMouse()
    {
        Cursor.visible = true;
    }

    private void InitializeInputActions()
    {
        m_inputActions = new InputActions();

        m_playerMovementIA = m_inputActions.Player.Movement;
        m_playerMovementIA.Enable();

        m_playerShootIA = m_inputActions.Player.Shoot;
        m_playerShootIA.Enable();

        m_playerInteractIA = m_inputActions.Player.Interact;
        m_playerInteractIA.Enable();
    }

    private void InitializeInputEvents()
    {
        m_playerShootIA.performed += Shoot_Action;
        m_playerInteractIA.performed += Interact_Action;
    }

    private void Shoot_Action(InputAction.CallbackContext _inputCtx)
    {
        switch (_inputCtx.phase)
        {
            case InputActionPhase.Performed:
                OnShootPerformed?.Invoke();
                break;
            default: return;
        }

    }

    private void Interact_Action(InputAction.CallbackContext _inputCtx)
    {
        switch (_inputCtx.phase)
        {
            case InputActionPhase.Performed:
                OnInteractPerformed?.Invoke();
                break;
            default: return;
        }
    }

    public Vector3 GetWorldMousePosition()
    {
        Vector3 worldMousePosition = Utilities.GameCamera.ScreenToWorldPoint(Input.mousePosition);
        return worldMousePosition;
    }

    public Vector2 GetMovementVector2Normalized()
    {
        Vector2 movement = m_playerMovementIA.ReadValue<Vector2>();
        return movement;
    }
}