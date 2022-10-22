using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PositionStorage : MonoBehaviour
{
    [SerializeField]
    private GameObject _player;

    [SerializeField]
    private GameObject _enemy;

    private enum SidePositionSword
    {
        Left = 0,
        Right = 1,
    }


    private Vector3[] _basePosition = {new Vector3(-8.9f, -1.4f, 0f), new Vector3(8.9f, -1.4f, 0f)};

    private Vector3[] _targetPosition = { new Vector3(-6.3f, -1.4f, 0f), new Vector3(6.3f, -1.4f, 0f)};





    private void RandomSidePositionSword()
    {
        int value = Random.Range(0, 2);
        if (value == 0)
        {
            SendPositionActors(0,1);
        }
        else if (value == 1)
        {
            SendPositionActors(1, 0);
        }

    }

    private void SendPositionActors(int numLeftSide, int numRightSide)
    {
        if (_player.TryGetComponent<Actor>(out _))
        {
            _player.GetComponent<Player>().GetBaseAndTargetPositionEvent.Invoke(_basePosition[numLeftSide], _targetPosition[numLeftSide]);
            _enemy.GetComponent<Enemy>().GetBaseAndTargetPositionEvent.Invoke(_basePosition[numRightSide], _targetPosition[numRightSide]);
        }
    }

    private void SetStandartParam()
    {
        RandomSidePositionSword();
    }

    private void StartStandartFunctions()
    {

    }


    void Start()
    {
        SetStandartParam();
    }

    void Update()
    {
        
    }
}
