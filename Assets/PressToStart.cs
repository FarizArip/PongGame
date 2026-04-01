using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class NewMonoBehaviourScript : MonoBehaviour
{
    public InputAction StartPlay;
    private Rigidbody2D rb;
    private bool keyPressed = false;
    private Vector2 random;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        random = UnityEngine.Random.insideUnitCircle.normalized;
        StartPlay.Enable();
    }

    // Update is called once per frame
    void Update()
    {
        float start = StartPlay.ReadValue<float>();
        if (!keyPressed && start > 0.5f)
        {
            keyPressed = true;
        }
    }

    void FixedUpdate()
    {
        if (keyPressed)
        {
            Vector2 position = rb.position + random * 2f * Time.deltaTime;
            rb.MovePosition(position);
        }
    }

    void OnCollisionEnter2D(Collision2D col) {
        var speed = random.magnitude;
        var direction = Vector2.Reflect(random.normalized, col.contacts[0].normal);
        rb.linearVelocity = direction * Mathf.Max(speed, 0f);
    }   
}
