using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class EnemyBoss : MonoBehaviour
{
    // Start is called before the first frame update
    Transform target;
    public int enemyHP = 100;
    public Animator animator;
    public Slider enemyHealthBar;
    void Start()
    {
        enemyHealthBar.value = enemyHP;
        target = GameObject.FindGameObjectWithTag("Boss").transform;
        // Physics2D.IgnoreCollision(target.GetComponent<Collider2D>(), GetComponent<Collider2D>());
    }
    public void TakeDamage(int damageAmount)
    {

        enemyHP -= damageAmount;
        enemyHealthBar.value = enemyHP;
        if (enemyHP > 0)
        {
            // Damage animation
            animator.SetTrigger("damage");
        }
        else
        {
            // Death animation
            animator.SetTrigger("death");
            // GetComponent<CircleCollider2D>().enabled = false;
            // this.enabled = false;
            Destroy(transform.parent.gameObject, 0.5f);
        }
    }
}
