using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Luncher : MonoBehaviour
{
    public Transform firePoint;                     //�߻� ��ġ
    public GameObject missilePrefab;                //�߻�� �̻��� ������
    public float detectionRange = 10.0f;            //Ž�� ����
    public float fireRate = 5.0f;                   // �߻� �ӵ� (�ʴ� �߻� Ƚ��)
    public LayerMask monsterLayer;
    private float timeSinceLastFire = 0.0f;

    private void Update()
    {
        timeSinceLastFire += Time.deltaTime;

        // ���� �������� ���͸� Ž���ϰ� �߻�
        if (timeSinceLastFire >= 1.0f / fireRate)
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

            Launch(nearestMonster); // ���� ����� ������ �����̻��� �߻�
        }
    }

    void Launch(Transform target)
    {
        GameObject missile = Instantiate(missilePrefab, firePoint.position, Quaternion.identity);
        Missile missileScript = missile.GetComponent<Missile>();

        missileScript.SetTarget(target); // ���� Ÿ������ ����
    }
}
