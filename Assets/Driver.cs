using UnityEngine;
using UnityEngine.InputSystem;

public class Driver : MonoBehaviour
{
    [SerializeField] float moveSpeed = 0.03f;
    [SerializeField] float steerSpeed = 0.55f;
    
    

    void Update()
    {
        float move = 0f;
        float steer = 0f;
        
        if (Keyboard.current.wKey.isPressed)
        {
            move = 1f;
        }
        else if (Keyboard.current.sKey.isPressed)
        {
            move = -1f;
        }
        if (Keyboard.current.aKey.isPressed)
        {
            steer = 1f;
        }
        else if (Keyboard.current.dKey.isPressed)
        {
            steer = -1f;    
            
        } 
        
        if (move < 0f)
        {
            steer *= -1f;
        }
        

        transform.Translate(0, move * moveSpeed, 0);
        transform.Rotate(0, 0, steer * steerSpeed);

    }
}

