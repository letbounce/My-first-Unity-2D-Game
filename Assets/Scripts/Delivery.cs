using UnityEngine;

public class Delivery : MonoBehaviour
{

    bool hasPackage;
    [SerializeField] float destroyDelay = 0.25f;

    void OnTriggerEnter2D(Collider2D collision)
    {
        // if (the tag is package)
        // then (print picked up package to console)
        if (collision.gameObject.CompareTag("Package") && !hasPackage)
        {
            Debug.Log("Picked up package");
            hasPackage = true;
            Destroy(collision.gameObject, destroyDelay);
        }
        if (collision.gameObject.CompareTag("Customer") && hasPackage)
        {
            Debug.Log("Delivered package to customer");
            hasPackage = false;
        }

    }

    
}
