using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallScript : MonoBehaviour
{
    public Vector2 curPos; // ���� �ֱ� ��ġ
    public Vector2 lastPos; // ���� ������ ��ġ
    public static Transform characterPos; // �н��� �÷��̾ ������ ���� ����
    public float speed; // �� ���ǵ�
    public bool ballMoving; //���� �̵��ϴ��� �Ǵ��� ����
    // Start is called before the first frame update
    void Start()
    {
        //�ʱⰪ�� ������ ��
        characterPos = this.transform;
        speed = 2f;
    }

    // Update is called once per frame
    void Update()
    {
        //�ֱ� ��ġ�� ���� �ڽ��� ��ġ�� ����
        curPos = transform.position;
        //���� ���� ��ġ�� ������ ��ġ�� ���ٸ�
        if(curPos == lastPos)
        {
            ballMoving = false;
        }
        else
        {
            ballMoving = true;
            characterAI.teamDistance = 10;
        }
        // ���� ������ ��ġ�� �ֱ� ��ġ ����, ���� �ֱ� ��ġ�� ���� ���� ��ġ���� �����ϹǷ� ���� �����̸� ������ ��ġ�� ��� ���ŵ�
        // curPos == lastPos�� ���� ���ٸ� �������� �ʴ´ٴ� �ǹ�
        lastPos = curPos;

        // ball pass ���� (���� ����ڸ� ���� �̵�)
        // ���� ���� ��ġ
        Vector2 positionA = this.transform.position;
        // �н� ������� ��ġ
        Vector2 positionB = characterPos.position;
        // ���� ���� ��ġ���� �н� ������� ��ġ���� ������ ���� ���� ���� �̵�
        this.transform.position = Vector2.Lerp(positionA, positionB, Time.deltaTime * speed);
    }
}
