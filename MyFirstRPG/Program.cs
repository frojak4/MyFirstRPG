namespace MyFirstRPG
{
    internal class Program
    {
        static Speler player = new Speler("Frode", 5, 100, 100, 0, 15, 2);
        static Fiende enemy;
        static Random random = new Random();
        static bool gameState = true;

        static void Main(string[] args)
        {

            startScreen();

            while(gameState) {
                int action = random.Next(1, 8);

                if (action <= 3)
                {
                    enemyEncounter();
                } 
                else if (action == 4)
                {
                    event1();
                }
                else if (action == 5)
                {
                    event2();
                }
                else if (action == 6)
                {
                    event3();
                }
                else if (action == 7)
                {
                    event4();
                }
            }
        }

        static void startScreen()
        {
            Console.WriteLine("Hei, og velkommen til RPG. Skriv ditt navn nedenfor for å fortsette!");
            player.Name = Console.ReadLine();

        }


        static void enemyEncounter()
        {
            
            int fiendeValg = random.Next(1, 4);
            bool runState = false;
            if (fiendeValg == 1)
            {
                enemy = new Fiende("Goblin", 3, 10, 50, 40);
            }
            else if (fiendeValg == 2)
            {
                enemy = new Fiende("Alkoholiker", 7, 20, 120, 80);
            }
            else if (fiendeValg == 3)
            {
                enemy = new Fiende("Svenske", 5, 15, 80, 60);
            }



            Console.Clear();
            Console.WriteLine($"Du møtte på ein {enemy.Name} i level {enemy.Level}.");
            Console.WriteLine("(Trykk på valgfri knapp for å gå videre)");
            Console.ReadKey();
            while (enemy.HP > 0)
            {
                Console.Clear();
                Console.WriteLine($"{player.Name}       vs       {enemy.Name}");
                Console.WriteLine($"HP: {player.HP}              HP: {enemy.HP}");
                Console.WriteLine($"Level: {player.Level}             Level: {enemy.Level}");
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
                    enemy.HP -= player.Damage;
                    Console.Clear();
                    Console.WriteLine($"{player.Name} angrep {enemy.Name} og gjorde {player.Damage} skade!");
                    Console.WriteLine("(Trykk på valgfri knapp for å gå videre)");
                    Console.ReadKey();
                    if (enemy.HP > 0)
                    {
                        enemyAttack();
                    }
                }
                else if (userInput == "2")
                {
                    if (player.Potions > 0)
                    {
                        playerHeal();
                    }
                    else
                    {
                        Console.Clear();
                        Console.WriteLine("Du er tom for potions.");
                        Console.WriteLine("(Trykk på valgfri knapp for å gå videre)");
                        Console.ReadKey();
                    }
                }
                else if (userInput == "3")
                {
                    playerStats();
                }
                else if (userInput == "4")
                {
                    int checkForRun = random.Next(1, 3);

                    if (checkForRun == 1)
                    {
                        Console.Clear();
                        Console.WriteLine("Du sprang unna fienden!");
                        Console.WriteLine("(Trykk på valgfri knapp for å gå videre)");
                        Console.ReadKey();
                        enemy.HP = 0;
                        runState = true;
                    }
                    else if (checkForRun == 2)
                    {
                        Console.Clear();
                        Console.WriteLine("Du klarte ikkje å springe unna fienden");
                        Console.WriteLine("(Trykk på valgfri knapp for å gå videre)");
                        Console.ReadKey();
                        enemyAttack();
                    }
                }

            }

            if (!runState)
            {
                Console.Clear();
                Console.WriteLine($"Du beseiret {enemy.Name} og fikk {enemy.XPDrop} XP");
                checkForLevelUp();
            }


        }

        static void enemyAttack()
        {
            Console.Clear();
            player.HP -= enemy.Damage;
            Console.WriteLine($"{enemy.Name} angrep {player.Name} og gjorde {enemy.Damage} skade!");
            Console.WriteLine("(Trykk på valgfri knapp for å gå videre)");
            Console.ReadKey();
            checkForDeath();
        }

        static void playerHeal()
        {
            player.HP += 40;
            player.Potions--;
            if (player.HP > player.MaxHP)
            {
                player.HP = player.MaxHP;
            }

            Console.Clear();
            Console.WriteLine(
                $"{player.Name} tok ein overraskende stor slurk av Jaegermeister flaska si, og føler seg litt bedre. han har no {player.HP} HP. ");
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

        static void checkForLevelUp()
        {
            player.XP += enemy.XPDrop;

            if (player.XP >= 100)
            {
                player.XP -= 100;
                player.Level += 1;
                player.Damage += 5;
                player.HP += 20;
                Console.Clear();
                Console.WriteLine($"Du levlet opp til level {player.Level}");
                Console.WriteLine("(Trykk på valgfri knapp for å gå videre)");
                Console.ReadKey();
            }
        }

        static void checkForDeath()
        {
            if (player.HP <= 0)
            {
                Console.Clear();
                Console.WriteLine(
                    $"{player.Name} kollapset ned på bakken og døde. Han blei berre level {player.Level}. Skammelig");
                Console.WriteLine("(Trykk på valgfri knapp for å avslutte spelet.)");
                Console.ReadKey();
                System.Environment.Exit(0);
            }
        }

        static void event1()
        {
            string userInput = "";
            while (userInput is not "1" and not "2")
            {
                Console.Clear();
                Console.WriteLine("Du kom til ein tornebusk. Kva gjer du?");
                Console.WriteLine("1. Putt hånda di inni for å sjå om nokon har gjemt Jaegermeister der");
                Console.WriteLine("2. Gå vidare som ein tapar");
                userInput = Console.ReadLine();
            }

            if (userInput == "1")
            {
                Console.Clear();
                Console.WriteLine(
                    "Trudde du virkelig det skulle ligge Jaeger i ei random busk!? Du stakk deg på buska og mista 30HP");
                Console.WriteLine("(Trykk på valgfri knapp for å gå videre)");
                Console.ReadKey();
                player.HP -= 30;
                checkForDeath();
            }
            else if (userInput == "2")
            {
                Console.Clear();
                Console.WriteLine("Du gikk forbi buska, men er no frustrert for at du aldri får vite kva som er inni");
                Console.WriteLine("(Trykk på valgfri knapp for å gå videre)");
                Console.ReadKey();
            }

            
        }
        static void event2()
        {
            string userInput = "";
            while (userInput is not "1" and not "2")
            {
                Console.Clear();
                Console.WriteLine("Inni skogen finner du ei fontene med lyseblått vatn. Den skinner.");
                Console.WriteLine("1. Bade");
                Console.WriteLine("2. Gå vidare som ein skitten tapar");
                userInput = Console.ReadLine();
            }

            if (userInput == "1")
            {
                Console.Clear();
                Console.WriteLine("Vatnet forfriska deg, du fekk fullt liv.");
                Console.WriteLine("(Trykk på valgfri knapp for å gå videre)");
                Console.ReadKey();
                player.HP = player.MaxHP;
            }
            else if (userInput == "2")
            {
                Console.Clear();
                Console.WriteLine("Du gikk forbi fontena, og lever livet videre som ein svett tapar.");
                Console.WriteLine("(Trykk på valgfri knapp for å gå videre)");
                Console.ReadKey();
            }
        }

        static void event3()
        {
            Console.Clear();
            Console.WriteLine("Du finner ei flaske Jaeger på bakken.");
            Console.WriteLine("(Trykk på valgfri knapp for å gå videre)");
            Console.ReadKey();
            player.Potions += 1;
        }

        static void event4()
        {
            string userInput = "";
            while (userInput is not "1" and not "2")
            {
                Console.Clear();
                Console.WriteLine("Du møter på ein prest som stinker Jaegermeister. Han spør om han kan velsigne deg. Kva gjer du?");
                Console.WriteLine("1. La han velsigne deg! Glory!!");
                Console.WriteLine("2. Gå vidare som eit ureligiøst svin");
                userInput = Console.ReadLine();
            }

            if (userInput == "1")
            {
                Console.Clear();
                Console.WriteLine("Etter velsignelsen føler du deg bedre og sterkare. Du fekk 50XP!");
                Console.WriteLine("(Trykk på valgfri knapp for å gå videre)");
                Console.ReadKey();
                player.XP += 50;
                checkForLevelUp();
            }
            else if (userInput == "2")
            {
                Console.Clear();
                Console.WriteLine("Du fekk presten til å grine. Er du stolt av deg sjølv?");
                Console.WriteLine("(Trykk på valgfri knapp for å gå videre)");
                Console.ReadKey();
            }
        }
    }
}
