using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class buff1 : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

        // ʾ�����
        GameObject player1 = GameObject.FindGameObjectWithTag("Player1");
        GameObject player2 = GameObject.FindGameObjectWithTag("Player2");
        Player playerCom1 = player1.GetComponent<Player>();
        Player playerCom2 = player2.GetComponent<Player>();
        // ��ȡһ���������
        Broom selectedBroom = Broom.ExtractBroom();
        Debug.Log($"���1��ȡ�����{selectedBroom.broomName}");

        // Ӧ������ļӳ�Ч��
        selectedBroom.ApplyBuff(playerCom1);

        // �����ҵ����ԣ���������ӳɺ�
        Debug.Log($"���1������٣�{playerCom1.maxspeed}");
        Debug.Log($"���1���ٶȣ�{playerCom1.acceleration}");

    }

    // Update is called once per frame
    void Update()
    {

    }
}
