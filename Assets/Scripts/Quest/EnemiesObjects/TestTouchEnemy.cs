namespace Quest.EnemiesObjects
{
    public class TestTouchEnemy : Enemy
    {
        public void Kill()
        {
            _playerQuest.DeadEnemy<TestTouchEnemy>();
            Destroy(gameObject);
        }
    }
}