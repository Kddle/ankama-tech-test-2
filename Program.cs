using System;

namespace AnkamaTechTest2
{
    class Program
    {
        public const int MIN_RANGE = 1, MAX_RANGE = 10, MAX_MULTIPLE = 3;

        static void Main(string[] args)
        {
            GuessMultipleGame guessMultipleGame = new GuessMultipleGame(MIN_RANGE, MAX_RANGE, MAX_MULTIPLE);

            try
            {
                guessMultipleGame.Initialize();

                while (!guessMultipleGame.IsGameFinished())
                {
                    guessMultipleGame.Update();
                }

                Console.WriteLine($"Game finished in {guessMultipleGame.GetTurnCount()} turns.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[ERROR] {ex.Message}");
                return;
            }
        }
    }
}
