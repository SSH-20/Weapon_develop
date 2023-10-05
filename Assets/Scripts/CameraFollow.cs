using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform player;                            // �÷��̾ ������ ����
    public float smoothSpeed = 5.0f;
    public Vector3 offset = new Vector3(0, 0, -10);     // ī�޶� ��ġ ������

    void LateUpdate()
    {
        if (player != null)
        {
            // �÷��̾��� ��ġ�� �������� ���� ��ġ�� ī�޶� �̵�
            Vector3 desiredPosition = player.position + offset;
            Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed * Time.deltaTime);
            transform.position = smoothedPosition;

            // ī�޶� �׻� ������ ����(����)�� ����
            transform.rotation = Quaternion.identity;
        }
    }
}
