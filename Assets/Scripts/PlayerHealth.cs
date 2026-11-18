using System.Collections;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int maxHp = 3;
    public int hp = 3;
    public float invincibleTime = 1f;
    bool dead;
    bool invincible;

    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Enemy"))
            TakeDamage(1);
    }

    public void TakeDamage(int amount)
    {
        if (dead || invincible) return;

        hp -= amount;
        Debug.Log(" ‹…À£° £”‡—™¡ø£∫" + hp);

        if (hp <= 0)
        {
            Die();
            return;
        }

        StartCoroutine(Blink());
    }
    void Die()
    {
        dead = true;
        Debug.Log("ÕÊº“À¿Õˆ, ”Œœ∑Ω· ¯");

        GetComponent<PlayerController>().enabled = false;
        GameUI.Instance.Lose();
    }

    IEnumerator Blink()
    {
        invincible = true;

        var rend = GetComponent<Renderer>();
        for (int i = 0; i < 5; i++)
        {
            rend.enabled = false;
            yield return new WaitForSeconds(0.1f);
            rend.enabled = true;
            yield return new WaitForSeconds(0.1f);
        }

        invincible = false;
    }
}