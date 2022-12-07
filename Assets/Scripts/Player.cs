using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;



public class Player : Actor
{
    private SwordBehavior _swordBehavior;

    public SwordBehavior swordBehavior
    {
        get
        {
            return _swordBehavior;
        }
        set
        {
            swordBehavior = _swordBehavior;
        }
    }


    private void CheckPressButton()
    {
        if (Input.GetKeyDown(KeyCode.Keypad1))
        {
            _healthImages.OnDisableHealthSprite.Invoke();
            _swordBehavior = SwordBehavior.Up;
        }
        else if (Input.GetKeyDown(KeyCode.Keypad2))
        {
            _swordBehavior = SwordBehavior.Middle;
        }
        else if (Input.GetKeyDown(KeyCode.Keypad3))
        {
            _swordBehavior = SwordBehavior.Down;
        }
    }

    

    private void StartCoroutineMoveUpSword()
    {
        StartCoroutine("IStartMoveSword", _targetPosition);
    }
    private void StartCoroutineMoveDownSword()
    {
        StartCoroutine("IStartMoveSword", _basePosition);
    }
    private void OnEnable()
    {
        CheckHealthEvent.AddListener(CheckHealth);
        GetBaseAndTargetPositionEvent.AddListener(GetAndSetPositionSword);
        MoveSwordOnTargetPositionEvent.AddListener(StartCoroutineMoveUpSword);
    }
    private void Awake()
    {
        
        
    }

    private void Start()
    {
        _healthImages = GetComponent<HealthImages>();

        _healthActor = 3;

        _swordBehavior = SwordBehavior.Middle;

        StartGetKindHitEvent();
    }

    private void Update()
    {
        CheckPressButton();
    }

    private void OnDisable()
    {
        CheckHealthEvent.RemoveListener(CheckHealth);
        GetBaseAndTargetPositionEvent.RemoveListener(GetAndSetPositionSword);
        MoveSwordOnTargetPositionEvent.RemoveListener(StartCoroutineMoveUpSword);
    }

    IEnumerator IStartMoveSword(Vector3 targetPosition)
    {
        while (true)
        {
            yield return null;
            gameObject.transform.localPosition = MoveSword(targetPosition);
            
            if (Math.Round(gameObject.transform.localPosition.x,2) == Math.Round(targetPosition.x,2))
            {
                yield break;
            }  
        }
    }
}