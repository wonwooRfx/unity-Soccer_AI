using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class characterAI : MonoBehaviour
{
    float speed; //플레이어 스피드
    public Transform ball; // 쫓아갈 공 트랜스폼
    bool hasBall; // 공을 갖고 있는지 여부 
    float ballDistance; // 공과의 거리
    bool nearTheBall;
    public List<Transform> teamCharacters; // 플레이어 리스트
    public int randomChoice;
    
    public static float teamDistance; // 모든 캐릭터 사이의 공유되는  타입의 변수
    // Start is called before the first frame update
    void Start()
    {
        speed = 1f; // 플레이어의 스피드 초기값
        teamDistance = 10f;
    }

    // Update is called once per frame
    void Update()
    {
        // 볼을 가지지 않고 자신이 가장 볼에 가깝다면 볼을 쫓아 간다.
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
        //공에 가장 가까운 플레이어를 찾기 위해 공에 가장 가까이 있는 캐릭터의 거리 값을 저장할 수 있도록 처리
        //이 조건 안 코드의 teamDistance 값은 점점 작아 질 수밖에 없다
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
