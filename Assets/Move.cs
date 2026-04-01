using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class Move : MonoBehaviour
{
    public float speed = 1f;
    public InputAction MoveAction;
    private Rigidbody2D rb;
    private Vector2 move;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        MoveAction.Enable();
    }

    void Update()
    {
        move = MoveAction.ReadValue<Vector2>();
        Debug.Log(move);
    }

    void FixedUpdate()
    {
        Vector2 position = rb.position + move * speed * Time.deltaTime;
        rb.MovePosition(position);
    } 
}
