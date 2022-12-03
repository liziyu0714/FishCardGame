namespace FishCardGame.Cards
{
    public class Player
    {
        private string playerName = "Default Player";
        private int heart;
        private int maxCardCount;
        private List<Card> cards = new List<Card>();

        public string PlayerName { get => playerName; set => playerName = value; }
        public int Heart { get => heart; set => heart = value; }
        public int MaxCardCount { get => maxCardCount; set => maxCardCount = value; }
        public List<Card> Cards { get => cards; set => cards = value; }

        public Player(string playerName, int heart, List<Card> cards, int maxCardCount)
        {
            PlayerName = playerName;
            Heart = heart;
            this.cards = cards;
            MaxCardCount = maxCardCount;
        }
        public Player(string playerName, int heart = 10, int maxCardCount = 5)
        {
            PlayerName = playerName;
            Heart = heart;
            MaxCardCount = maxCardCount;
        }

        public Player(string playerName)
        {
            PlayerName = playerName;
            Heart = Info.DefaultHeart;
            MaxCardCount = Info.DefaultCardCount;
        }

        public void AddCard(Card card)
        {
            cards.Add(card);
        }
        public void RemoveCard(Card card)
        {
            cards.Remove(card);
        }
        public void ClearCards()
        {
            cards.Clear();
        }
    }

    public static class PlayCard
    {
        public static int CalStars(List<Card> cards)
        {
            int sum = 0;
            foreach (Card card in cards)
            {
                sum += card.GetStar();
            }
            return sum;
        }

        public static List<Card> GenerateNewCards(int count)
        {
            var cards = new List<Card>();
            Random random = new Random();
            for (int i = 0; i < count; i++)
            {
                cards.Add(Info.AllCard[random.Next(0, Info.AllCard.Count)]);
            }
            return cards;

        }

        public static void GetNewCards(Player player)
        {
            player.ClearCards();
            var cards = GenerateNewCards(player.MaxCardCount);
            player.Cards = cards;
            return;
        }

        public static void GetNewCardsAs(Player player, Player asplayer)
        {
            player.ClearCards();
            var cards = GenerateNewCards(player.MaxCardCount);
            int trytime = 0;
            while (Math.Abs(CalStars(cards) - CalStars(asplayer.Cards)) > 3 && trytime++ < 20)
            {
                cards = GenerateNewCards(player.MaxCardCount);
            }
            player.Cards = cards;
            return;
        }
    }
}
