using System;
using System.Collections;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel;
using System.Reflection.Metadata.Ecma335;
using System.Text;

namespace TicTacToe
{
    class Program
    {
        //Make Array for the board 
        private static char[] arr = { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9' };
        private static char[] defaultArr = { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9' };
        static int player = 1;
        static int _choice;
        private static string p1Name;
        private static string p2Name;
        private static string p1Choice;
        private static string p2Choice;
        
        private static int _p1Wins = 0;
        private static int _p2Wins = 0;
        static int _flag = 0; //1 = Winner & -1 = Draw
        static int _version = 0;
        static readonly char[,] ArrBoards = new char[10, 10];
        static string _playerInput;
        private static string _ticTacToeTitle;


        static void Main(string[] args)

        {

            Console.Title = "TicTacToe";

            #region Title Graphic

            _ticTacToeTitle = @"
       (                                                        )       
  *   ))\ )  (            *   )   (       (            *   ) ( /(       
` )  /(()/(  )\         ` )  /(   )\      )\         ` )  /( )\()) (    
 ( )(_))(_)|((_)   ___   ( )(_)|(((_)(  (((_)   ___   ( )(_)|(_)\  )\   
(_(_()|_)) )\___  |___| (_(_()) )\ _ )\ )\___  |___| (_(_())  ((_)((_)  
|_   _|_ _((/ __|       |_   _| (_)_\(_|(/ __|       |_   _| / _ \| __| 
  | |  | | | (__          | |    / _ \  | (__          | |  | (_) | _|  
  |_| |___| \___|         |_|   /_/ \_\  \___|         |_|   \___/|___|
";

            #endregion

            Console.WriteLine(_ticTacToeTitle.PadLeft(30));
            Board();
            GetNames();
            GetP1Symbol();
            MarkChoice();
            RunGame();
        }
        /*
        //    do
        //    {
        //        Menu();
        //        Console.WriteLine();
        //        MakeMove();
        //        if (_playerInput == "U") continue;
        //        for (int i = 0; i < arr.Length; i++)
        //        {
        //            ArrBoards[_version, i] = arr[i];
        //        }
        //        _flag = CheckWin();
        //        _version++;
        //    }
        //    while (_flag != 1 && _flag != -1);
        //    {
        //        Console.WriteLine(title);
        //        Console.Clear();
        //        Board();


        //    }
        //    //Checks to see if there is a winner, if so, displays the name & winner graphic
        //    if (_flag == 1)
        //    {
        //        Winner();
        //        int intWinner = (player % 2 + 1);
        //        if (intWinner == 1)
        //        {
        //            //Player 1 won
        //            Console.WriteLine("{0} HAS WON!!!! TOUGH LUCK {1}", p1Name, p2Name);
        //            _p1Wins++;
        //        }
        //        else
        //        {
        //            //Player 2 won
        //            Console.WriteLine("{0} HAS WON!!!! TOUGH LUCK {1}", p2Name, p1Name);
        //            _p2Wins++;
        //        }
        //    }
        //    else// Draw = -1: Method displays the draw picture and text 
        //    {
        //        Draw();
        //    }
        //    Console.ReadLine();
        //    //End of Game
        //}
        */
        //Displays the board 
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
        //Sets Marker Choice for Player 1
        private static void MarkChoice()
        {
            //If player 1 selects X, assigns player 2 O
            if (p1Choice == "X")
            {
                p2Choice = "O";
            }
            //If player 1 selects O, player 2 is assigned X
            else
            {
                p2Choice = "X";
            }
        }
        //Seemed easier to find than reinventing the wheel
        private static int CheckWin()
        {
            #region Horzontal Winning Condtion

            //Row 1   
            if (arr[1] == arr[2] && arr[2] == arr[3])
            {
                return 1;
            }

            //Row 2
            else if (arr[4] == arr[5] && arr[5] == arr[6])
            {
                return 1;
            }

            //Row 3
            else if (arr[6] == arr[7] && arr[7] == arr[8])
            {
                return 1;
            }
            #endregion
            #region vertical Winning Condtion
            //Column 1       
            else if (arr[1] == arr[4] && arr[4] == arr[7])
            {
                return 1;
            }

            //Column 2
            else if (arr[2] == arr[5] && arr[5] == arr[8])
            {
                return 1;
            }

            //Column 3 
            else if (arr[3] == arr[6] && arr[6] == arr[9])
            {
                return 1;
            }
            #endregion
            #region Diagonal Winning Condition
            //Top Left to Bottom Right 
            else if (arr[1] == arr[5] && arr[5] == arr[9])
            {
                return 1;
            }
            //Top Right to Bottom Left
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
            //Null Result
            else
            {
                return 0;
            }
        }
        //Displays Winner Graphic
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
        //Displays Draw Graphic
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
        //Get's the names of both players
        private static void GetNames()
        {
            Console.WriteLine(Environment.NewLine);
            Console.WriteLine("Hello! Please enter your names!");
            Console.WriteLine("-------------------------------");
            Console.Write("Player 1: ");
            p1Name = Console.ReadLine();
            Console.Write("Player 2: ");
            p2Name = Console.ReadLine();

        }
        //Player 1 chooses if they want to be X or O
        private static void GetP1Symbol()
        {
            Console.WriteLine(Environment.NewLine);
            Console.WriteLine($"Welcome {p1Name} and {p2Name}! Lets play some tic-tac-toe!!!");
            Console.WriteLine("------------------------------------------------------------------------");
            Console.WriteLine($"{p1Name}, would you like to be X's or O's?");
            p1Choice = Console.ReadLine();
            
        }
        //Prompts Players to make a move
        static void MakeMove()
        {
            Console.Write("Please select a spot 1-9 to put your mark");
            if (player > 1)
            {
                Console.Write(" OR '0' to go back a Move: ");
            }
            else { Console.Write(": "); }

            _playerInput = Console.ReadLine();


            if (int.TryParse(_playerInput, out int playerInput))
            {

                if (playerInput == 0)
                {
                    UndoMove();
                }
                else
                {
                    _choice = int.Parse(_playerInput);

                    if (arr[_choice] != 'X' && arr[_choice] != 'O')
                    {
                        if (player % 2 == 0)
                        {
                            arr[_choice] = Convert.ToChar(p2Choice);
                            player++;
                        }
                        else
                        {
                            arr[_choice] = Convert.ToChar(p1Choice);
                            player++;
                        }
                    }
                    else
                    {

                        Console.WriteLine("Sorry, the row {0} is already taken with {1}", _choice, arr[_choice]);
                        Console.WriteLine("\n");
                        Console.WriteLine("Please wait for the board to reload...");

                    }

                }
            }
            else
            {
                Console.BackgroundColor = ConsoleColor.DarkRed;
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("Please enter a Valid Number, Press any key to Continue");
                Console.ReadLine();
                Console.ResetColor();
                RunGame();
                
            }

            //StackMoves(arr, player);
        }
        //Displays Title, Board, and help text 
        static void Menu()
        {
            Console.Clear();
            Console.WriteLine(_ticTacToeTitle);
            Console.WriteLine($"   |{p1Name} is {p1Choice}'s| ----------------------------- |{p2Name} is {p2Choice}'s|");
            Console.WriteLine(Environment.NewLine);

            if (player % 2 == 0)
            {
                Console.WriteLine($"                             {p2Name}'s Turn");
            }
            else
            {
                Console.WriteLine($"                             {p1Name}'s Turn");
            }
            Board();
        }
        //Goes back a move if "U" is selected instead of a number
        private static void UndoMove()
        {
            string undo = "N";

            if (player % 2 == 0)
            {
                Console.WriteLine($"Would you like to go back to {p1Name}'s Turn? (Y/N)");
                undo = Console.ReadLine();
            }
            else
            {
                Console.WriteLine($"Would you like to go back to {p2Name}'s Turn? (Y/N)");
                undo = Console.ReadLine();
            }

            if (undo == "Y" || undo == "y")
            {

                _version = _version - 2;
                for (int i = 0; i < arr.Length; i++)
                {
                    arr[i] = ArrBoards[_version, i];
                }
                Board();
                player--;


            }
        }
        //Ask players to play again
        static void PlayAgain()
        {
            //Displays Current Record
            Console.WriteLine("Current Record:");
            Console.WriteLine($"{p1Name} - {_p1Wins}");
            Console.WriteLine($"{p2Name} - {_p2Wins}");
            Console.WriteLine("\n");
            Console.WriteLine("Would you like to play again? (Y/N)");
            var playAgain = Console.ReadLine();
            if (playAgain == "Y" || playAgain == "y")
            {
                ResetArrays();
                RunGame();
            }

        }
        //Clears out all arrays
        static void ResetArrays()
        {
            for (int i = 0; i < arr.Length; i++)
            {
                arr[i] = defaultArr[i];
            }
            Array.Clear(ArrBoards, 0, ArrBoards.Length);
            _version = 0;
            _flag = 0;
        }
        //Runs the main code 
        private static void RunGame()
        {
            
            do
            {
                Menu();
                Console.WriteLine();
                MakeMove();
                if (_playerInput != "0") continue;
                for (int i = 0; i < arr.Length; i++)
                {
                    ArrBoards[_version, i] = arr[i];
                }
                _flag = CheckWin();
                _version++;
                player = 1;
            }
            while (_flag != 1 && _flag != -1);
            {
                Console.WriteLine(_ticTacToeTitle);
                Console.Clear();
                Board();


            }
            //Checks to see if there is a winner, if so, displays the name & winner graphic
            if (_flag == 1)
            {
                Winner();
                int intWinner = (player % 2 + 1);
                if (intWinner == 1)
                {
                    //Player 1 won
                    Console.WriteLine("{0} HAS WON!!!! TOUGH LUCK {1}", p1Name, p2Name);
                    _p1Wins++;
                }
                else
                {
                    //Player 2 won
                    Console.WriteLine("{0} HAS WON!!!! TOUGH LUCK {1}", p2Name, p1Name);
                    _p2Wins++;
                   
                }
            }
            else// Draw = -1: Method displays the draw picture and text 
            {
                Draw();
            }
            PlayAgain();
            Console.ReadLine();
            //End of Game
        }
        public static void ClearCurrentConsoleLine()
        {
            int currentLineCursor = Console.CursorTop;
            Console.SetCursorPosition(0, 30);
            Console.Write(new string(' ', Console.WindowWidth));
            Console.SetCursorPosition(0, currentLineCursor);
        }

    }
}
