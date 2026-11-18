using UnityEngine;

public class EnemyChase : MonoBehaviour
{
    public Transform target;        // 把 Player 拖进来
    public float speed = 4f;

    Rigidbody rb;

    void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        Vector3 dir = target.position - transform.position;
        dir.y = 0f;

        rb.velocity = new Vector3(dir.normalized.x * speed, rb.velocity.y, dir.normalized.z * speed);// 保留重力，别把 y 清零
    }
}