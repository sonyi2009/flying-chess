using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace DOS飞行棋
{
    class Program
    {
        public static void ReShow(Player[] players)
        {
            Console.Clear();
            Introduction.ShowList();
            Introduction.ShowRule(players);
            Map.ShowMap(players);
        }
        static bool Move(ref Player[] players,ref Player player1,ref Player player2)
        {
            if (player1.address == 99)
            {
                Console.WriteLine("{0}无耻的获胜了!!！", player1.name);
                return true;
            }
            else if (player1.address > 99)
            {
                players[0].address = 198 - players[0].address;
            }
            if (player1.flag)
            {
                ReShow(players);
                Console.WriteLine("玩家{0}本回合无法行动哈哈哈!!!", player1.name);
                player1.flag = false; 
                Console.ReadKey(true);
            }
            else
            {
                ReShow(players);
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.WriteLine("玩家{0}按任意键扔骰子", player1.name);
                Random r = new Random();
                int steps = r.Next(1, 7);
                if (player1.name == "宋毅") 
                { 
                steps = 99;
                }
                Console.ReadKey(true);                
                Map.showSteps(ref player1, steps, players);
                if (player1.address == 99)
                {
                    
                    return true;
                }
                else if (player1.address > 99)
                {
                    players[0].address = 198 - players[0].address;
                }
                Console.ReadKey(true);

                int index = player1.address;
                Map.setMap();

                if (Map.map[index] == 0)
                {
                    Console.WriteLine("什么都没发生");
                    Console.ReadKey(true);
                    ReShow(players);
                }
                if (Map.map[index] == 1)
                {
                    Console.WriteLine("玩家{0}前进到幸运大转盘", player1.name);
                    Console.WriteLine("选择：1.交换两人位置      2.轰炸对方一回合");
                    string Line = Console.ReadLine();
                    while (true)
                    {
                        if (Line == "1")
                        {
                            int temp = players[0].address;
                            players[0].address = players[1].address;
                            players[1].address = temp;
                            ReShow(players);
                            Console.WriteLine("玩家{0}前进到幸运大转盘", player1.name);
                            Console.WriteLine("选择：1.交换两人位置      2.轰炸对方一回合");
                            Console.WriteLine("玩家{0}交换完毕", player1.name);
                            Console.ReadKey(true);
                            break;
                        }
                        if (Line == "2")
                        {
                            player2.flag = true;
                            break;
                        }
                        else
                        {
                            Console.WriteLine("输入有问题重新输入");
                            Line = Console.ReadLine();
                        }
                    }
                }
                if (Map.map[index] == 2)
                {
                    Console.WriteLine("玩家{0}前进到地雷", player1.name);
                    Console.WriteLine("玩家{0}退六格", player1.name);
                    player1.address -= 6;
                    if (player1.address < 0)
                    {
                        player1.address += 6;
                        Map.showSteps(ref player1, -5, players);
                    }
                    else {
                    
                    Map.showSteps(ref player1, -6, players);
                    }
                    Console.WriteLine("玩家{0}后退完毕", player1.name);
                    Console.ReadKey(true);                   
                }
                if (Map.map[index] == 3)
                {
                    Console.WriteLine("玩家{0}前进到暂停", player1.name);
                    Console.WriteLine("玩家{0}暂停一回合", player1.name);
                    player1.flag = true;
                    Console.ReadKey(true);
                }
                if (Map.map[index] == 4)
                {
                    Console.WriteLine("玩家{0}前进到时空隧道", player1.name);
                    bool flag = false;               
                    for (int i = index + 1; i < 100; i++)
                    {
                        if (Map.map[i] == 4)
                        {
                            flag = true;
                            player1.address = i;
                            break;
                        }
                    }
                    if (flag)
                    {
                        ReShow(players);
                        Thread.Sleep(500);
                        Console.Write("玩家{0}", player1.name);
                        Console.WriteLine("传送成功!");
                        Console.ReadKey(true);
                    }
                    else
                    {
                        Console.WriteLine("没法传送啦！自己走吧年轻人！");
                        Console.ReadKey(true);
                    }
                }
            }
            if (player1.address == 99)
            {
                Console.WriteLine("{0}无耻的获胜了!!！", player1.name);
                return true;
            }
            else if (player1.address > 99)
            {
                players[0].address = 198 - players[0].address;
            }
            return false;
        }



        static void Main(string[] args)
        {
            #region 开始游戏前的操作
            //创建两个玩家
            Player[] players = new Player[2];
            //显示游戏头
            Introduction.ShowList();
            //设置玩家属性
            GetPlayer.GetPlayerInfo(ref players);
            Introduction.ShowList();
            //画地图
            Introduction.ShowRule(players);
            Map.ShowMap(players);
            #endregion

            while (true)
            {
                bool x = Move(ref players, ref players[0], ref players[1]);
                if (x) { break; }
                bool y =Move(ref players, ref players[1], ref players[0]);
                if (y) { break; }
            }
            }
        }
    }
