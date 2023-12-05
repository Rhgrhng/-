namespace 入门知识整和练习
{
    internal class Program
    {
        static void Main(string[] args)
        { //运行后wasd移动，靠近她按j键进行游戏。。。。
            #region 1 控制台相关
            //隐藏光标
            Console.CursorVisible = false;
            //设置窗口大小
            int w = 50;
            int h = 30;
            Console.SetWindowSize(w, h);
            Console.SetBufferSize(w, h);
            #endregion
            #region 2 游戏分层
            int nowSceneID = 1;
            //我是来结束这个循环的
            string gameOverInfo = " ";
            while (true)
            {
                switch (nowSceneID)
                {
                   
                    case 1:
                        #region 开始游戏
                        Console.Clear();
                        Console.SetCursorPosition(w/2-7, 8);
                        Console.Write("获得蓝毒的芳心");
                        //设置编号来决定那部分亮
                        int theScenen = 0;
                        while (true)
                        {    //显示 内容
                            //先设置文字位置 再显示内容
                            Console.SetCursorPosition(w / 2 - 4,13);
                            Console.ForegroundColor=theScenen==0?ConsoleColor.Red:ConsoleColor.White;
                            Console.Write("开始游戏");
                            Console.SetCursorPosition(w/2 - 4,15);
                            Console.ForegroundColor=theScenen==1? ConsoleColor.Red : ConsoleColor.White;
                            Console.Write("退出游戏");
                            //输入 输出
                            //检测玩家输入的一个键内容，且内容不会再控制台上显示
                            char input = Console.ReadKey(true).KeyChar;
                            
                            //跳出的bool值
                            bool isQuit = false;
                            switch(input)
                            {
                                case 'w':
                                case'W':
                                    theScenen--;
                                    if (theScenen < 0)
                                    {
                                        theScenen = 1;
                                    }
                                    break;
                                case 's':
                                case 'S':
                                    theScenen++;
                                    if (theScenen > 1)
                                    {
                                        theScenen=0;
                                    }
                                    break;
                                case 'j':
                                case 'J':
                                    if(theScenen == 0)
                                    {
                                        //1.跳转到下一个界面
                                        //2.跳出当前(swith)whisle循环,在while中定义个bool break值
                                        nowSceneID = 2;
                                        isQuit = true;
                                    }
                                    else
                                    {    //关闭喽
                                        Environment.Exit(0);
                                    }
                                    break;
                            }
                            if (isQuit == true)
                            {
                                break;
                            }
                        }
                        #endregion                       
                        break;
                    case 2:
                        Console.Clear();
                        #region 红墙


                        //红色字体
                        Console.ForegroundColor=ConsoleColor.Red;
                        //上方墙
                        for (int i = 0; i < w; i+=2)
                        {
                            
                            //设置光标位置
                            Console.SetCursorPosition(i, 0);
                            Console.Write("■");
                            //下方墙
                            Console.SetCursorPosition(i, h - 1);
                            Console.Write("■");
                            //中间墙
                            Console.SetCursorPosition(i, h - 6);
                            Console.Write("■");
                        }
                        //下方墙
                        //for (int i = 0; i < w; i += 2)
                        //{

                        //    //设置光标位置
                        //    Console.SetCursorPosition(i, h-1);
                        //    Console.Write("■");
                        //}
                        //中间墙
                        //for (int i = 0; i < w;i+= 2)
                        //{
                            
                        //    Console.SetCursorPosition(i, h - 6);
                        //    Console.Write("■");
                        //}                       
                        for (int i = 0; i < h; i ++)
                        {
                            //左边的墙
                            Console.SetCursorPosition(0, i);
                            Console.Write("■");
                            //右墙
                            Console.SetCursorPosition(w - 2, i);
                            Console.Write("■");
                        }
                        ////右墙
                        //for (int i = 0; i < h; i ++)
                        //{


                        //    Console.SetCursorPosition(w-2, i);
                        //    Console.Write("■");
                        //}
                        #endregion
                        //boss相关
                        #region boss属性
                        int atkMin = 8;
                        int atkMax = 13;
                        int hp = 100;
                        int X = 24;
                        int Y = 15;
                        string boosIncon = "她";
                        //声明的颜色变量 
                        ConsoleColor bossColor = ConsoleColor.Blue;
                        #endregion
                        #region 玩家属性
                        int px = 4;
                        int py = 5;
                        int pAtkMin = 9;
                        int pAtkMax = 12;
                        int pHp = 100;
                        string playerIncon = "我";
                        ConsoleColor playerColor = ConsoleColor.White;
                        #endregion
                        char playerInput;
                        #region  芳心相关
                        int heartX = 24;
                        int heartY = 5;
                        string heartIncon = "心";
                        ConsoleColor heartColor = ConsoleColor.Red;
                        #endregion
                        
                        #region 战斗状态
                        bool isFight = false;
                        bool isOver =false;
                        #endregion
                        while (true)
                        {   //活着时才绘制
                            #region boss相关
                            if (hp > 0)
                            {
                                Console.SetCursorPosition(X, Y);
                                Console.ForegroundColor = bossColor;
                                Console.Write(boosIncon);
                            }
                            else
                            {
                                #region 芳心相关
                                Console.SetCursorPosition(heartX, heartY);
                                Console.ForegroundColor = heartColor;
                                Console.Write(heartIncon);
                                #endregion

                            }
                            #endregion
                            #region 战斗相关


                            //画出玩家
                            Console.SetCursorPosition(px, py);
                            Console.ForegroundColor = playerColor;
                            Console.Write(playerIncon);
                            //得到玩家输入
                            playerInput = Console.ReadKey(true).KeyChar;
                            //战斗状态
                            if (isFight)
                            {   //按j战斗
                                if (playerInput == 'j' || playerInput == 'J')
                                {
                                    if (pHp < 0)
                                    {  //输掉了
                                        nowSceneID = 3;
                                        gameOverInfo = "取悦失败";
                                        break;
                                    }
                                    else if (hp < 0)
                                    {   //赢了
                                        Console.SetCursorPosition(X, Y);
                                        Console.Write("   ");
                                        isFight = false;
                                    }
                                    else
                                    {
                                        //我逗她
                                        Random r = new Random();
                                        //得到随机精力了
                                        int atk = r.Next(pAtkMin, pAtkMax);
                                        //boss血量减少
                                        hp -= atk;
                                        //打印信息,改颜色
                                        Console.ForegroundColor = ConsoleColor.Green;
                                        //消除原本信息
                                        Console.SetCursorPosition(2, h - 4);
                                        Console.Write("                      ");
                                        //输入信息
                                        Console.SetCursorPosition(2, h - 4);
                                        Console.Write("我和她缠斗消耗了她{0}精力，她还剩{1}的精力", atk, hp);
                                        //她逗我
                                        if (hp > 0)
                                        {
                                            //得到随机攻击力
                                            atk = r.Next(atkMin, atkMax);
                                            pHp -= atk;
                                            //打印信息,改颜色
                                            Console.ForegroundColor = ConsoleColor.Yellow;
                                            //消除原本信息
                                            Console.SetCursorPosition(2, h - 3);
                                            Console.Write("                      ");
                                            //输入信息
                                            Console.SetCursorPosition(2, h - 3);
                                            Console.Write("她和我缠斗消耗了我{0}精力，我还剩{1}的精力", atk, pHp);
                                        }
                                        else
                                        {
                                            //擦除
                                            Console.SetCursorPosition(2, h - 5);
                                            Console.Write("                                         ");
                                            Console.SetCursorPosition(2, h - 4);
                                            Console.Write("                                         ");
                                            Console.SetCursorPosition(2, h - 3);
                                            Console.Write("                                         ");
                                            //赢了
                                            Console.SetCursorPosition(2, h - 5);
                                            Console.Write("恭喜你获得了她的芳心");
                                            Console.SetCursorPosition(2, h - 4);
                                            Console.Write("按j继续");
                                        }
                                    }
                                }
                            }
                            #endregion
                            else
                            //非战斗状态
                            {

                                #region 6 玩家移动
                                //擦除
                                Console.SetCursorPosition(px, py);
                                Console.Write("  ");
                                //改位置
                                switch (playerInput)
                                {
                                    case 'w':
                                    case 'W':
                                        py--;
                                        if (py < 1)
                                        {  //向上将她拉回来
                                            py = 1;
                                        }
                                        else if (py == Y && px == X && hp > 0)
                                        {  //不会覆盖boss
                                            py++;
                                        }
                                        else if
                                        (px == heartX && py == heartY && hp <= 0)
                                        {
                                            py++;
                                        }
                                        break;
                                    case 'S':
                                    case 's':
                                        py++;
                                        if (py > h - 7)
                                        {
                                            py = h - 7;
                                        }
                                        else if (py == Y && px == X && hp > 0)
                                        {  //不会覆盖boss
                                            py--;
                                        }
                                        else if
                                        (py == heartY && px == heartX && hp <= 0)
                                        {
                                            py--;
                                        }

                                        break;
                                    case 'A':
                                    case 'a':
                                        px -= 2;
                                        if (px < 2)
                                        {
                                            px = 2;
                                        }
                                        else if (py == Y && px == X && hp > 0)
                                        {
                                            px += 2;
                                        }
                                        else if
                                        (py == heartY && px == heartX && hp <= 0)
                                        {
                                            py += 2;
                                        }
                                        break;
                                    case 'D':
                                    case 'd':
                                        px += 2;
                                        if (px > w - 4)
                                        {
                                            px = w - 4;
                                        }
                                        else if (py == Y && px == X && hp > 0)
                                        {
                                            px -= 2;
                                        }
                                        else if
                                        (py == heartY && px == heartX && hp <= 0)
                                        {
                                            py -= 2;
                                        }
                                        break;
                                    case 'j':
                                    case 'J':
                                        //开始战斗
                                        if ((px == X && py == Y - 1 || px == X && py == Y + 1
                                            || py == Y && px == X - 2 || py == Y && px == X + 2) && hp > 0)
                                        {
                                            isFight = true;
                                            //开始战斗！
                                            Console.SetCursorPosition(2, h - 5);
                                            Console.ForegroundColor = ConsoleColor.White;
                                            Console.Write("开始和她缠斗了，按j继续");
                                            Console.SetCursorPosition(2, h - 4);
                                            Console.Write("我的精力有{0}", pHp);
                                            Console.SetCursorPosition(2, h - 3);
                                            Console.Write("她的精力有{0}", hp);
                                        }
                                        #endregion
                                        else if ((px == heartX && py == heartY - 1 || px == heartX && py == heartY + 1
                                            || py == heartY && px == heartX - 2 || py == heartY && px == heartX + 2) && hp <= 0)
                                        {   //下一个
                                            nowSceneID = 3;
                                            isOver = true;
                                            gameOverInfo = "获取芳心";
                                        }
                                        break;
                                }

                            }

                            //跳出while循环
                            if (isOver)
                            {
                                break;
                            }
                        }
                        break;
                    case 3:
                        Console.Clear();

                        Console.SetCursorPosition(w / 2 - 7, 8);
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.Write("GameOver");
                        Console.SetCursorPosition(w / 2 - 7, 9);
                        Console.Write(gameOverInfo);
                        //界面选择
                        int nowindex = 0;
                        while (true)
                        {    //显示 内容
                            //先设置文字位置 再显示内容
                            Console.SetCursorPosition(w / 2 - 4, 13);
                            Console.ForegroundColor = nowindex == 0 ? ConsoleColor.Red : ConsoleColor.White;
                            Console.Write("反回开始界面");
                            Console.SetCursorPosition(w / 2 - 4, 15);
                            Console.ForegroundColor = nowindex == 1 ? ConsoleColor.Red : ConsoleColor.White;
                            Console.Write("退出游戏");
                            //输入 输出
                            //检测玩家输入的一个键内容，且内容不会再控制台上显示
                            char input = Console.ReadKey(true).KeyChar;

                            //跳出的bool值
                            bool isQuit = false;
                            switch (input)
                            {
                                case 'w':
                                case 'W':
                                    nowindex--;
                                    if (  nowindex < 0)
                                    {
                                        nowindex = 1;
                                    }
                                    break;
                                case 's':
                                case 'S':
                                    nowindex++;
                                    if (nowindex > 1)
                                    {
                                        nowindex = 0;
                                    }
                                    break;
                                case 'j':
                                case 'J':
                                    if (nowindex == 0)
                                    {
                                        //1.跳转到下一个界面
                                        //2.跳出当前(swith)whisle循环,在while中定义个bool break值
                                        nowSceneID = 1;
                                        isQuit = true;
                                    }
                                    else
                                    {    //关闭喽
                                        Environment.Exit(0);
                                    }
                                    break;
                            }
                            if (isQuit == true)
                            {
                                break;
                            }
                        }
                        break;





                }
            }
            #endregion









        }
    }
}