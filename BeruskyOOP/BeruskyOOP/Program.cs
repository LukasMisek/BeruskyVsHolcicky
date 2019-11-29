using System;
using System.Collections.Generic;
using System.Data;

namespace BeruskyOOP
{
    class Program
    {
        public static List<Bytost> bytosti = new List<Bytost>();

        static void Main(string[] args)
        {
            // Rozmery pole
            int height = 10;
            int width = 10;

            // Kontejnery na objekty
            PoleTravy pole = new PoleTravy(width, height);

            // Policko = objekt, na kterym muze byt jinej objekt

            // Model = data, co mame

            // Kontroler = neco jako GUI, ovladani hry

            // MVC = model view controller = pattern, jak se delaji hry, nebo neco takovy

            // Extra tridy / metody = nahazet zvlast do jine tridy

            // Generovani travicek
            for (int i = 0; i < height * width / 2; i++) bytosti.Add(new Travicka(pole));

            // Generovani berusek
            for (int i = 0; i < height * width / 10; i++) bytosti.Add(new Beruska(pole));

            // Generovani holcicek
            for (int i = 0; i < height * width / 50; i++) bytosti.Add(new Holcicka(pole));

            // Cyklus pro chod programu
            string input = "";           
            while (input != "K")
            {
                // Rust travy
                bytosti.Add(new Travicka(pole));

                // Pohyb bytosti (Travicka, holcicky, berusky)
                foreach (var bytost in bytosti)
                {
                    bytost.Move();
                    foreach (var cil in bytosti)
                    {
                        if (bytost.posX == cil.posX && bytost.posY == cil.posY && bytost.sila > cil.sila && cil.isAlive == true)
                        {
                            
                            SimpleFight(
                                Convert.ToInt32(bytost.nick.Substring(1, bytost.nick.Length - 1)),
                                Convert.ToInt32(cil.nick.Substring(1, cil.nick.Length - 1))
                                 );
                            /*
                            Fight(
                                Convert.ToInt32(bytost.nick.Substring(1, bytost.nick.Length-1)),
                                Convert.ToInt32(cil.nick.Substring(1, cil.nick.Length-1))
                                );*/
                                
                        }
                    }
                }
                // Zobrazeni bytosti   
                foreach (var bytost in bytosti) if(bytost.isAlive == true) bytost.ShowMe();

                // Zobrazeni hranic pole
                pole.ShowMe();

                // Zobrazeni skore
                ShowScore();

                // Cteni vstupu
                Console.SetCursorPosition(0, 0);
                input = Console.ReadLine();
                Console.Clear();

            }

        }

        // Utocnik je vzdy silnejsi => vzdy vyhraje nad obrancem
        public static void SimpleFight(int attackerID, int deffenderID)
        {
            if ((bytosti[attackerID].nick.Substring(0, 1) == "A" && bytosti[deffenderID].nick.Substring(0, 1) == "B") 
                || 
                (bytosti[attackerID].nick.Substring(0, 1) == "B" && bytosti[deffenderID].nick.Substring(0, 1) == "T"))
            {
                bytosti[deffenderID].zdravi = bytosti[deffenderID].zdravi - 50;
                if (bytosti[deffenderID].zdravi <= 0)
                {
                    bytosti[deffenderID].Dead();
                    bytosti[attackerID].skore++;
                    bytosti[attackerID].zdravi = bytosti[attackerID].zdravi + bytosti[deffenderID].sila;
                }
            }

        }

        /* Utocnik i Obrance hazi kostkou 1-20 podle D&D
         * 1 = Critical miss = vždy prohra
         * 20 = Critical hit = vždy výhra
         * Jinak porovnat hody
         * Holčička je silnější a má + 100 k hodu
         * Beruška má + 50 k hodu
         * Travička má + 10 k hodu
         */
        public static void Fight(int attackerID, int deffenderID)
        {

            string fightResult = FightResult(bytosti[attackerID].sila, bytosti[deffenderID].sila);
            if (fightResult == "attacker")
            {
                bytosti[attackerID].zdravi = bytosti[attackerID].zdravi + bytosti[deffenderID].sila;
                bytosti[deffenderID].zdravi = bytosti[deffenderID].zdravi - 50;
                if (bytosti[deffenderID].zdravi <= 0)
                {
                    bytosti[deffenderID].Dead();
                    bytosti[attackerID].skore++;
                }
            }
            else if (fightResult == "deffender")
            {
                bytosti[deffenderID].zdravi = bytosti[deffenderID].zdravi + bytosti[attackerID].sila;
                bytosti[attackerID].zdravi = bytosti[attackerID].zdravi - 50;
                if (bytosti[attackerID].zdravi <= 0)
                {
                    bytosti[attackerID].Dead();
                    bytosti[deffenderID].skore++;
                }
            }
            else
            {
                bytosti[deffenderID].zdravi = bytosti[deffenderID].zdravi - 25;
                bytosti[attackerID].zdravi = bytosti[attackerID].zdravi - 25;

                if (bytosti[deffenderID].zdravi <= 0) bytosti[deffenderID].Dead();

                if (bytosti[attackerID].zdravi <= 0) bytosti[attackerID].Dead();

            }
        }

        public static string FightResult(int attackerAttackPower,int deffenderAttackPower)
        {
            // Hod kostkou
            var rnd = new Random();
            int attackerThrow = rnd.Next(1, 20);
            int deffenderThrow = rnd.Next(1, 20);

            if (attackerThrow == 1) return "deffender";
            else if (attackerThrow == 20) return "attacker";
            else if (deffenderThrow == 1) return "attacker";
            else if (deffenderThrow == 20) return "deffender";
            else if (attackerThrow + attackerAttackPower > deffenderThrow + deffenderAttackPower) return "attacker";
            else return "deffender";
        }

        public static void ShowScore()
        {
            foreach(var bytost in bytosti)
            {
                if(bytost.nick.Substring(0, 1) != "T")
                {
                    Console.WriteLine("Bytost: {0} \t Body: {1} \t Životy {2} \t Ještě žije: {3}", 
                        bytost.nick, bytost.skore, bytost.zdravi, bytost.isAlive);
                }
            }
        }
    }
}