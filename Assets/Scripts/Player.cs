using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Vector2 inputVec;
    public float speed;

    Rigidbody2D rigid;

    void Start()
    {
        rigid = GetComponent<Rigidbody2D>();        
    }

    
    void Update()
    {
        inputVec.x = Input.GetAxis("Horizontal");
        inputVec.y = Input.GetAxis("Vertical");
    }

    private void FixedUpdate()
    {
        //���� ������ ��ŭ �����̴� �ӵ�. ��� ȯ�濡���� �Ȱ��� �ӵ��� �̵��� �� �ְ� �ϴ� �ڵ�
        Vector2 nextVec = inputVec.normalized * speed * Time.fixedDeltaTime;
        //�̵�
        rigid.MovePosition(rigid.position + nextVec);
    }
}