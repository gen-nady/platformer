namespace ObjectToQuest
{
    public class BananaPickUpItem : PickUpItem
    {
        public override void PickUp()
        {
            _playerQuest.ObjectFound(_idName);
            Destroy(gameObject);
        } 
    }
}