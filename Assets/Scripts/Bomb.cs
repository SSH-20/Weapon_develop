using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour
{
    public Transform firePoint;                     //발사 위치
    public GameObject grandePrefab;                //발사될 미사일 프리펩
    public float detectionRange = 10.0f;            //탐지 범위
    public float throwRate = 5.0f;                   // 발사 속도 (초당 발사 횟수)
    public LayerMask monsterLayer;
    private float timeSinceLastFire = 0.0f;

    private void Update()
    {
        timeSinceLastFire += Time.deltaTime;

        // 일정 간격으로 몬스터를 탐지하고 발사
        if (timeSinceLastFire >= 1.0f / throwRate)
        {
            DetectAndLaunchr();
            timeSinceLastFire = 0.0f;
        }
    }

    void DetectAndLaunchr()
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

            Launch(nearestMonster); // 가장 가까운 적 타겟팅
        }
    }

    void Launch(Transform target)
    {
        GameObject grande = Instantiate(grandePrefab, firePoint.position, Quaternion.identity);
        Granade GrandeScript = grande.GetComponent<Granade>();

        GrandeScript.SetTarget(target); // 적을 타겟으로 설정
    }
}
