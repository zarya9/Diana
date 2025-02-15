using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float speed = 5f;

    public float minX = -5f;
    public float maxX = 5f;
    public float minY = -3f;
    public float maxY = 2f;

    private bool flip = false;

    public SpriteRenderer sprite;

    // Update is called once per frame
    void Update()
    {
        

        if (Input.GetKey(KeyCode.Q)) // Влево-вверх
        {
            Move(Vector2.left + Vector2.up);
            FlipCharacter(true);
        }
        if (Input.GetKey(KeyCode.A)) // Влево-вниз
        {
            Move(Vector2.left - Vector2.up);
            FlipCharacter(true);
        }
        if (Input.GetKey(KeyCode.E)) // Вправо-вверх
        {
            Move(Vector2.right + Vector2.up);
            FlipCharacter(false);
        }
        if (Input.GetKey(KeyCode.D)) // Вправо-вниз
        {
            Move(Vector2.right - Vector2.up);
            FlipCharacter(false);
        }
        ClampPosition();

    }

    private void Move(Vector2 direction)
    {
        direction.Normalize();

        transform.Translate(direction * speed * Time.deltaTime);
    }
    private void ClampPosition()
    {
        Vector3 clampedPosition = transform.position;

        clampedPosition.x = Mathf.Clamp(clampedPosition.x, minX, maxX);

        clampedPosition.y = Mathf.Clamp(clampedPosition.y, minY, maxY);

        transform.position = clampedPosition;
    }
    private void FlipCharacter(bool faceRight)
    {
        Vector2 localScale = transform.localScale;
        if (faceRight && localScale.x < 0)  
        {
            localScale.x = -localScale.x;
        }
        else if (!faceRight && localScale.x > 0)
        {
            localScale.x = -localScale.x;
        }
        transform.localScale = localScale;
    }

}
