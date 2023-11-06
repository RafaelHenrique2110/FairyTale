using UnityEngine;

public class HeroMovement : MonoBehaviour
{
    float speed = 5;

    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        Vector3 dir = new Vector3(horizontal, 0, vertical);
        transform.position += dir * speed * Time.deltaTime;
    }

    void OnCollisionEnter(Collision collision)
    {
        Dashed enemy = collision.gameObject.GetComponent<Dashed>();
        enemy.Dash(transform.forward, 10);
    }
}
