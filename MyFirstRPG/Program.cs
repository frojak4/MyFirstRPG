namespace MyFirstRPG
{
    internal class Program
    {
        static Speler player = new Speler("Frode", 5, 100, 0, 15, 2);
        static Fiende goblin;
        static void Main(string[] args)
        {
            startScreen();
            enemyEncounterGoblin();
        }

        static void startScreen()
        {
            Console.WriteLine("Hei, og velkommen til RPG. Skriv ditt navn nedenfor for å fortsette!");
            string playerName = Console.ReadLine();
            player.Name = playerName;
        }


        static void enemyEncounterGoblin()
        {
            goblin = new Fiende("Goblin", 3, 10, 50, 40);
            Console.Clear();
            Console.WriteLine($"Du møtte på ein {goblin.Name} i level {goblin.Level}.");
            Console.WriteLine("(Trykk på valgfri knapp for å gå videre)");
            Console.ReadKey();
            while (goblin.HP > 0)
            {
                Console.Clear();
                Console.WriteLine($"{player.Name}       vs       {goblin.Name}");
                Console.WriteLine($"HP: {player.HP}              HP: {goblin.HP}");
                Console.WriteLine($"Level: {player.Level}             Level: {goblin.Level}");
                Console.WriteLine();
                Console.WriteLine("------------------------------");
                Console.WriteLine();
                Console.WriteLine("1. Angrip");
                Console.WriteLine($"2. Bruk potion ({player.Potions} igjen)");
                Console.WriteLine("3. Statistikk");
                Console.WriteLine("4. Spring");
                Console.WriteLine();
                string userInput = Console.ReadLine();



                if (userInput == "1")
                {
                    goblin.HP -= player.Damage;
                    Console.Clear();
                    Console.WriteLine($"{player.Name} angrep {goblin.Name} og gjorde {player.Damage} skade!");
                    Console.WriteLine("(Trykk på valgfri knapp for å gå videre)");
                    Console.ReadKey();
                    if (goblin.HP > 0)
                    {
                        enemyAttack();
                    }
                } else if (userInput == "2")
                {
                    if (player.Potions > 0) {
                        playerHeal();
                    }
                    else
                    {
                        Console.Clear();
                        Console.WriteLine("Du er tom for potions.");
                        Console.WriteLine("(Trykk på valgfri knapp for å gå videre)");
                        Console.ReadKey();
                    }
                } else if (userInput == "3")
                {
                    playerStats();
                }
               
            }
        }

        static void enemyAttack()
        {
            Console.Clear();
            player.HP -= goblin.Damage;
            Console.WriteLine($"{goblin.Name} angrep {player.Name} og gjorde {goblin.Damage} skade!");
            Console.WriteLine("(Trykk på valgfri knapp for å gå videre)");
            Console.ReadKey();
        }

        static void playerHeal()
        {
            player.HP += 40;
            player.Potions --;
            if (player.HP > 100)
            {
                player.HP = 100;
            }
            Console.Clear();
            Console.WriteLine($"{player.Name} tok ein overraskende stor slurk av Jaegermeister flaska si, og føler seg litt bedre. han har no {player.HP} HP. ");
            Console.WriteLine("(Trykk på valgfri knapp for å gå videre)");
            Console.ReadKey();
            enemyAttack();
        }

        static void playerStats()
        {
            Console.Clear();
            Console.WriteLine($"{player.Name}");
            Console.WriteLine($"HP: {player.HP}");
            Console.WriteLine($"Damage: {player.Damage}");
            Console.WriteLine($"Level: {player.Level}");
            Console.WriteLine($"XP til neste level: {100 - player.XP}");
            Console.WriteLine("(Trykk på valgfri knapp for å gå videre)");
            Console.ReadKey();
        }
    }
}
