using UnityEngine;

public class GenaController2D : MonoBehaviour
{
    public float speed = 3f; // �������� ��������
    private GameObject[] oranges; // ������ ����������
    private GameObject targetOrange; // ��������� ��������

    // ������� �����������
    public float minX = -5f;
    public float maxX = 5f;
    public float minY = -3f;
    public float maxY = 2f;

    private SpriteRenderer spriteRenderer; // ��������� ��� ��������� �������

    void Start()
    {
        // �������� ��������� SpriteRenderer
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
        oranges = GameObject.FindGameObjectsWithTag("Orange"); // ������� ��� ��������� �� ����
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
        // ����������� � ���������
        Vector2 direction = ((Vector2)targetOrange.transform.position - (Vector2)transform.position).normalized;

        // ��������
        transform.position = (Vector2)transform.position + direction * speed * Time.deltaTime;

        // ������� ������� � ����������� �� �����������
        if (direction.x < 0) // �������� ������
        {
            spriteRenderer.flipX = false; // ������� ��� �������
        }
        else if (direction.x > 0) // �������� �����
        {
            spriteRenderer.flipX = true; // ���������� ��������� �������
        }
    }

    void LimitMovement()
    {
        // ������������ ������� �� X � Y
        float clampedX = Mathf.Clamp(transform.position.x, minX, maxX);
        float clampedY = Mathf.Clamp(transform.position.y, minY, maxY);

        // ��������� ������������ �������
        transform.position = new Vector2(clampedX, clampedY);
    }
}