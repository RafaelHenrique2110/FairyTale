using UnityEngine;

public class Dashed : MonoBehaviour
{
    const float countDownDefault = 0.3f;
    bool hasDashed = false;
    [SerializeField] float countDown = countDownDefault;
    float speed = 5;
    Vector3 direction = Vector3.forward;

    void Update()
    {
        if (hasDashed) {
            transform.position += direction * speed * Time.deltaTime;
            countDown -= Time.deltaTime;
        }

        if (countDown <= 0) {
            hasDashed = false;
            countDown = countDownDefault;
        }
    }

    public void Dash(Vector3 direction, float speed)
    {
        this.direction = direction;
        this.speed = speed;
        hasDashed = true;
    }

    
}
