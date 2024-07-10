using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed = 3;
    public GameObject BulletPrefab;
    private Rigidbody2D _Rigid;
    private SpriteRenderer _Sr;
    private Skill skill;
    private string skillName;
    private bool isRight = true;
    private bool isCloaking = false;
    private bool isShielding = false;
    void Start()
    {
        _Sr = GetComponent<SpriteRenderer>();
        _Rigid = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        float x = Input.GetAxis("Horizontal");
        float y = Input.GetAxis("Vertical");
        Move(x, y);
        Flip(x);
        UseSkill(x, y);
    }

    void Move(float x, float y)
    {
        _Rigid.velocity = new Vector2(x * speed, y * speed);
    }

    void Flip(float x)
    {
        if (x < 0)
        {
            _Sr.flipX = true;
            isRight = false;
        }

        if (x > 0)
        {
            _Sr.flipX = false;
            isRight = true;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        GetSkill(collision.gameObject);
    }
    void GetSkill(GameObject prof) 
    {
       bool profFlag = false;
        if (skill != null)
        {
            Debug.Log("���ļ���δʹ�����");
            return;
        }
        string skillTag = prof.tag;
        switch (skillTag)
        {
            case "cloaking":
                skill = new Cloaking("cloaking", 2);
                Debug.Log($"������Ϊ{skill.skillName}");
                Debug.Log($"����ʱ��{((Cloaking)skill).duration}");
                skillName = "cloaking";
                profFlag = true;
                break;
            case "shield":
                skill = new Shield("shield", 2);
                Debug.Log($"������Ϊ{skill.skillName}");
                Debug.Log($"��ʱ��{((Shield)skill).duration}");
                skillName = "shield";
                profFlag = true;
                break;
            case "attack":
                skill = new Attack("attack",3) ;
                Debug.Log($"������Ϊ{skill.skillName}");
                Debug.Log($"�������ڴ���{((Attack)skill).times}");
                skillName = "attack";
                profFlag = true;
                break;
        }
        if (profFlag)
        {
            //Todo:�޸�ui�еĵ��߿�
            GameObject profGenerator = GameObject.FindGameObjectWithTag("propgenerator");
            ObjectGenerator objectGenerator = profGenerator.GetComponent<ObjectGenerator>();
            objectGenerator.generatedObjects.Remove(prof);
            Destroy(prof);
        }
    }
    void UseSkill(float x, float y)
    {
        if (skill != null && Input.GetKeyUp(KeyCode.Space))
        {
            Debug.Log($"��ʹ����{skillName}");
            switch (skillName)
            {
                case "cloaking":
                    if (!((Cloaking)skill).isUsed) 
                    {
                        //ʹ������
                        Debug.Log("��ʹ��������");
                        _Sr.color = new Color(_Sr.color.r, _Sr.color.g, _Sr.color.b, _Sr.color.a * 0.5f);
                        ((Cloaking)skill).isUsed = true;
                        isCloaking = true;
                    }
                    break;
                case "shield":
                    if (!((Shield)skill).isUsed)
                    {
                        //ʹ�û���
                        Debug.Log("��ʹ���˻���");
                        ((Shield)skill).isUsed = true;
                        isShielding = true;
                    }
                    break;
                case "attack":
                    GameObject bulletObj = Instantiate(BulletPrefab);
                    bulletObj.transform.position = transform.position + (new Vector3(x, y)).normalized * 1;
                    Bullet bullet = bulletObj.GetComponent<Bullet>();
                    if (x == 0 && y == 0)
                    {
                        if (isRight)
                        {
                            bullet.SetDirection(Vector3.right);
                        }
                        else
                        {
                            bullet.SetDirection(Vector3.left);
                        }
                    }
                    else 
                    {
                        bullet.SetDirection((new Vector3(x, y)).normalized);
                    }
                    ((Attack)skill).times -= 1;
                    Debug.Log("�����ӵ�");
                    Debug.Log($"ʣ���ӵ�{((Attack)skill).times}");
                    break;
            }
        }
        if (skillName != null)
        {
            if (skillName == "cloaking" && ((Cloaking)skill).isUsed)
            {
                if (((Cloaking)skill).duration > 0)
                    ((Cloaking)skill).duration -= Time.deltaTime;
                else
                {
                    skill = null;
                    skillName = null;
                    _Sr.color = new Color(_Sr.color.r, _Sr.color.g, _Sr.color.b, _Sr.color.a * 2);
                    isCloaking = false;
                    Debug.Log("��������");
                    //��������
                }
            }
            if (skillName == "shield" && ((Shield)skill).isUsed)
            {
                if (((Shield)skill).duration > 0)
                    ((Shield)skill).duration -= Time.deltaTime;
                else
                {
                    skill = null;
                    skillName = null;
                    isShielding = false;
                    Debug.Log("��������");
                    //������
                }
            }
            if ((skillName == "attack"))
            {
                if (((Attack)skill).times <= 0)
                {
                    skill = null;
                    skillName = null;
                    Debug.Log("�ӵ���ʹ�����");
                    //��������
                }
            }
        }
    }
}