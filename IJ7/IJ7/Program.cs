using System;

namespace IJ7
{
    abstract class NPC
    {
        protected int Health;

        public abstract void TakeDamage(int damage);
    }

    class Human : NPC
    {
        int agility;

        public override void TakeDamage(int damage)
        {
            Health -= damage / agility;
            if (Health <= 0)
            {
                Console.WriteLine("Я умер");
            }
        }

        class Wombat : NPC
        {
            int armor;

            public override void TakeDamage(int damage)
            {
                Health -= damage - armor;
                if (Health <= 0)
                {
                    Console.WriteLine("Я умер");
                }
            }

            class Program
            {
                static void Main(string[] args)
                {
                    
               
                }
            }
        }
    }
}
