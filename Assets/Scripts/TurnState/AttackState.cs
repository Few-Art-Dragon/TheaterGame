public class AttackState : ITurnState
{
   
    public void ŅalculateTurn(Actor player, Actor enemy)
    {
        if (player.SwordState != enemy.SwordState)
        {
            enemy.CheckHealthEvent.Invoke();
        }
    }
}
