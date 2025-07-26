using System.Collections;
using UnityEngine;

public class Player : MonoBehaviour
{
    [Header("Attributes")]
    [SerializeField] private int life;
    [SerializeField] private int force;
    [SerializeField] private int armor;
    [SerializeField] private int speed;
    // [SerializeField] private Vector2 lastDirection;

    [Header("State")]
    [SerializeField] private bool walking;

    [Header("Anim Attrib")]
    [SerializeField] private float walkingTime;


    void Update()
    {
        Move();
    }

    public void Move()
    {
        if (walking) return;

        if (Input.GetKeyDown(KeyCode.W)) StartCoroutine(MoveEnum(Vector2.up));
        else if (Input.GetKeyDown(KeyCode.S)) StartCoroutine(MoveEnum(Vector2.down));
        else if (Input.GetKeyDown(KeyCode.A)) StartCoroutine(MoveEnum(Vector2.left));
        else if (Input.GetKeyDown(KeyCode.D)) StartCoroutine(MoveEnum(Vector2.right));
    }

    public IEnumerator MoveEnum(Vector2 dir)
    {
        walking = true;

        float elapsed = 0.0f;
        Vector2 initialPosition = (Vector2) transform.position;
        Vector2 finalPosition = (Vector2)(transform.position + (Vector3) dir);

        while (elapsed < walkingTime)
        {
            yield return null;
            elapsed += Time.deltaTime;
            transform.position = Vector3.Lerp(
                (Vector3)initialPosition,
                (Vector3)finalPosition,
                elapsed / walkingTime);
        }
        transform.position = (Vector3) finalPosition;
        // lastDirection = dir;
        walking = false;
    }
}
