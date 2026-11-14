using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;                              // 把玩家拖进来
    public Vector3 offset = new Vector3(0f, 2f, -6f);     // 相机相对玩家的位置

    void LateUpdate()
    {
        transform.position = target.position + offset;
    }
}