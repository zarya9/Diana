using UnityEngine;

public class GenaController2D : MonoBehaviour
{
    public float speed = 3f; // Скорость движения
    private GameObject[] oranges; // Массив апельсинов
    private GameObject targetOrange; // Ближайший апельсин

    // Границы перемещения
    public float minX = -5f;
    public float maxX = 5f;
    public float minY = -3f;
    public float maxY = 2f;

    private SpriteRenderer spriteRenderer; // Компонент для отражения спрайта

    void Start()
    {
        // Получаем компонент SpriteRenderer
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        FindClosestOrange();
        if (targetOrange != null)
        {
            MoveTowardsOrange();
        }

        LimitMovement();
    }

    void FindClosestOrange()
    {
        oranges = GameObject.FindGameObjectsWithTag("Orange"); // Находим все апельсины по тегу
        float closestDistance = Mathf.Infinity;
        targetOrange = null;

        foreach (GameObject orange in oranges)
        {
            float distance = Vector2.Distance(transform.position, orange.transform.position);
            if (distance < closestDistance)
            {
                closestDistance = distance;
                targetOrange = orange;
            }
        }
    }

    void MoveTowardsOrange()
    {
        // Направление к апельсину
        Vector2 direction = ((Vector2)targetOrange.transform.position - (Vector2)transform.position).normalized;

        // Движение
        transform.position = (Vector2)transform.position + direction * speed * Time.deltaTime;

        // Поворот спрайта в зависимости от направления
        if (direction.x < 0) // Движение вправо
        {
            spriteRenderer.flipX = false; // Обычный вид спрайта
        }
        else if (direction.x > 0) // Движение влево
        {
            spriteRenderer.flipX = true; // Зеркальное отражение спрайта
        }
    }

    void LimitMovement()
    {
        // Ограничиваем позицию по X и Y
        float clampedX = Mathf.Clamp(transform.position.x, minX, maxX);
        float clampedY = Mathf.Clamp(transform.position.y, minY, maxY);

        // Применяем ограниченную позицию
        transform.position = new Vector2(clampedX, clampedY);
    }
}