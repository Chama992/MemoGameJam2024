using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class ballinmid : MonoBehaviour
{
    // Start is called before the first frame update
    public Rigidbody2D _v;
    public Vector2 startPosition = new Vector2(0, -4);
    // ������ inspector �п���ֱ���޸� public ����
    // ������������һ����ʼλ�ñ���
    void Start()
    {
        _v = GetComponent<Rigidbody2D>();
        setball();
    }

    void Update()
    {

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("������ײ");
        GameObject collisionGo = collision.gameObject;
        if (collisionGo.CompareTag("player1score"))
        {
            Debug.Log("�ж��ɹ�");
            setball();
        }
        else if (collisionGo.CompareTag("player2score"))
        {
            Debug.Log("�ж��ɹ�");
            setball();
        }
    }

    private void setball()
    {
        transform.position = startPosition;
        _v.velocity = new Vector2(0, 5);
    }
}