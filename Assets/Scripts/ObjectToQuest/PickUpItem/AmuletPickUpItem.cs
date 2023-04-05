namespace ObjectToQuest
{
    public class AmuletPickUpItem : PickUpItem
    {
        public override void PickUp()
        {
            _playerQuest.ObjectFound(_idName);
            gameObject.SetActive(false);
        } 
    }
}