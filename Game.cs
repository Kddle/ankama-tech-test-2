using System;
using System.Collections.Generic;
using System.Text;

namespace AnkamaTechTest2
{
    public abstract class Game
    {
        protected bool isFinished = false;

        public bool IsGameFinished()
        {
            return isFinished;
        }

        public abstract void Initialize();
        public abstract void Update();
    }
}
