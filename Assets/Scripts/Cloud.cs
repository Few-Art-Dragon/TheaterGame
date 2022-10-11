using System.Collections;
using System.Collections.Generic;
using UnityEngine;

enum StateMoveCloud
{
    Horizontal,
    Vertical,
    Both
}

public class Cloud : MonoBehaviour
{
    [SerializeField] 
    private StateMoveCloud stateMoveCloud;

    [SerializeField]
    private bool _randomSpeed;


    [SerializeField]
    private Vector2 _speedCloud;

    [SerializeField]
    private Vector2 _maxRandomSpeedCloud;

    [SerializeField]
    private Vector2 _minRandomSpeedCloud;

     
    

    

    private void SetStandartParam()
    {
        stateMoveCloud = StateMoveCloud.Horizontal;
    }

    private void StartStandartFunctions()
    {
        CheckRandom();
    }
    private void CheckRandom()
    {
        if (_randomSpeed)  CheckStateMoveCloud();
    }

    private void CheckStateMoveCloud()
    {
        switch (stateMoveCloud)
        {
            case StateMoveCloud.Horizontal:
                RandomSpeedCloud(new Vector2(_minRandomSpeedCloud.x, _maxRandomSpeedCloud.x), new Vector2(0,0));
                break;
            case StateMoveCloud.Vertical:
                RandomSpeedCloud( new Vector2(0,0), new Vector2(_minRandomSpeedCloud.y, _maxRandomSpeedCloud.y));
                break;
            case StateMoveCloud.Both:
                RandomSpeedCloud( new Vector2(_minRandomSpeedCloud.x, _maxRandomSpeedCloud.x), new Vector2(_minRandomSpeedCloud.y, _maxRandomSpeedCloud.y));
                break;
        }
    }

    private void RandomSpeedCloud(Vector2 horizontal, Vector2 vertical)
    {
        _speedCloud.x = Random.Range(horizontal.x, horizontal.y);
        _speedCloud.y = Random.Range(vertical.x, vertical.y);
    }

    private void MoveCloud()
    {
        gameObject.transform.Translate(_speedCloud * Time.deltaTime, Space.Self);
    }

    private void ReverseSpeedCloud()
    {
        _speedCloud = -_speedCloud; 
    }


    void Start()
    {
        SetStandartParam();
        StartStandartFunctions();
    }


    void Update()
    {
        MoveCloud();
    }

    void OnBecameInvisible()
    {
        ReverseSpeedCloud();
    }
}
