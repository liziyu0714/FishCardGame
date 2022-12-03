using FishCardGame.Cards;
namespace FishCardGame.ConsoleTest
{
    internal class Program
    {
        static void Main(string[] args)
        {
            
            Player testPlayer = new Player("liziyu0714" , 10 , 20);
            PlayCard.GetNewCards(testPlayer);
            Console.WriteLine(testPlayer.Cards.Count);
            Console.WriteLine(PlayCard.CalStars(testPlayer.Cards));
            foreach(Card card in testPlayer.Cards)
            {
                Console.WriteLine(card.ToString());
            }

            Player testPlayer2 = new Player("Fish0714" , 10 , 20);
            PlayCard.GetNewCardsAs(testPlayer2, testPlayer);
            Console.WriteLine(testPlayer2.Cards.Count);
            Console.WriteLine(PlayCard.CalStars(testPlayer2.Cards));
            foreach (Card card in testPlayer2.Cards)
            {
                Console.WriteLine(card.ToString());
            }
            int inputOperateNumber = -1;
            inputOperateNumber =    int.Parse(Console.ReadLine());
            while(inputOperateNumber != 0)
            {
                
                switch(inputOperateNumber )
                {
                    case 1: int num = int.Parse(Console.ReadLine());
                        testPlayer.Cards[num].UseCard(self: testPlayer);
                        break;
                    case 2: int num1 = int.Parse(Console.ReadLine());
                        testPlayer.Cards[num1].UseCard(target: testPlayer2);
                        break;
                }
                Console.WriteLine($"{testPlayer.PlayerName} , Heart : {testPlayer.Heart}");
                Console.WriteLine($"{testPlayer2.PlayerName} , Heart : {testPlayer2.Heart}");
                inputOperateNumber = int.Parse(Console.ReadLine());
            }

            /*
            Player testPlayer = new Player("liziyu0714", 10, 20);
            PlayCard.GetNewCards(testPlayer);
            Console.WriteLine(testPlayer.Cards.Count);
            Console.WriteLine(PlayCard.CalStars(testPlayer.Cards));
            foreach (Card card in testPlayer.Cards)
            {
                Console.WriteLine(card.ToString());
            }
            if (testPlayer.Cards[0].GetType() == typeof(CureCard))
            {
                testPlayer.Cards[0].UseCard(testPlayer);
            }
            Console.WriteLine(testPlayer.Heart);
            */
            
        }
    }
}