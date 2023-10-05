using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SniperBullet : MonoBehaviour
{
    public float bulletSpeed = 20.0f;           //총알 속도
    public int damage = 1;                      //총알 데미지
    public float destroyDelay = 0.4f;           //총알 유지시간
    public int piercing_count = 2;
    void Start()
    {
        Destroy(gameObject, destroyDelay);       //유지시간 후 파괴

    }

    void Update()
    {
        transform.Translate(Vector2.up * bulletSpeed * Time.deltaTime);

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            // 충돌 3회 이상 총알 파괴
            if (piercing_count == 0)
            {
                Destroy(gameObject);
            } 
            
            piercing_count--;
        }
    }
}
