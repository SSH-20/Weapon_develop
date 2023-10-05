using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoBullet : MonoBehaviour
{
    public float bulletSpeed = 5.0f;           //�Ѿ� �ӵ�
    public int damage = 1;                      //�Ѿ� ������
    public float destroyDelay = 2.0f;           //�Ѿ� �����ð�

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
            Destroy(gameObject);                                      // �浹�� ��� �Ѿ� �ı�
        }
    }

}
