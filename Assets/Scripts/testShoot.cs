using UnityEngine;

public class testShoot : MonoBehaviour
{
    public float gravity = 9.81f; // ���������� �� ����������� �����
    public float maxGravityDistance = 10f; // ������������ ����������, �� ������� ��������� ����������

    private Rigidbody2D rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        // �������� ��� ������� � ����� "Planet"
        GameObject[] planets = GameObject.FindGameObjectsWithTag("Planet");

        // ���������� �� ������� ������� �������
        foreach (GameObject planet in planets)
        {
            // ��������� ���������� �� �������
            float distance = Vector2.Distance(transform.position, planet.transform.position);

            // ���� ���������� ������ ������������� �������� ����������
            if (distance < maxGravityDistance)
            {
                // ��������� ���� ����������
                float gravityForce = gravity * rb.mass * planet.GetComponent<Rigidbody2D>().mass / Mathf.Pow(distance, 2);

                // ��������� ����������� �� �������
                Vector2 direction = (planet.transform.position - transform.position).normalized;

                // ��������� ���� ���������� � ���� �������� �������
                rb.AddForce(direction * gravityForce);
            }
        }
    }
}
