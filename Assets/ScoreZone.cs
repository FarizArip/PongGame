using Unity.VisualScripting;
using UnityEngine;

public class ScoreZone : MonoBehaviour
{
    GameManager manager;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void Start()
    {
        manager = FindAnyObjectByType<GameManager>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<PongBall>() != null) {
            if (tag == "PlayerZone")
            {
                manager.opponentWin.Invoke();
            } else if (tag == "OpponentZone")
            {
                manager.playerWin.Invoke();
            }
        }
    }
}