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

    private Vector3[] _basePosition = {new Vector3(-8.9f, -1.4f, 0f), new Vector3(8.9f, -1.4f, 0f)};

    private Vector3[] _targetPosition = { new Vector3(-6.3f, -1.4f, 0f), new Vector3(6.3f, -1.4f, 0f)};


    private void SendPositionActors()
    {
        _player.GetComponent<Player>().GetBaseAndTargetPositionEvent.Invoke(_basePosition[0], _targetPosition[0]);
        _enemy.GetComponent<Enemy>().GetBaseAndTargetPositionEvent.Invoke(_basePosition[1], _targetPosition[1]);
    }

    void Start()
    {
        SendPositionActors();
    }

    void Update()
    {
        
    }
}
