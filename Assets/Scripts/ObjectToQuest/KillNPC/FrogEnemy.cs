namespace ObjectToQuest.KillNPC
{
    public class FrogEnemy : Enemy
    {
        public override void TakeDamage()
        {
            gameObject.SetActive(false);
        }
    }
}