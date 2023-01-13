using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    float gameSpeed = 1;
    // Start is called before the first frame update
    void Start()
    {
        instance = this;
    }

    public void SetMoney(float money)
    {
        money += gameSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
