using System;
using GameOfLifeLibrary;

namespace GameOfLife
{
    static class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(Constants.Welcome);
            
            GameOfLifeLibrary.GameOfLife gameOfLife = new GameOfLifeLibrary.GameOfLife();
            
            
        }
    }
}