using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


public class HealthImages : MonoBehaviour
{
    [HideInInspector]
    public UnityEvent OnDisableHealthSprite = new UnityEvent();

    [SerializeField]
    protected List<SpriteRenderer> _healthSprites = new List<SpriteRenderer>();

    protected void DisableHealthSprite()
    {
        foreach (var sprite in _healthSprites)
        {
            if (sprite.enabled)
            {
                sprite.enabled = false;
                break;
            }
        }    
    }

    private void Start()
    {
        
    }

    private void Update()
    {
        
    }

}
