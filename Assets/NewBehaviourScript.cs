using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class MonScript : MonoBehaviour
{
    // 몬스터 기본 정보
    public string monName;
    //float은 소수점
    public float monMaxHp;
    //컨트롤 d를 누르면 줄이 통째로 복사된다
    public Image hpImage;

    public float Atk;

    public MonScript target;

    public TextMeshProUGUI hpText;

    public int reCnt;//웬만하면 변수명 풀로 하기

    public float monCurHp;
    //HideInInspector:숨기기

    public float coolTime;

    // public float i = 10;
    // i = 변수

    string die = "fuck";





    // Start is called before the first frame update
    void Start()
    {
        gameObject.GetComponent<TextMeshProUGUI>().text = monName;
        monCurHp = monMaxHp;
        hpText.text = monCurHp + " / " + monMaxHp;
    }

    float cTime;

    // Update is called once per frame: 매 프레임마다 업데이트 됨
    void Update()
    {
        if (monCurHp > 0)
            if (cTime >= coolTime)//실행할 것이 한개만 들어가면 중괄호 안써도 된다
            {
                //monCurHp--;//몬스터 피를 먼저 깎는다
                //float fill = monCurHp / monMaxHp;
                //hpImage.fillAmount = fill;
                ////1보다 커지면 이미지를 줄이면서 0으로 다시 초기화 시킨다
                //cTime = 0;
                //kjhT /= 2f;
                ////f를 붙이는건 float이다라는 뜻
                ///
                target.OnDamage(Atk);
                //타겟의 몬스터에 접근하고 계의 온데미지 함수를 실행시켜
                cTime = 0;
            }
            else
            {
                cTime += Time.deltaTime;

            }
    }

    public void OnDamage(float _Atk)//매개변수가 없으면 공란으로 비어두면 됨
    {
        monCurHp -= _Atk;//몬스터 피를 먼저 깎는다
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
        // 함수를 void라고 한다


    }
}


