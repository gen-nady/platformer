namespace Quest.FoundObjects
{
    public class TestBallFound : Found
    {
        public void PickUp()
        {
            _playerQuest.PickUp<TestBallFound>();
            Destroy(gameObject);
        }
    }
}