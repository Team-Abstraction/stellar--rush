using UnityEngine;

public class testShoot : MonoBehaviour
{
    public float gravity = 9.81f; // гравитация на поверхности земли
    public float maxGravityDistance = 10f; // максимальное расстояние, на котором действует гравитация

    private Rigidbody2D rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        // получаем все объекты с тегом "Planet"
        GameObject[] planets = GameObject.FindGameObjectsWithTag("Planet");

        // проходимся по каждому объекту планеты
        foreach (GameObject planet in planets)
        {
            // вычисляем расстояние до планеты
            float distance = Vector2.Distance(transform.position, planet.transform.position);

            // если расстояние меньше максимального действия гравитации
            if (distance < maxGravityDistance)
            {
                // вычисляем силу гравитации
                float gravityForce = gravity * rb.mass * planet.GetComponent<Rigidbody2D>().mass / Mathf.Pow(distance, 2);

                // вычисляем направление на планету
                Vector2 direction = (planet.transform.position - transform.position).normalized;

                // добавляем силу гравитации к силе движения снаряда
                rb.AddForce(direction * gravityForce);
            }
        }
    }
}
