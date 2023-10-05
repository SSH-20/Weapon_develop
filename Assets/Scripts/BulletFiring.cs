using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletFiring : MonoBehaviour
{
    public Transform ShotPoint;                     // 총알 발사 위치
    public GameObject bulletPrefab;                 // 총알 프리펩
    public float fireRate = 0.5f;                   // 발사 주기 설정
    public float bulletSpeed = 20.0f;               // 총알 속도

    private float shotTime;

    private void Start()
    {
        // 일정한 주기로 자동으로 총알 발사
        InvokeRepeating("Shoot", 0.0f, fireRate);
    }

    private void Update()
    {
        //카메라 스크린의 마우스 거리와 총과의 방향
        Vector2 direction = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position; 
        //마우스 거리로 부터 각도 계산
        float angle = Mathf.Atan2(direction.x, direction.y) * Mathf.Rad2Deg;
        //축으로부터 방향과 각도의 회전값
        Quaternion rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        transform.rotation = rotation;
    }
}
