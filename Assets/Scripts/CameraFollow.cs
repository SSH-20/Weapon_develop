using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform player;                            // 플레이어를 연결할 변수
    public float smoothSpeed = 5.0f;
    public Vector3 offset = new Vector3(0, 0, -10);     // 카메라 위치 오프셋

    void LateUpdate()
    {
        if (player != null)
        {
            // 플레이어의 위치에 오프셋을 더한 위치로 카메라를 이동
            Vector3 desiredPosition = player.position + offset;
            Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed * Time.deltaTime);
            transform.position = smoothedPosition;

            // 카메라가 항상 고정된 방향(정면)을 유지
            transform.rotation = Quaternion.identity;
        }
    }
}
