using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotGun : MonoBehaviour
{
    public Transform firePoint;
    public GameObject ShotGunBulletPrefab;
    public int pelletsCount = 5;                        // 발사되는 탄환의 개수
    public float spreadAngle = 30.0f;                   // 탄환들 사이의 각도
    public float detectionRange = 10.0f;                // 탐지 범위
    public LayerMask monsterLayer;                      // 탐지할 레이어
    
    public float fireRate = 0.5f;                       // 발사 속도 (초당 발사 횟수)
    private float timeSinceLastFire = 0.0f;

    private void Start()
    {
        // 일정한 주기로 자동으로 총알 발사
        InvokeRepeating("Shoot", 0.0f, fireRate);
    }

    /*void Update()
    {
        timeSinceLastFire += Time.deltaTime;

        // 일정 간격으로 몬스터를 탐지하고 발사
        if (timeSinceLastFire >= 1.0f / fireRate)
        {
            DetectAndShoot();
            timeSinceLastFire = 0.0f;
        }
    }*/

    /*void DetectAndShoot()
    {
        Collider2D[] monsters = Physics2D.OverlapCircleAll(transform.position, detectionRange, monsterLayer);

        if (monsters.Length > 0)
        {
            Transform nearestMonster = monsters[0].transform;
            float nearestDistance = Vector2.Distance(transform.position, nearestMonster.position);

            foreach (Collider2D monster in monsters)
            {
                float distance = Vector2.Distance(transform.position, monster.transform.position);
                if (distance < nearestDistance)
                {
                    nearestMonster = monster.transform;
                    nearestDistance = distance;
                }
            }

            Shoot(nearestMonster); // 가장 가까운 적에게 탄환 발사
        }
    }*/

    void Shoot()
    {
        for (int i = 0; i < pelletsCount; i++)
        {
            // 카메라 스크린의 마우스 거리와 총과의 방향
            Vector2 direction = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;

            // 마우스 거리로부터 각도 계산 (음수로 설정하여 반대 방향으로 회전)
            float angle = -Mathf.Atan2(direction.x, direction.y) * Mathf.Rad2Deg + Random.Range(-spreadAngle / 2, spreadAngle / 2) + 90;
            
            Quaternion rotation = Quaternion.AngleAxis(angle, Vector3.forward);
            transform.rotation = rotation;
            Debug.Log(rotation);
            
            GameObject bullet = Instantiate(ShotGunBulletPrefab, firePoint.position, Quaternion.AngleAxis(angle, Vector3.forward));  
        }
    }
}
