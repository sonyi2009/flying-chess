using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DOS飞行棋
{
    class Introduction
    {
        public static void ShowRule(Player[] players)
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("玩家 {0} 的士兵用A表示",players[0].name);
            Console.WriteLine("玩家 {0} 的士兵用B表示", players[1].name);
            Console.WriteLine("图例:幸运轮盘:◎   地雷:☆   暂停:▲   时空隧道:卐");
        }
        public static void ShowList()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("***************************************");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("***************************************");
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("***************飞行棋游戏**************");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("***************************************");
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("***************************************");
        }
    }
}
