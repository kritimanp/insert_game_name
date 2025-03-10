using UnityEngine;

public class enemy_damage : MonoBehaviour
{
    public float damage;
    protected void OnTriggerEnter2D(Collider2D collision)
    {
      if(collision.tag=="Player")
      collision.GetComponent<health>().TakeDamage(damage);
    }
}
