using System;

namespace ConsoleGame
{
  class Program
  {
        

        static void Main(string[] args)
    {
      Random rand = new Random();
      Console.CursorVisible = false;

      // Determine bounds and set starting positions
      int rows = Console.BufferHeight;
      int cols = Console.BufferWidth;
      char cursor = '<';
      int characterRow = rows / 2;
      var characterCol = cols / 2;
      char fruit = '@';
      int fruitRow = rand.Next(1, rows);
      int fruitCol = rand.Next(1, cols);
      int score = 0;

      
      while (true)
            {
                // Draw score, character, and fruit
                Console.Clear();
                Console.SetCursorPosition(0, 0);
                string value = $"Score: {score}";
                Console.Write(value);
                Console.SetCursorPosition(characterCol, characterRow);
                Console.Write(cursor);
                Console.SetCursorPosition(fruitCol, fruitRow);
                Console.Write(fruit);


                var cki = Console.ReadKey(false);

                // End game if Q is pressed
                if (cki.Key == ConsoleKey.Q)
                {
                    Console.Clear();
                    Console.SetCursorPosition(0, 0);
                    Console.CursorVisible = true;
                    break;
                }

                // Change character position based on key
                // Uses UpdatePosition()
                string key = cki.Key.ToString();
                int colChange = 0;
                int rowChange = 0;
                Game.UpdatePosition(key, out colChange, out rowChange);
                characterCol += colChange;
                characterRow += rowChange;

                // Update character symbol
                // Uses UpdateCursor()
                cursor = Game.UpdateCursor(key);


                characterCol = Game.KeepInBounds(characterCol, cols);
                characterRow = Game.KeepInBounds(characterRow, rows);


                if (NewMethod(characterRow, characterCol, fruitRow, fruitCol))
                {
                    score++;
                    fruitCol = rand.Next(cols);
                    fruitRow = rand.Next(rows);
                }
            }

            static bool NewMethod(int characterRow, int characterCol, int fruitRow, int fruitCol)
            {
                return Game.DidScore(characterCol, characterRow, fruitCol, fruitRow);
            }
        }
  }
}
