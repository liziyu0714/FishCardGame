using FishCardGame.Cards;
namespace FishCardGame.FirstDemo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("FishCardGame 第一版Demo , 基于0.0.1-alpha1");
            Console.WriteLine("输入初始生命值");
            Info.DefaultHeart = int.Parse(Console.ReadLine()!);
            Console.WriteLine("输入默认手牌数");
            Info.DefaultCardCount = int.Parse(Console.ReadLine()!);
            Player player = new Player("玩家");
            Player computer = new Player("电脑");
            Console.WriteLine("输入玩家姓名");
            player.PlayerName = Console.ReadLine()!;
            Console.WriteLine("正在发牌...");
            PlayCard.GetNewCards(player);
            PlayCard.GetNewCardsAs(computer, player);
            int cnt = 0, restartnum = 5;
            Random random = new Random();
            while (player.Heart > 0 && computer.Heart > 0)
            {
                Console.WriteLine($"第{++cnt}回合\n你的回合");
                if (player.Cards.Count == 0)
                {
                    Console.WriteLine("你的牌组已耗尽，正在重新发牌...");
                    PlayCard.GetNewCards(player);
                }
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"{player.PlayerName} 的牌组: ");
                for (int i = 0; i < player.Cards.Count; i++)
                {
                    Console.WriteLine($"[{i + 1}] {player.Cards[i].ToString()}");
                }
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine($"输入你要使用的卡牌编号,输入-1来重新发牌，手动重新发牌的次数还剩{restartnum}次");
                int num = int.Parse(Console.ReadLine()!);
                if (num > player.Cards.Count)
                {
                    Console.WriteLine("输入错误，超出了所有牌的范围");
                    continue;
                }
                if (num == -1)
                {
                    if (restartnum > 0)
                    {
                        restartnum--;
                        player.ClearCards();
                        computer.ClearCards();
                    }
                    else
                    {
                        Console.WriteLine("没有洗牌次数了");
                    }
                    continue;
                }
                player.Cards[num - 1].UseCard(player, computer);
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"你使用了{player.Cards[num - 1].ToString()} , 你现在的生命: {player.Heart} , 对方的生命 : {computer.Heart}");
                Console.ForegroundColor = ConsoleColor.White;
                player.RemoveCard(player.Cards[num - 1]);
                if (computer.Heart <= 0)
                {
                    break;
                }
                Console.WriteLine("对方回合");
                if (computer.Cards.Count == 0)
                {
                    Console.WriteLine("对方牌组耗尽，正在重新发牌...");
                    PlayCard.GetNewCardsAs(computer, player);
                }
                int tnum = random.Next(1, computer.Cards.Count);
                computer.Cards[tnum - 1].UseCard(computer, player);
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"对方使用了{computer.Cards[tnum - 1].ToString()} , 你现在的生命: {player.Heart} , 对方的生命 : {computer.Heart}");
                Console.ForegroundColor = ConsoleColor.White;
                computer.RemoveCard(computer.Cards[tnum - 1]);
            }
            Console.Clear();
            if (computer.Heart <= 0)
            {
                Console.WriteLine("你赢了");
            }
            else
            {
                Console.WriteLine("你输了");
            }

            Console.ReadLine();
        }
    }
}