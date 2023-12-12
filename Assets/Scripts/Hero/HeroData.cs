using System;

namespace Hero
{
    public static class HeroData
    {
        public static event Action<int> OnAddMoney; 
        public static int Money;
        public static int XP;
        public static int Armor;
        public static int Attack;

        public static void AddMoney(int count)
        {
            Money += count;
            OnAddMoney?.Invoke(Money);
        }

        public static void LoadProgress()
        {
            Money = ES3.KeyExists("Money") ? ES3.Load<int>("Money") : 0;
            OnAddMoney?.Invoke(Money);
            
            if (ES3.KeyExists("XP"))
            {
                XP = ES3.Load<int>("XP");
            }
        }
        
        public static void SaveProgress()
        {
            ES3.Save("Money", Money);
            ES3.Save("XP", XP);
        }
        
    }
}