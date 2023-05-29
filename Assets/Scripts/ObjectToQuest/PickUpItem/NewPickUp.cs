using ObjectToQuest;

public class NewPickUp : PickUpItem
{
    public override void PickUp()
    {
        _playerQuest.ObjectFound(_idName);
        gameObject.SetActive(false);
    }
}