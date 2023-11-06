using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] private int MaxHealth = 100;

    [SerializeField] private int health = 100;

    private Color naturalColor;

    private void Start()
    {
        naturalColor = GetComponent<SpriteRenderer>().color;
    }

    public virtual void Damage(int amount)
    {
        health -= amount;
        StartCoroutine(Flash(Color.white));
        if (health < 0)
        {
            Die();
        }
    }

    public virtual void Heal(int amount)
    {
        health += amount;
        StartCoroutine(Flash(Color.green));
        health = Mathf.Clamp(health, 0, MaxHealth);
    }

    public virtual void Die()
    {
        Destroy(gameObject);
    }
    private IEnumerator Flash(Color color)
    {
        if (GetComponent<SpriteRenderer>() == null) yield break;

        SpriteRenderer sprite = GetComponent<SpriteRenderer>();
        sprite.color = color;
        yield return new WaitForSeconds(0.1f);
        sprite.color = naturalColor;
    }
}
