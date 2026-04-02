using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class NPCOpponent : MonoBehaviour
{
    float speed = 5f;
    Rigidbody2D rb;
    PongBall ball;
    Vector3 ballPosition;
    [SerializeField] float minSpeed = 0.5f;
    [SerializeField] float maxSpeed = 10f;
    //public Transform targetObject;

    void Start()
    {
        ball = FindAnyObjectByType<PongBall>();
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (ball == null)
        {
            ball = GameObject.FindAnyObjectByType<PongBall>();
        }
    }

    void FixedUpdate()
    {
        speed = Random.Range(minSpeed, maxSpeed);
        if (ball != null)
        {
            ballPosition = ball.transform.position;

            rb.transform.position = Vector3.Lerp(transform.position, new Vector3(transform.position.x, ballPosition.y, 0), Time.fixedDeltaTime * speed);
        }
        // if (targetObject != null)
        // {
        //     Vector2 newPosition = transform.position;

        //     newPosition.y = targetObject.position.y;

        //     Vector2 position = rb.position + newPosition * speed * Time.deltaTime;
        //     rb.MovePosition(position);
        // }
    } 
}
