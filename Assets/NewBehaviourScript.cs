using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class MonScript : MonoBehaviour
{
    // ���� �⺻ ����
    public string monName;
    //float�� �Ҽ���
    public float monMaxHp;
    //��Ʈ�� d�� ������ ���� ��°�� ����ȴ�
    public Image hpImage;

    public float Atk;

    public MonScript target;

    public TextMeshProUGUI hpText;

    public int reCnt;//�����ϸ� ������ Ǯ�� �ϱ�

    public float monCurHp;
    //HideInInspector:�����

    public float coolTime;

    // public float i = 10;
    // i = ����

    string die = "fuck";





    // Start is called before the first frame update
    void Start()
    {
        gameObject.GetComponent<TextMeshProUGUI>().text = monName;
        monCurHp = monMaxHp;
        hpText.text = monCurHp + " / " + monMaxHp;
    }

    float cTime;

    // Update is called once per frame: �� �����Ӹ��� ������Ʈ ��
    void Update()
    {
        if (monCurHp > 0)
            if (cTime >= coolTime)//������ ���� �Ѱ��� ���� �߰�ȣ �Ƚᵵ �ȴ�
            {
                //monCurHp--;//���� �Ǹ� ���� ��´�
                //float fill = monCurHp / monMaxHp;
                //hpImage.fillAmount = fill;
                ////1���� Ŀ���� �̹����� ���̸鼭 0���� �ٽ� �ʱ�ȭ ��Ų��
                //cTime = 0;
                //kjhT /= 2f;
                ////f�� ���̴°� float�̴ٶ�� ��
                ///
                target.OnDamage(Atk);
                //Ÿ���� ���Ϳ� �����ϰ� ���� �µ����� �Լ��� �������
                cTime = 0;
            }
            else
            {
                cTime += Time.deltaTime;

            }
    }

    public void OnDamage(float _Atk)//�Ű������� ������ �������� ���θ� ��
    {
        monCurHp -= _Atk;//���� �Ǹ� ���� ��´�
        float fill = monCurHp / monMaxHp;
        hpImage.fillAmount = fill;
        if (monCurHp <= 0)
        {
            if (reCnt > 0)
            {
                monCurHp = monMaxHp / 2f; // monCurHp = monMaxHp * 0.5f;
                reCnt--;
                hpText.text = monCurHp + " / " + monMaxHp;
            }
            else
            {
                hpText.text = die;
            }
        }
        else
        {
            hpText.text = monCurHp + " / " + monMaxHp;
        }
        // �Լ��� void��� �Ѵ�


    }
}


