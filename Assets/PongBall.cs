using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class PongBall : MonoBehaviour
{
    //public InputAction StartPlay;
    Rigidbody2D rb;
    //private bool keyPressed = false;
    Vector2 direction = Vector2.zero;
    float speed = 5f;
    float force = 100f;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        //random = UnityEngine.Random.insideUnitCircle.normalized;
        //StartPlay.Enable();
    }

    void OnEnable()
    {
        if (rb == null)
        {
            rb = GetComponent<Rigidbody2D>();
        }
        ThrowBall();
    }

    private Vector2 GenerateRandomDirection()
    {
        float[,] degrees = {{-60f, 60f}, {120f, 240f}};
        float chooseDirec = Random.Range(0, degrees.GetLength(0));
        float minDeg = degrees[(int)chooseDirec, 0];
        float maxDeg = degrees[(int)chooseDirec, 1];
        float randomValue = Random.Range(minDeg, maxDeg) * Mathf.Deg2Rad;
        return new Vector2(Mathf.Cos(randomValue), Mathf.Sin(randomValue));
    }

    void ThrowBall()
    {
        // Put the ball on random position in the center, then
        // push it to random direction
        rb.AddForce(GenerateRandomDirection() * speed * force);
        rb.linearVelocity = rb.linearVelocity.normalized * speed;
    }

    // Update is called once per frame
    // void Update()
    // {
    //     float start = StartPlay.ReadValue<float>();
    //     if (!keyPressed && start > 0.5f)
    //     {
    //         keyPressed = true;
    //     }
    // }

    // void FixedUpdate()
    // {
    //      if (keyPressed)
    //      {
    //          Vector2 position = rb.position + random * 2f * Time.deltaTime;
    //          rb.MovePosition(position);
    //      }
    // }

    // void OnCollisionEnter2D(Collision2D col) {
    //     var speed = random.magnitude;
    //     var direction = Vector2.Reflect(random.normalized, col.contacts[0].normal);
    //     rb.linearVelocity = direction * Mathf.Max(speed, 0f);
    // }   
}
