using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInput : MonoBehaviour
{
    private SnakeControls _controls;
    private Vector2 _moveInput;

    public Vector2 MoveInput => _moveInput;

    private void Awake()
    {
        _controls = new SnakeControls();
    }

    private void OnEnable()
    {
        _controls.Enable();
        _controls.Player.Move.performed += OnMove;
        _controls.Player.Move.canceled += OnMove;
    }

    private void OnDisable()
    {
        _controls.Disable();
        _controls.Player.Move.performed -= OnMove;
        _controls.Player.Move.canceled -= OnMove;
    }

    private void OnMove(InputAction.CallbackContext context)
    {
        _moveInput = context.ReadValue<Vector2>();
    }
}
