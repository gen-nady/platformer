namespace ObjectToQuest
{
    public class ApplePickUpItem : PickUpItem
    {
        public override void PickUp()
        {
            _playerQuest.ObjectFound(_idName);
            gameObject.SetActive(false);
        } 
    }
}