using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sniper : MonoBehaviour
{
    public Transform firePoint;
    public GameObject bulletPrefab;
    public float fireRate = 0.5f; // �߻� �ֱ� ����

    private void Start()
    {
        // ������ �ֱ�� �ڵ����� �Ѿ� �߻�
        InvokeRepeating("Shoot", 0.0f, fireRate);
    }

    public void Shoot()
    {
        // ī�޶� ��ũ���� ���콺 �Ÿ��� �Ѱ��� ����
        Vector2 direction = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;

        // ���콺 �Ÿ��κ��� ���� ��� (������ �����Ͽ� �ݴ� �������� ȸ��)
        float angle = -Mathf.Atan2(direction.x, direction.y) * Mathf.Rad2Deg + 90;

        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, Quaternion.AngleAxis(angle - 90, Vector3.forward));
    }
}
