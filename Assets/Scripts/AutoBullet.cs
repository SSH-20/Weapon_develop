using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoBullet : MonoBehaviour
{
    public float bulletSpeed = 5.0f;           //총알 속도
    public int damage = 1;                      //총알 데미지
    public float destroyDelay = 2.0f;           //총알 유지시간

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
            Destroy(gameObject);                                      // 충돌한 경우 총알 파괴
        }
    }

}
