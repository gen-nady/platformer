namespace PickUpObject
{
    public class ApplePickUpItem : PickUpItem
    {
        public override void PickUp()
        {
            _playerQuest.ObjectFound(_idName);
            Destroy(gameObject);
        } 
    }
}