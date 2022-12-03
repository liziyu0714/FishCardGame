namespace FishCardGame.Cards
{
    public static class Info
    {
        public static int TotalCardCount = 0;
        public static int Nextid = 0;
        public static int Previd = 0;
        public static int DefaultHeart = 10;
        public static int DefaultCardCount = 5;
        public static int GetNextId()
        {
            return Nextid++;
        }
        public static List<Card> AllCard = new List<Card>() {new AttackCard("攻击 I" ,"对对手造成1点伤害" , 1 ,1 ,GetNextId()) ,
            new AttackCard("攻击 II" ,"对对手造成2点伤害",2, 2 , GetNextId()) ,
            new AttackCard("攻击 III" ,"对对手造成3点伤害" , 3,3 , GetNextId()) ,
            new AttackCard("攻击 IV" ,"对对手造成4点伤害" , 4,4 , GetNextId()) ,
            new AttackCard("攻击 V" ,"对对手造成5点伤害" ,5, 5 , GetNextId()) ,
            new CureCard("治疗 I" ,"恢复1点生命" ,1, 1 , GetNextId()) ,
            new CureCard("治疗 II" ,"恢复2点生命" ,2, 2 , GetNextId()) ,
            new CureCard("治疗 III" ,"恢复3点生命" ,3, 3 , GetNextId()) ,
            new CureCard("治疗 IV" ,"恢复4点生命" , 4 ,4, GetNextId()) ,
            new CureCard("治疗 V" ,"恢复5点生命" , 5,5 , GetNextId()),
            new MakeCard("摸牌 I" , "多拿一张牌" , 3 , 1 , GetNextId()) , 
            new MakeCard("摸牌 II" , "多拿两张牌" , 4 , 2 , GetNextId()) ,
            new MakeCard("摸牌 III" , "多拿三张牌" , 5 , 3 , GetNextId()) 
        };

        public static Player Empty = new Player("Empty", 0, 0);
    }
    public class Card
    {
        string name = "Default Card";
        string info = "Default Card Info.This Card do not contain any infomation";
        int id;
        int star;
        public Card()
        {
            Name = "Default Card";
            Id = -1;
            Info = "Default Card Info.This Card do not contain any infomation";
        }
        public Card(string name, int id)
        {
            this.Name = name;
            this.Id = id;
            Info = $"{name} do not contain any infomation";
        }
        public Card(string name, string info, int id, int star)
        {
            this.Name = name;
            this.Info = info;
            this.Id = id;
            this.star = star;
        }

        public string Name { get => name; set => name = value; }
        public string Info { get => info; set => info = value; }
        public int Id { get => id; set => id = value; }

        public int GetStar()
        {
            return this.star;
        }
        public override string ToString()
        {
            return $"{Name} , id: {Id} , info :{Info}";
        }

        public virtual void UseCard( Player? self = null , Player? target = null)
        {

        }
    }

    public class AttackCard : Card
    {
        int AttackValue;

        public AttackCard(int attackValue)
        {
            AttackValue = attackValue;
        }
        public AttackCard(string name = "Default Attack Card", string info = "Default Attack Card , This Card do not contain any infomation", int attackValue = 1, int star = 0, int id = -1) : base(name, info, id,star)
        {
            AttackValue = attackValue;
        }

        public override void UseCard( Player? self = null , Player? target = null)
        {
            target!.Heart -= AttackValue;
        }
    }

    public class CureCard : Card
    {
        int CureValue;

        public CureCard(int cureValue)
        {
            CureValue = cureValue;
        }

        public CureCard(string name = "Default Cure Card", string info = "Default Cure Card , This Card do not contain any infomation", int cureValue = 1, int star = 0, int id = -1) : base(name, info, id,star)
        {
            CureValue = cureValue;
        }
        public override void UseCard(Player? self = null, Player? target = null)
        {
            self!.Heart += CureValue;
        }
    }

    public class MakeCard : Card
    {
        int Count;
        public MakeCard(int count)
        {
            Count = count;
        }

        public MakeCard(string name = "Default Make Card", string info = "Default Make Card , This Card do not contain any infomation", int count = 1, int star = 0, int id = -1) : base(name, info, id, star)
        {
            Count = count;
        }
        public override void UseCard(Player? self = null, Player? target = null)
        {
            Random random = new Random();
            for(int i = 0; i < Count; i++)
            {
                self!.AddCard(FishCardGame.Cards.Info.AllCard[random.Next(0, FishCardGame.Cards.Info.AllCard.Count)]);
            }
        }
    }
}