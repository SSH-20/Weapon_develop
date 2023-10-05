using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Missile : MonoBehaviour
{
    public float initialSpeed = 5.0f;           //�ʱ� �ӵ�
    public float MaxSpeed = 10.0f;              //�ִ� �ӵ�
    public float acceleration = 2.0f;           //���ӵ�
    public float explosionRadius = 2.0f;        //���� ����
    public int damage = 2;

    public float destroyDelay = 2.0f;           //�̻��� �����ð�

    private Transform target;
    private float currentSpeed;                 //���� �ӵ�

    private void Start()
    {
        Destroy(gameObject, destroyDelay);       //�����ð� �� �ı�
        currentSpeed = initialSpeed;
    }
    void Update()
    {
        if (target != null)
        {
            Vector2 moveDirection = (target.position - transform.position).normalized;
            currentSpeed = Mathf.Min(currentSpeed + acceleration * Time.deltaTime, MaxSpeed);   // ���ӵ� ����
            Vector2 moveAmount = moveDirection * currentSpeed * Time.deltaTime;                 //�� ������ ���� �ӵ� ���
            transform.Translate(moveAmount);

        }
        else
        {
            Explode();                                                                          // Ÿ���� ������ �̻��� �ı�
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            Explode();
        }
    }

    //����
    void Explode()
    {
        Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, explosionRadius);

        foreach (Collider2D collider in colliders)
        {
            if (collider.CompareTag("Enemy"))
            {
                Enemy enemy = collider.GetComponent<Enemy>();
               /* if (enemy != null)
                {
                    enemy.TakeDamage(damage);
                }*/
            }
        }

        Destroy(gameObject); // ���� �� �̻��� �ı�
    }

    public void SetTarget(Transform newTarget)
    {
        target = newTarget;
    }
}