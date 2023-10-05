using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Granade : MonoBehaviour
{
    public float initialSpeed = 5.0f;           //초기 속도
    //public float MaxSpeed = 10.0f;              //최대 속도
    //public float acceleration = 2.0f;           //가속도
    public float explosionRadius = 2.0f;        //폭발 범위
    public int damage = 2;

    public float destroyDelay = 2.0f;           //미사일 유지시간

    private Transform target;
    //private float currentSpeed;                 //현재 속도

    private void Start()
    {
        Destroy(gameObject, destroyDelay);       //유지시간 후 파괴
        //currentSpeed = initialSpeed;
    }
    void Update()
    {
        transform.Translate(target.position * initialSpeed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            Explode();
        }
    }

    //폭발
    void Explode()
    {
        Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, explosionRadius);

        foreach (Collider2D collider in colliders)
        {
            if (collider.CompareTag("Enemy"))
            {
                Enemy enemy = collider.GetComponent<Enemy>();
                /* if (enemy != null)
                 {
                     enemy.TakeDamage(damage);
                 }*/
            }
        }

        Destroy(gameObject); // 폭발 후 미사일 파괴
    }

    public void SetTarget(Transform newTarget)
    {
        target = newTarget;
    }
}
