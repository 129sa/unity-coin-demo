using UnityEngine;

public class LifecycleLogger : MonoBehaviour
{
    int frame = 0;

    void Awake() { Debug.Log("Awake"); }
    void OnEnable() { Debug.Log("OnEnable"); }
    void Start() { Debug.Log("Start"); }

    void Update()
    {
        if (frame < 2) Debug.Log("Update");
        frame++;
    }

    void LateUpdate() { if (frame < 3) Debug.Log("LateUpdate"); }

    void OnDisable() { Debug.Log("OnDisable"); }
    void OnDestroy() { Debug.Log("OnDestroy"); }
}