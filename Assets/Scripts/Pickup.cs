using UnityEngine;
using System.Collections;
using System;

public class Pickup : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Player"))return;

        GameUI.Instance.AddCoin();
        StartCoroutine(Respawn());

    }

    IEnumerator Respawn()
    {
        GetComponent<MeshRenderer>().enabled = false;
        GetComponent<Collider>().enabled = false;

        // 第二步：等 3 秒
        yield return new WaitForSeconds(3f);

        // 第三步：恢复
        GetComponent<MeshRenderer>().enabled = true;
        GetComponent<Collider>().enabled = true;
    }
    IEnumerator Blink()
    {
        var renderer = GetComponent<Renderer>();
        for (int i = 0; i < 3; i++)
        {
            renderer.material.color = Color.red;
            yield return new WaitForSeconds(0.1f);
            renderer.material.color = Color.white;
            yield return new WaitForSeconds(0.1f);
        }
    }
}