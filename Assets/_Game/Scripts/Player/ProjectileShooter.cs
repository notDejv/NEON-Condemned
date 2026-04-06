using UnityEngine;
using UnityEngine.InputSystem;

public class ProjectileShooter : MonoBehaviour
{
    public GameObject projectilePrefab;
    public float fireRate = 0.5f;

    private float _nextFireTime;

    void Update()
    {
        bool fired = false;

        // Left mouse click for editor testing
        Mouse mouse = Mouse.current;
        if (mouse != null && mouse.leftButton.wasPressedThisFrame)
            fired = true;

        // Screen tap for mobile
        Touchscreen touch = Touchscreen.current;
        if (touch != null && touch.primaryTouch.press.wasPressedThisFrame)
            fired = true;

        if (fired && Time.time >= _nextFireTime)
        {
            Shoot();
            _nextFireTime = Time.time + fireRate;
        }
    }

    void Shoot()
    {
        if (projectilePrefab == null) return;
        Instantiate(projectilePrefab, transform.position + transform.forward, transform.rotation);
    }
}
