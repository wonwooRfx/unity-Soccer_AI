using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class characterAI : MonoBehaviour
{
    float speed; //�÷��̾� ���ǵ�
    public Transform ball; // �Ѿư� �� Ʈ������
    bool hasBall; // ���� ���� �ִ��� ���� 
    float ballDistance; // ������ �Ÿ�
    bool nearTheBall;
    public List<Transform> teamCharacters; // �÷��̾� ����Ʈ
    public int randomChoice;
    
    public static float teamDistance; // ��� ĳ���� ������ �����Ǵ�  Ÿ���� ����
    // Start is called before the first frame update
    void Start()
    {
        speed = 1f; // �÷��̾��� ���ǵ� �ʱⰪ
        teamDistance = 10f;
    }

    // Update is called once per frame
    void Update()
    {
        // ���� ������ �ʰ� �ڽ��� ���� ���� �����ٸ� ���� �Ѿ� ����.
        if (hasBall == false && nearTheBall == true)
        {
           
                transform.position = Vector3.Lerp(transform.position, ball.position, speed * Time.deltaTime);
           
           
        }
        /*Vector3 dir = (ball.position - transform.position ).normalized;
        dir = dir*speed*Time.deltaTime;
        transform.Translate(dir);*/
        if (ballDistance < 0.1)
        {
            hasBall = true;
            
        }

        if (hasBall == true)
        {
            passBall();
            hasBall = false;
        }


        ballDistance = Vector3.Distance(transform.position, ball.position);
        //���� ���� ����� �÷��̾ ã�� ���� ���� ���� ������ �ִ� ĳ������ �Ÿ� ���� ������ �� �ֵ��� ó��
        //�� ���� �� �ڵ��� teamDistance ���� ���� �۾� �� ���ۿ� ����
        if(ballDistance < teamDistance)
        {
            teamDistance = ballDistance;
        }

        if (teamDistance == ballDistance)
        {
            nearTheBall = true;
        }

        if(teamDistance < ballDistance)
        {
            nearTheBall = false;
        }
    }

    void passBall()
    {
        randomChoice = Random.Range(0, 10);
        BallScript.characterPos = teamCharacters[randomChoice];
    }

       
}
