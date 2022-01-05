using System;
using System.Collections.Generic;
using System.Reflection.Metadata.Ecma335;

namespace Domain
{
    public class Game
    {
        private List<int> _highscores;
        private Dice _dice1;
        private Dice _dice2;

        public int Eye1
        {
            get => _dice1.Dots;
        }

        public int Eye2
        {
            get => _dice2.Dots;
        }

        public bool HasSnakeEyes
        {
            get
            {
                if (Eye1 == 1 && Eye2 == 1)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        public IReadOnlyList<int> HighScores
        {
            get => _highscores;

        }
        public int Total { get; set; }

        public Game()
        {
            Initialize();
        }

        public void Initialize()
        {
            _dice1 = new Dice();
            _dice2 = new Dice();
            _highscores = new List<int>();
            
        }

        public void Play()
        {
            _dice1.Roll();
            _dice2.Roll();

            if (HasSnakeEyes)
            {
                _highscores.Add(Total);
                Total = 0;
            }
            else
            {
                Total += Eye1 + Eye2;
            }
            
        }

        public void Restart()
        {
            Initialize();
        }
    }
}