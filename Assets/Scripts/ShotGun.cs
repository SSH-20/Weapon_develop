using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotGun : MonoBehaviour
{
    public Transform firePoint;
    public GameObject ShotGunBulletPrefab;
    public int pelletsCount = 5;                        // �߻�Ǵ� źȯ�� ����
    public float spreadAngle = 30.0f;                   // źȯ�� ������ ����
    public float detectionRange = 10.0f;                // Ž�� ����
    public LayerMask monsterLayer;                      // Ž���� ���̾�
    
    public float fireRate = 0.5f;                       // �߻� �ӵ� (�ʴ� �߻� Ƚ��)
    private float timeSinceLastFire = 0.0f;

    private void Start()
    {
        // ������ �ֱ�� �ڵ����� �Ѿ� �߻�
        InvokeRepeating("Shoot", 0.0f, fireRate);
    }

    /*void Update()
    {
        timeSinceLastFire += Time.deltaTime;

        // ���� �������� ���͸� Ž���ϰ� �߻�
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

            Shoot(nearestMonster); // ���� ����� ������ źȯ �߻�
        }
    }*/

    void Shoot()
    {
        for (int i = 0; i < pelletsCount; i++)
        {
            // ī�޶� ��ũ���� ���콺 �Ÿ��� �Ѱ��� ����
            Vector2 direction = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;

            // ���콺 �Ÿ��κ��� ���� ��� (������ �����Ͽ� �ݴ� �������� ȸ��)
            float angle = -Mathf.Atan2(direction.x, direction.y) * Mathf.Rad2Deg + Random.Range(-spreadAngle / 2, spreadAngle / 2) + 90;
            
            Quaternion rotation = Quaternion.AngleAxis(angle, Vector3.forward);
            transform.rotation = rotation;
            Debug.Log(rotation);
            
            GameObject bullet = Instantiate(ShotGunBulletPrefab, firePoint.position, Quaternion.AngleAxis(angle, Vector3.forward));  
        }
    }
}
