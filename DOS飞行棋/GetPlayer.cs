using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace DOS飞行棋
{
    class GetPlayer
    {
        static void Loading()
        {
            for (int i = 0; i < 10; i++)
            {
                Console.Clear();
                Console.Write("游戏已经启动，正在载入地图{0}%", i * 10);
                Thread.Sleep(1200-i*i*i);
            }
            Console.Clear();
        }
        public static int GetPlayerInfo(ref Player[] players)
        {
            Console.Write("请输入玩家一名称：");
            players[0].name = Console.ReadLine();
            while (players[0].name == "")
            {
                Console.Write("玩家一输入名称为空请重新输入：");
                players[0].name = Console.ReadLine();
            }
            Console.Write("请输入玩家二名称：");
            players[1].name = Console.ReadLine();
            while (players[1].name == "")
            {
                Console.Write("玩家二输入名称为空请重新输入：");
                players[1].name = Console.ReadLine();
            }
            while (players[1].name == players[0].name)
            {
                Console.Write("玩家二与玩家一重名，请重新输入:");
                players[1].name = Console.ReadLine();
            }
            Thread.Sleep(1000);
            Thread t = new Thread(Loading);
            t.Start();
            t.Join();
            Console.Clear();
            return 0;
        }
    }
}
