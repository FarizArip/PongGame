using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class Musuh : MonoBehaviour
{
    public float speed = 1f;
    private Rigidbody2D rb;
    public Transform targetObject;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        if (targetObject != null)
        {
            Vector2 newPosition = transform.position;

            newPosition.y = targetObject.position.y;

            Vector2 position = rb.position + newPosition * speed * Time.deltaTime;
            rb.MovePosition(position);
        }
    } 
}
