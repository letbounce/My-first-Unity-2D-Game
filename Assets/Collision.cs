using UnityEngine;

public class Collision : MonoBehaviour
{
    void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("Collision detected");
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Trigger detected");
    }
}
