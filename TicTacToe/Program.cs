using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace TicTacToe
{
    class Program
    {
        //Make Array for the board 
        static char[] arr = { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9' };
        static int player = 1;
        static int choice;
        static int flag = 0;
        
        
        static void Main(string[] args)

        {
            Console.Title = "TicTacToe";
            String title = @"
       (                                                        )       
  *   ))\ )  (            *   )   (       (            *   ) ( /(       
` )  /(()/(  )\         ` )  /(   )\      )\         ` )  /( )\()) (    
 ( )(_))(_)|((_)   ___   ( )(_)|(((_)(  (((_)   ___   ( )(_)|(_)\  )\   
(_(_()|_)) )\___  |___| (_(_()) )\ _ )\ )\___  |___| (_(_())  ((_)((_)  
|_   _|_ _((/ __|       |_   _| (_)_\(_|(/ __|       |_   _| / _ \| __| 
  | |  | | | (__          | |    / _ \  | (__          | |  | (_) | _|  
  |_| |___| \___|         |_|   /_/ \_\  \___|         |_|   \___/|___|
";

            Console.WriteLine(title.PadLeft(30));
                Board();
                GetNames(out string p1Name, out string p2Name);
                GetP1Symbol(p1Name, p2Name, out string p1Choice);
                var p2Choice = MarkChoice(p1Choice);

           do
            {

                Console.Clear();
                Console.WriteLine(title.PadLeft(30));
                Console.WriteLine("   |" + p1Name + " is " + p1Choice + "'s|" + "  -----------------------------  |" + p2Name + " is " + p2Choice + "'s|");
                Console.WriteLine("\n");

                if (player % 2 == 0)
                {
                    Console.WriteLine("                             " + p2Name + "'s Turn");
                }
                else
                {
                    Console.WriteLine("                             " + p1Name + "'s Turn");
                }
                Board();
                Console.WriteLine();
                Console.Write("Please select a spot 1-9 to put your mark: ");
                choice = int.Parse(Console.ReadLine());
                if (arr[choice] != 'X' && arr[choice] != 'O')
                {
                    if (player % 2 == 0)
                    {
                        arr[choice] = Convert.ToChar(p2Choice);
                        player++;
                    }
                    else
                    {
                        arr[choice] = Convert.ToChar(p1Choice);
                        player++;
                    }
                }
                else
                {
                    Console.WriteLine("Sorry, the row {0} is already taken with {1}", choice, arr[choice]);
                    Console.WriteLine("\n");
                    Console.WriteLine("Please wait for the board to reload...");
                }

                flag = CheckWin();

            }
            while (flag != 1 && flag != -1);
            {
                Console.WriteLine(title);
                Console.Clear();// clearing the console  
                Board();// getting filled board again  

            }


            if (flag == 1)// if flag value is 1 then some one has won or means who played marked last time which has win  

            {
                Winner();
                int intWinner = (player % 2 + 1);
                if (intWinner == 1)
                {
                    Console.WriteLine("{0} has won", p1Name);
                }
                else
                {
                    Console.WriteLine("{0} has won", p2Name);
                }

            }

            else// if flag value is -1 the match will be draw and no one is winner  

            {

                Draw();

            }

            Console.ReadLine();






        }
        private static void Board()

        {

            Console.WriteLine("                                |     |      ");
            Console.WriteLine("                             {0}  |  {1}  |  {2}", arr[1], arr[2], arr[3]);
            Console.WriteLine("                           _____|_____|_____ ");
            Console.WriteLine("                                |     |      ");
            Console.WriteLine("                             {0}  |  {1}  |  {2}", arr[4], arr[5], arr[6]);
            Console.WriteLine("                           _____|_____|_____ ");
            Console.WriteLine("                                |     |      ");
            Console.WriteLine("                             {0}  |  {1}  |  {2}", arr[7], arr[8], arr[9]);
            Console.WriteLine("                                |     |      ");

        }
        private static string MarkChoice(string choice)
        {

            if (choice == "X")
            {
                return "O";
            }
            else
            {
                return "X";
            }
        }

        //CheckWin code was provided at c-sharpcorner.com by Sourabh Somani 
        //Seemed easier to find than reinventing the wheel
        private static int CheckWin()

        {

            #region Horzontal Winning Condtion

            //Winning Condition For First Row   
            if (arr[1] == arr[2] && arr[2] == arr[3])
            {
                return 1;
            }

            //Winning Condition For Second Row   
            else if (arr[4] == arr[5] && arr[5] == arr[6])
            {
                return 1;
            }

            //Winning Condition For Third Row   
            else if (arr[6] == arr[7] && arr[7] == arr[8])
            {
                return 1;
            }
            #endregion

            #region vertical Winning Condtion

            //Winning Condition For First Column       
            else if (arr[1] == arr[4] && arr[4] == arr[7])
            {
                return 1;
            }

            //Winning Condition For Second Column  
            else if (arr[2] == arr[5] && arr[5] == arr[8])
            {
                return 1;
            }

            //Winning Condition For Third Column  
            else if (arr[3] == arr[6] && arr[6] == arr[9])
            {
                return 1;
            }

            #endregion



            #region Diagonal Winning Condition
            else if (arr[1] == arr[5] && arr[5] == arr[9])
            {
                return 1;
            }

            else if (arr[3] == arr[5] && arr[5] == arr[7])
            {
                return 1;
            }

            #endregion

            #region Checking For Draw

            // If all the cells or values filled with X or O then NO player has won the match  

            else if (arr[1] != '1' && arr[2] != '2' && arr[3] != '3' && arr[4] != '4' && arr[5] != '5' && arr[6] != '6' && arr[7] != '7' && arr[8] != '8' && arr[9] != '9')
            {
                return -1;
            }
            #endregion
            //If no winner, continue the match
            else

            {
                return 0;
            }
        }
        private static void Winner()
        {
            string winnerText = @"
                   __                                          __ 
                  /  |                                        /  |
     __   __   __ $$/  _______   _______    ______    ______  $$ |
    /  | /  | /  |/  |/       \ /       \  /      \  /      \ $$ |
    $$ | $$ | $$ |$$ |$$$$$$$  |$$$$$$$  |/$$$$$$  |/$$$$$$  |$$ |
    $$ | $$ | $$ |$$ |$$ |  $$ |$$ |  $$ |$$    $$ |$$ |  $$/ $$/ 
    $$ \_$$ \_$$ |$$ |$$ |  $$ |$$ |  $$ |$$$$$$$$/ $$ |       __ 
    $$   $$   $$/ $$ |$$ |  $$ |$$ |  $$ |$$       |$$ |      /  |
    $$$$$/$$$$/  $$/ $$/   $$/ $$/   $$/  $$$$$$$/ $$/       $$/ 

";
            Console.WriteLine(winnerText);
        }
        private static void Draw()
        {
            string winnerText = @"
      _______   _______    ______   __       __ 
    /       \ /       \  /      \ /  |  _  /  |
    $$$$$$$  |$$$$$$$  |/$$$$$$  |$$ | / \ $$ |
    $$ |  $$ |$$ |__$$ |$$ |__$$ |$$ |/$  \$$ |
    $$ |  $$ |$$    $$< $$    $$ |$$ /$$$  $$ |
    $$ |  $$ |$$$$$$$  |$$$$$$$$ |$$ $$/$$ $$ |
    $$ |__$$ |$$ |  $$ |$$ |  $$ |$$$$/  $$$$ |
    $$    $$/ $$ |  $$ |$$ |  $$ |$$$/    $$$ |
    $$$$$$$/  $$/   $$/ $$/   $$/ $$/      $$/

";
            Console.WriteLine(winnerText);
            Console.ReadLine();
        }

        static void GetNames(out string p1Name, out string p2Name)
        {
            Console.WriteLine(Environment.NewLine);
            Console.WriteLine("Hello! Please enter your names!");
            Console.WriteLine("-------------------------------");
            Console.Write("Player 1: ");
            p1Name = Console.ReadLine();
            Console.Write("Player 2: ");
            p2Name = Console.ReadLine();

        }


        static void GetP1Symbol(string p1Name, string p2Name, out string playerChoice)
        {
            Console.WriteLine(Environment.NewLine);
            Console.WriteLine($"Welcome {p1Name} and {p2Name}! Lets play some tic-tac-toe!!!");
            Console.WriteLine("------------------------------------------------------------------------");
            Console.WriteLine($"{p1Name}, would you like to be X's or O's?");
            playerChoice = Console.ReadLine();
        }

    }
}
