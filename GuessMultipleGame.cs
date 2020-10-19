using System;
using System.Collections.Generic;
using System.Text;

namespace AnkamaTechTest2
{
    public class GuessMultipleGame : Game
    {
        private int minRange, maxRange, maxMultiple;

        private Player _player;
        private int _turnCount;
        private int[] _guessNumbers;

        // Getters
        public Player GetCurrentPlayer()
        {
            return _player;
        }

        public int GetTurnCount()
        {
            return _turnCount;
        }

        // Constructor
        public GuessMultipleGame(int minRange, int maxRange, int maxMultiple)
        {
            this.minRange = minRange;
            this.maxRange = maxRange;
            this.maxMultiple = maxMultiple;
        }

        // Public Methods
        public override void Initialize()
        {
            _player = new Player();
            _turnCount = 0;
            _guessNumbers = GetUniqueRandomNumbersInRange(minRange, maxRange, maxMultiple);
        }

        public override void Update()
        {
            Console.Write("Player input: ");
            int userTurnInput = _player.GetNumericInput();

            if (userTurnInput == -1)
                return;

            _turnCount++;

            int validGuesses = GetValidGuesses(userTurnInput);

            if (validGuesses == _guessNumbers.Length)
                isFinished = true;

            var outMessage = isFinished ? "Win" : validGuesses.ToString();
            Console.WriteLine($"Game answer: {outMessage}");
        }

        // Private Methods
        int GetValidGuesses(int userInput)
        {
            int validGuesses = 0;

            foreach (var n in _guessNumbers)
            {
                if (userInput % n == 0)
                    validGuesses++;
            }

            return validGuesses;
        }

        private int[] GetUniqueRandomNumbersInRange(int min, int max, int count)
        {
            // TODO : Uncomment to use values provided in the specs document.
            //return new int[] { 2, 7, 10 };

            if (min > max)
                throw new InvalidOperationException("The 'min' value must be less than the 'max' value");

            if ((max - min) + 1 < count)
                throw new InvalidOperationException($"The range is to small to have {count} unique values.");

            Random random = new Random();
            List<int> numbers = new List<int>();

            while (numbers.Count < count)
            {
                var randomNumber = random.Next(min, max + 1);

                if (!numbers.Contains(randomNumber))
                    numbers.Add(randomNumber);
            }

            return numbers.ToArray();
        }
    }
}
