using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotGunBullet : MonoBehaviour
{
    public float bulletSpeed = 10.0f;           //�Ѿ� �ӵ�
    public int damage = 1;
    public float destroyDelay = 2.0f;           //�Ѿ� �����ð�

    private void Start()
    {
       Destroy(gameObject, destroyDelay);       //�����ð� �� �ı�
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
