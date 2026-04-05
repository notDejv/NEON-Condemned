using UnityEngine;
using UnityEngine.InputSystem;

public class CubeMovement : MonoBehaviour
{
    public float speed = 5f;

    private Vector2 _moveInput;
    private Vector2 _lastTouchPosition;

    void Update()
    {
        _moveInput = Vector2.zero;

        // Keyboard (WASD) for editor testing
        Keyboard kb = Keyboard.current;
        if (kb != null)
        {
            if (kb.wKey.isPressed) _moveInput.y -= 1f;
            if (kb.sKey.isPressed) _moveInput.y += 1f;
            if (kb.aKey.isPressed) _moveInput.x += 1f;
            if (kb.dKey.isPressed) _moveInput.x -= 1f;
        }

        // Touch input (single finger drag)
        Touchscreen touch = Touchscreen.current;
        if (touch != null && touch.primaryTouch.press.isPressed)
        {
            Vector2 delta = touch.primaryTouch.delta.ReadValue();
            _moveInput = delta.normalized;
        }

        Vector3 move = new Vector3(_moveInput.x, 0f, _moveInput.y);
        transform.Translate(move * speed * Time.deltaTime, Space.World);
    }
}
