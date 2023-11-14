using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private int bulletDamage;
    public void OnCollisionEnter2D(Collision2D collision)
    {
        //TODO: Fix collisions (maybe layers?)
        Health health = collision.gameObject.GetComponent<Health>();
        if (health) health.Damage(bulletDamage);
    }
}