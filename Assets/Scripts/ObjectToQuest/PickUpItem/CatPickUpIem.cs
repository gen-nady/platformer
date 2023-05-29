using ObjectToQuest;

public class CatPickUpIem : PickUpItem
{
    public override void PickUp()
    {
        _playerQuest.ObjectFound(_idName);
        gameObject.SetActive(false);
    }
}
