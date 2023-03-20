namespace ObjectToQuest
{
    public class FarmerNPC : TalkNPC
    {
        public override void Talk()
        {
            _playerQuest.NpcTalked(_idName);
        }
    }
}