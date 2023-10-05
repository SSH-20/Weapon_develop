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
            // 플레이어 방향 계산
            Vector3 playerDirection = playerTransform.position - transform.position;

            // 플레이어 방향으로 이동
            Vector3 movement = playerDirection.normalized * moveSpeed * Time.deltaTime;
            transform.Translate(movement);
        }
    }


}
