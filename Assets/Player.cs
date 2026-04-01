using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    // awalnya saya coba menggunakan langsung Input System Package, izinkan saya comment-out bagian-bagiannya agar berkemungkinan untuk dipakai lgi
    float speed = 5f;
    //public InputAction MoveAction;
    Rigidbody2D rb;
    Vector2 move;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        //MoveAction.Enable();
    }

    void Update()
    {
        //move = MoveAction.ReadValue<Vector2>();
        //Debug.Log(move);
        move = new Vector2(0, Input.GetAxis("Vertical"));
    }

    void FixedUpdate()
    {
        //Vector2 position = rb.position + move * speed * Time.deltaTime;
        //rb.MovePosition(position);
        rb.transform.position += (Vector3) move * speed * Time.fixedDeltaTime;
    } 
}
