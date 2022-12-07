public class AttackState : ITurnState
{
   
    public void �alculateTurn(Actor player, Actor enemy)
    {
        if (player.SwordState != enemy.SwordState)
        {
            enemy.CheckHealthEvent.Invoke();
        }
    }
}
