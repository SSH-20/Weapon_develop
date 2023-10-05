using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletFiring : MonoBehaviour
{
    public Transform ShotPoint;                     // �Ѿ� �߻� ��ġ
    public GameObject bulletPrefab;                 // �Ѿ� ������
    public float fireRate = 0.5f;                   // �߻� �ֱ� ����
    public float bulletSpeed = 20.0f;               // �Ѿ� �ӵ�

    private float shotTime;

    private void Start()
    {
        // ������ �ֱ�� �ڵ����� �Ѿ� �߻�
        InvokeRepeating("Shoot", 0.0f, fireRate);
    }

    private void Update()
    {
        //ī�޶� ��ũ���� ���콺 �Ÿ��� �Ѱ��� ����
        Vector2 direction = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position; 
        //���콺 �Ÿ��� ���� ���� ���
        float angle = Mathf.Atan2(direction.x, direction.y) * Mathf.Rad2Deg;
        //�����κ��� ����� ������ ȸ����
        Quaternion rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        transform.rotation = rotation;
    }
}
