using UnityEngine;

public class Delivery : MonoBehaviour
{

    bool hasPackage;

    void OnTriggerEnter2D(Collider2D collision)
    {
        // if (the tag is package)
        // then (print picked up package to console)
        if (collision.gameObject.CompareTag("Package"))
        {
            Debug.Log("Picked up package");
            hasPackage = true;
        }
        if (collision.gameObject.CompareTag("Customer") && hasPackage)
        {
            Debug.Log("Delivered package to customer");
            hasPackage = false;
        }

    }

    
}
