using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StageCredit : MonoBehaviour
{
    public Text stage;
    public Text credit;

    float money = 0;
    float aMoney = 100;
    float eMoney = 500;
    float bMoney = 20000;

    public Button aBtn;
    public Button eBtn;
    public Button bBtn;

    public Text aincome;
    public Text eincome;
    public Text bincome;

    public Text acost;
    public Text ecost;
    public Text bcost;

    public GameObject bg, bg2, bg3, bg4; //public Image[]


    bool isClick; // Ŭ���� �ǰڲ� �ϴ� ���� ����

    int count = 0;

    // Start is called before the first frame update
    void Start()
    {
        stage.text = "Stage: 1"; // �� ������ �������� �ٲ��� ���̱� ������ start�� �⺻ ������ ����
        isClick = true;

       /* if(isClick == false) // ��ư�� ����
        {
            aBtn.interactable = false;
            eBtn.interactable = false;
            bBtn.interactable = false;
        }
        else
        {
            aBtn.interactable = true;
            eBtn.interactable = true;
            bBtn.interactable = true;
        }*/
    }
    public void ClickUp()
    {
        
        money += 200;

    }

    public void Ability()
    {

        aMoney = aMoney + 10;
 
        if (money >= aMoney)
        {
            isClick = true;
            money = money - aMoney;
        }
        else
        {
            isClick = false;
            Debug.Log("�ݾ��� �����մϴ�. Ŭ���� �� �Ͻʽÿ�");
        }
    }

    public void Employee()
    {
        eMoney = eMoney + 50;
       
        if (money >= eMoney)
        {
            isClick = true;
            money = money - eMoney;
        }
        else
        {
            isClick = false;
            Debug.Log("�ݾ��� �����մϴ�. Ŭ���� �� �Ͻʽÿ�");
        }
    }

    public void Building()
    {
        count++;
        bMoney = bMoney + 2000*count/count;
        
        if (money >= bMoney)
        {
            isClick = true;
            money = money - bMoney;
            if(count == 3) // �ѹ� Ŭ���ϸ� �̹����� 2���� ������
            {
                bg.SetActive(false);
                bg2.SetActive(true);
                bg3.SetActive(false);
                bg4.SetActive(false);
                stage.text = "Stage: 2";
            }
            if (count == 6) // �ι�° Ŭ���ϸ� �̹����� 3���� ������
            {
                bg.SetActive(false);
                bg2.SetActive(false);
                bg3.SetActive(true);
                bg4.SetActive(false);
                stage.text = "Stage: 3";
            }
            if (count == 9)
            {
                bg.SetActive(false);
                bg2.SetActive(false);
                bg3.SetActive(false);
                bg4.SetActive(true);
                stage.text = "Stage: 4";
            }
        }
        else
        {
            isClick = false;
            Debug.Log("�ݾ��� �����մϴ�. Ŭ���� �� �Ͻʽÿ�");
        }
    }

    public void Cheat()
    {
        money += 5000;
    }

    // Update is called once per frame
    void Update()
    {
        
        credit.text = "Credit: " + money;

        aincome.text = "Income + 10 Per Buy";
        acost.text = "Cost: +" + aMoney + " per Buy";

        eincome.text = "Income + 50 per Buy";
        ecost.text = "Cost: +" + eMoney + " per Buy";

        bincome.text = "Income + 2000 per Buy";
        bcost.text = "Cost: +" + bMoney + " per Buy";

    }

    

    

    

    
}
