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
        //물리 프레임 만큼 움직이는 속도. 어느 환경에서든 똑같은 속도로 이동할 수 있게 하는 코드
        Vector2 nextVec = inputVec.normalized * speed * Time.fixedDeltaTime;
        //이동
        rigid.MovePosition(rigid.position + nextVec);
    }
}
