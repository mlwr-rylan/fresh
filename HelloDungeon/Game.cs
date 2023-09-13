using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelloDungeon
{
    class Game
    {   
        struct Character
        {
         public string Name;
         public float Damage;
         public float Health;
         public Weapons currentWeapon;
        }


        string getInput(string prompt, string option1, string option2, string option3, string option4)
        {
            Console.WriteLine(prompt);
            Console.WriteLine(option1);
            Console.WriteLine(option2);
            Console.WriteLine(option3);
            Console.WriteLine(option4);
            return "";
        }

        float Attack(Character character1,ref Character character2)
        {
            character2.Health -= character1.currentWeapon.Damage + character1.Damage;
            
        }

        float currentScene = 0;
        Character Xanman;
        Character Stepbro;
        Character uncle;
        Character blackman;

        Character Player;

        void SelectionScreen()
        {

            Console.WriteLine("Choose Your Character!!!!");
            Console.WriteLine("1. Xanman");
            Console.WriteLine("2. Stepbro");
            Console.WriteLine("3. uncle");
            Console.WriteLine("4. blackman");
            string playerChoice = Console.ReadLine();

            if (playerChoice == "1")
            {
                Player = Xanman;
                
            }
            else if (playerChoice == "2")
            {
                Player = Stepbro;
                
            }
            else if (playerChoice == "3")
            {
                Player = uncle;
                
            }
            else if (playerChoice == "4")
            {
                Player = blackman;
                
            }
            else
            {
                Console.WriteLine("NOT A CHOICE IDIOT!");
                Console.WriteLine("Press any key to continue!");
                Console.ReadKey(true);
                Console.Clear();
                return;
            }

            PrintStats(Player);
            Console.ReadKey(true);
            Console.Clear();
        }
        struct Weapons
        {
            public string Name;
            public float Damage;
            
        }

        Weapons Sword;
        Weapons Knife;
        Weapons Gun; 

        string swordName = "blade of gyat";
        float swordDamage = 10f;
        float swordDurability = 50f;

        struct items
        {
            public string Name;
            public float Effect;
        }
        string itemName = "healing potion";
        float itemHealing = 10f;

       
        
        string xanmanName = "xanman";
        float xanmanHealth = 100f;
        float xanmanDamage = 40f;

        string stepbroName = "stepbro";
        float stepbroHealth = 150f;
        float stepbroDamage = 50f;

        string uncName = "uncle";
        float uncHealth = 200f;
        float uncDamage = 60f;

        void PrintStats(Character Monster)
        {
            Console.WriteLine("Monster :" + Monster.Name);

            Console.WriteLine("Monster Damage:" + Monster.Damage);

            Console.WriteLine("Monster Health:" + Monster.Health);
        }
        Character heal(Character temp, float hp)
        {
            temp.Health += hp;
            return temp;
        }

        void Fight(ref Character monster1, ref Character monster2)
        {
            PrintStats(monster1);
            PrintStats(monster2);

            string battleDecision = getInput("Choose an action", "Attack", "Dodge", "Run", "Avoid");
            if(battleDecision == "1")
            {
                monster2.Health = Attack(Player, monster2);
                Console.WriteLine("You attacked with " + Player.currentWeapon.Name);
            }

            Console.WriteLine(monster1.Name + " slaps " + monster2.Name + "!");
            monster1.Health -= monster2.Damage + monster2.currentWeapon.Damage;
            Console.ReadKey(true);

            PrintStats(monster1);
            PrintStats(monster2);

            Console.WriteLine(monster1.Name + "punches" + monster2.Name);
        }
        bool gameOver;


        void Start()
        {
           


            Xanman.Name = "Xanman";
            Xanman.Health = 100f;
            Xanman.Damage = 40f;
            
            
            Stepbro.Name = "Stepbro";
            Stepbro.Health = 150f;
            Stepbro.Damage = 50f;

            
            uncle.Name = "uncle";
            uncle.Health = 200f;
            uncle.Damage = 60f;

            
            blackman.Name = "black man";
            blackman.Health = 420f;
            blackman.Damage = 500f;


        }
        void BattleScene()
        {
            while (Xanman.Health > 0 && uncle.Health >= 0)
            {
                Fight(ref Xanman, ref uncle);

                Console.Clear();
                
                
            }


        }
        void WinResultScene()
        {
            if (Xanman.Health > 0 && uncle.Health <= 0)
            {
                Console.WriteLine("The winner is" + Xanman.Name);
            }
            else if (Xanman.Health <= 0 && uncle.Health > 0)
            {
                Console.WriteLine("The winner is" + uncle.Name);
            }
        }
        void Update()
        {
            if (currentScene == 0)
            {
                SelectionScreen();

            }
            else if(currentScene == 1)
            {
                BattleScene();
            }
            else if(currentScene == 2)
            {
                WinResultScene();
            }
        }
        void End()
        {
            Console.WriteLine("Thanks For Playing!");
        }
        public void Run()
        {
            Start();
            
           while(gameOver== false)
            {
                Update();
            }

            End();


        }
    }
}
