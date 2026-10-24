using UnityEngine;
using UnityEngine.InputSystem;

public class Driver : MonoBehaviour
{
    [Header("Швидкість руху (Movement)")]
    [SerializeField] float moveSpeed = 0.03f;
    [Tooltip("Швидкість набору швидкості")]
    [SerializeField] float acceleration = 2.5f;
    [Tooltip("Швидкість гальмування при зміні напрямку")]
    [SerializeField] float deceleration = 4f;
    [Tooltip("Швидкість накату (сповільнення, коли відпущено клавіші)")]
    [SerializeField] float coastDeceleration = 1.5f;

    [Header("Кермування (Steering)")]
    [SerializeField] float steerSpeed = 0.55f;
    [Tooltip("Швидкість повертання керма")]
    [SerializeField] float steerTurnSpeed = 4f;
    [Tooltip("Швидкість повернення керма у центр")]
    [SerializeField] float steerReturnSpeed = 6f;

    [Header("Додатково")]
    [Tooltip("Чи повертати машину тільки під час руху")]
    [SerializeField] bool rotateOnlyWhileMoving = false;

    float currentMove = 0f;
    float currentSteer = 0f;

    void Update()
    {
        if (Keyboard.current == null) return;

        // 1. Отримання вхідного сигналу для руху (W / S)
        float targetMove = 0f;
        if (Keyboard.current.wKey.isPressed) targetMove += 1f;
        if (Keyboard.current.sKey.isPressed) targetMove -= 1f;

        // 2. Плавний розгін, гальмування та вільний накат
        float moveRate;
        if (targetMove == 0f)
        {
            moveRate = coastDeceleration;
        }
        else if (currentMove != 0f && Mathf.Sign(targetMove) != Mathf.Sign(currentMove))
        {
            moveRate = deceleration; // швидке гальмування при зміні напрямку
        }
        else
        {
            moveRate = acceleration; // плавний розгін
        }

        currentMove = Mathf.MoveTowards(currentMove, targetMove, moveRate * Time.deltaTime);

        // 3. Отримання вхідного сигналу для керма (A / D)
        float targetSteer = 0f;
        if (Keyboard.current.aKey.isPressed) targetSteer += 1f;
        if (Keyboard.current.dKey.isPressed) targetSteer -= 1f;

        // 4. Плавний поворот керма та повернення в нульове положення
        float steerRate = (targetSteer != 0f) ? steerTurnSpeed : steerReturnSpeed;
        currentSteer = Mathf.MoveTowards(currentSteer, targetSteer, steerRate * Time.deltaTime);

        // 5. Інверсія кермування при русі назад
        float steerFactor = currentSteer;
        if (currentMove < -0.01f)
        {
            steerFactor *= -1f;
        }

        // Опціонально: поворот тільки під час руху
        if (rotateOnlyWhileMoving)
        {
            steerFactor *= Mathf.Abs(currentMove);
        }

        // 6. Застосування переміщення та повороту
        transform.Translate(0, currentMove * moveSpeed, 0);
        transform.Rotate(0, 0, steerFactor * steerSpeed);
    }
}
