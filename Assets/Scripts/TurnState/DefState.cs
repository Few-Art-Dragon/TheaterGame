using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefState : ITurnState
{

    public void ŅalculateTurn(Actor player, Actor enemy)
    {
        if (player.SwordState != enemy.SwordState)
        {
            player.CheckHealthEvent.Invoke();
        }
    }
}
