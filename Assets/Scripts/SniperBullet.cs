using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SniperBullet : MonoBehaviour
{
    public float bulletSpeed = 20.0f;           //�Ѿ� �ӵ�
    public int damage = 1;                      //�Ѿ� ������
    public float destroyDelay = 0.4f;           //�Ѿ� �����ð�
    public int piercing_count = 2;
    void Start()
    {
        Destroy(gameObject, destroyDelay);       //�����ð� �� �ı�

    }

    void Update()
    {
        transform.Translate(Vector2.up * bulletSpeed * Time.deltaTime);

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            // �浹 3ȸ �̻� �Ѿ� �ı�
            if (piercing_count == 0)
            {
                Destroy(gameObject);
            } 
            
            piercing_count--;
        }
    }
}
