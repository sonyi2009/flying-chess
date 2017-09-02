using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace DOS飞行棋
{
    class Map
    {
        public static int[] map = new int[100];
        //设置道路标签int
        public static void setMap()
        {
            for (int i = 0; i < 100; i++) { map[i] = 0; }
            int[] luckyturn = { 6, 23, 40, 55, 69, 83 };//幸运轮盘◎
            int[] landMine = { 5, 13, 17, 33, 38, 50, 64, 80, 94 };//地雷☆
            int[] pause = { 9, 27, 60, 93 };//暂停▲
            int[] timeTunnel = { 20, 25, 45, 63, 72, 88, 90 };//时空隧道卐
            for (int i = 0; i < luckyturn.Length; i++)
            {
                int n = luckyturn[i];
                map[n] = 1;
            }
            for (int i = 0; i < landMine.Length; i++)
            {
                int n = landMine[i];
                map[n] = 2;
            }
            for (int i = 0; i < pause.Length; i++)
            {
                int n = pause[i];
                map[n] = 3;
            }
            for (int i = 0; i < timeTunnel.Length; i++)
            {
                int n = timeTunnel[i];
                map[n] = 4;
            }
        }
        //根据道路标签返回道路字符
        static string ShowRoad(int index)
        {
            string road = null;
            switch (index)
            {
                case 0:
                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                    road = "□";
                    break;
                case 1:
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    road = "◎";
                    break;
                case 2:
                    Console.ForegroundColor = ConsoleColor.Red;
                    road = "☆";
                    break;
                case 3:
                    Console.ForegroundColor = ConsoleColor.Green;
                    road = "▲";
                    break;
                case 4:
                    Console.ForegroundColor = ConsoleColor.Blue;
                    road = "卐";
                    break;
                case 5:
                    Console.ForegroundColor = ConsoleColor.DarkCyan;
                    road = "<>";
                    break;
                case 6:
                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                    road = "Ａ";
                    break;
                case 9:
                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                    road = "Ｂ";
                    break;
            }
            return road;
        }
        public static void showSteps(ref Player player, int steps, Player[] players)
        {
            if (steps >= 0) { 
            for (int i = 0; i <= steps; i++)
            {
                int address_1 = player.address;
                map[address_1 + i] = 6;
                Console.Clear();
                Introduction.ShowList();
                Introduction.ShowRule(players);
                player.address += i;

                Map.ShowMap(players);

                player.address -= i;
                Console.WriteLine("玩家{0}按任意键扔骰子", player.name);
                Console.WriteLine("玩家{0}扔骰子扔到{1}", player.name, steps);
                Console.WriteLine("玩家{0}开始移动", player.name);
                Thread.Sleep(100);
            }
            player.address += steps;
            Console.ReadKey(true);
            if (player.address == 99)
            {
                Console.WriteLine("{0}无耻的获胜了!!！", player.name);
                Console.ReadKey(true);
            }
            else if (player.address > 99)
            {
                players[0].address = 198 - players[0].address;
            }
            }
            else
            {
                for (int i = 0; i >= steps; i--)
                {
                    int address_1 = player.address;
                    map[address_1 + i] = 6;
                    Console.Clear();
                    Introduction.ShowList();
                    Introduction.ShowRule(players);
                    player.address += i;

                    Map.ShowMap(players);

                    player.address -= i;
                    Console.WriteLine("玩家{0}前进到地雷", player.name);
                    Console.WriteLine("玩家{0}退六格", player.name);
                    Thread.Sleep(100);
                }
                player.address += steps; 
            }
        }
       
        public static void ShowMap(Player[] players)
        {
            if (players[0].address != players[1].address)
            {
                setMap();
                int x = players[0].address;
                map[x] = 6;
                int y = players[1].address;
                map[y] = 9;
            }
            else
            {
                setMap();
                int x = players[0].address;
                map[x] = 5;
            }
            for (int i = 0; i < 29; i++)
            {
                Console.Write(ShowRoad(map[i]));
            }
            Console.Write("\n");
            for (int i = 29; i < 35; i++)
            {
                for (int j = 0; j < 28; j++)
                {
                    Console.Write("  ");
                }
                Console.Write(ShowRoad(map[i]));
                Console.Write("\n");
            }
            for (int i = 63; i >=35; i--)
            {
                Console.Write(ShowRoad(map[i]));
            }
            Console.Write("\n");
            for (int i = 64; i < 70; i++)
            {
                Console.Write(ShowRoad(map[i]));
                for (int j = 0; j < 28; j++)
                {
                    Console.Write("  ");
                }
                Console.Write("\n");
            }
            for (int i = 70; i < 100; i++)
            {
                Console.Write(ShowRoad(map[i]));
            }
            Console.Write("\n");
        }
    }

}
