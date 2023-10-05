using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotGunBullet : MonoBehaviour
{
    public float bulletSpeed = 10.0f;           //총알 속도
    public int damage = 1;
    public float destroyDelay = 2.0f;           //총알 유지시간

    private void Start()
    {
       Destroy(gameObject, destroyDelay);       //유지시간 후 파괴
    }
    void Update()
    {
        transform.Translate(Vector2.right * bulletSpeed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            Enemy enemy = collision.gameObject.GetComponent<Enemy>();
            /*if (enemy != null)
            {
                enemy.TakeDamage(damage);
            }*/
            Destroy(gameObject);
        }
    }
}
