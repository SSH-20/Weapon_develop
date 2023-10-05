using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterAi : MonoBehaviour
{
    public float moveSpeed = 3.0f;
    public Transform playerTransform;

    private void Update()
    {
        if (playerTransform != null)
        {
            // �÷��̾� ���� ���
            Vector3 playerDirection = playerTransform.position - transform.position;

            // �÷��̾� �������� �̵�
            Vector3 movement = playerDirection.normalized * moveSpeed * Time.deltaTime;
            transform.Translate(movement);
        }
    }


}
