using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallScript : MonoBehaviour
{
    public Vector2 curPos; // 공의 최근 위치
    public Vector2 lastPos; // 공의 마지막 위치
    public static Transform characterPos; // 패스할 플레이어를 지정할 정적 변수
    public float speed; // 공 스피드
    public bool ballMoving; //공이 이동하는지 판단할 여부
    // Start is called before the first frame update
    void Start()
    {
        //초기값은 지금의 값
        characterPos = this.transform;
        speed = 2f;
    }

    // Update is called once per frame
    void Update()
    {
        //최근 위치에 현재 자신의 위치값 대입
        curPos = transform.position;
        //만약 현재 위치와 마지막 위치가 같다면
        if(curPos == lastPos)
        {
            ballMoving = false;
        }
        else
        {
            ballMoving = true;
            characterAI.teamDistance = 10;
        }
        // 공의 마지막 위치를 최근 위치 대입, 공의 최근 위치에 현재 공위 위치값을 대입하므로 공이 움직이면 마지막 위치는 계속 갱신됨
        // curPos == lastPos의 값이 같다면 움직이지 않는다는 의미
        lastPos = curPos;

        // ball pass 구현 (공이 대상자를 향해 이동)
        // 현재 공의 위치
        Vector2 positionA = this.transform.position;
        // 패스 대상자의 위치
        Vector2 positionB = characterPos.position;
        // 현재 공의 유치값에 패스 대상자의 위치값을 보간한 값을 대입 시켜 이동
        this.transform.position = Vector2.Lerp(positionA, positionB, Time.deltaTime * speed);
    }
}
