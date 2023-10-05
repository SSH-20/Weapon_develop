using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sniper : MonoBehaviour
{
    public Transform firePoint;
    public GameObject bulletPrefab;
    public float fireRate = 0.5f; // 발사 주기 설정

    private void Start()
    {
        // 일정한 주기로 자동으로 총알 발사
        InvokeRepeating("Shoot", 0.0f, fireRate);
    }

    public void Shoot()
    {
        // 카메라 스크린의 마우스 거리와 총과의 방향
        Vector2 direction = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;

        // 마우스 거리로부터 각도 계산 (음수로 설정하여 반대 방향으로 회전)
        float angle = -Mathf.Atan2(direction.x, direction.y) * Mathf.Rad2Deg + 90;

        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, Quaternion.AngleAxis(angle - 90, Vector3.forward));
    }
}
