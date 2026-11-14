using UnityEngine;

public class HitLogger : MonoBehaviour
{
    void OnCollisionEnter(Collision other)
    {
        Debug.Log("撞到了：" + other.gameObject.name);
    }
    void OnTriggerEnter(Collider other)
    {
        Debug.Log("穿过了：" + other.gameObject.name);
    }
}