using System;
using System.Collections.Generic;

namespace NSD_Task_04
{
    internal class Program
    {
        public static Boss boss = new Boss(1500, 100, 0.2);
        public static Hero hero = new Hero(1000, 150, 0.1);
        public static Spells spells = new Spells();
        public delegate void ChoosenSpell();


        public static int CountOfTurns = 1;

        static void Main(string[] args)
        {            

            Console.SetCursorPosition(30, 10);
            Console.WriteLine("Вы - храбрый войн! Ваша задача уничтожить Босса.\n");
            Console.SetCursorPosition(20, 11);
            Console.WriteLine("Вы можете использовать как обычные атаки оружием, так и магические!\n");
            Console.SetCursorPosition(50, 12);
            Console.WriteLine("Удачи!");
            Console.ReadKey();

            while(boss.Health > 0 && hero.Health > 0)
            {
                ShowAllStats();

                hero.SelectAction();

                Console.WriteLine("Ваш ход закончен, теперь ходит Босс!");
                if (hero.IsBarrier) 
                { 
                    boss.Attack(hero, 0, 0);
                    Console.WriteLine("Внимание! Барьер был разрушен!\n");
                    hero.IsBarrier = false;
                }
                else boss.Attack(hero, 1, hero.Armor);
                Console.WriteLine("Нажмите любую клавишу для перехода к следующему ходу!");
                Console.ReadKey();
                CountOfTurns++;
            }
            if (boss.Health > 0) FightFailed();
            else FightWon();
        }

        

        public abstract class Human
        {
            public double Health;
            public double Damage;
            public double Armor;

            public  Human(double health, double damage, double armor)
            {
                this.Health = health;
                this.Damage = damage;
                this.Armor = armor;
            }
            public abstract void ShowStats();
        }

        public class Boss : Human
        {
            //private List<Debuff> debuffs;
            public Boss(double health, double damage, double armor) : base(health, damage, armor) { }

            public override void ShowStats()
            {
                Console.WriteLine("\t\tСтатистика Босса" +
                    $"\nОчки Здоровья: {Health}" +
                    $"\nАтака: {Damage}" +
                    $"\nБроня (процент отраженного урона): {Armor*100}%\n" /*+
                    $"\nОтрицательные эффекты: {ShowDebuffs()}"*/);
            }

            /*private string ShowDebuffs()
            {
                
            }*/

            public void Attack(Hero hero, double customBossDamageMulriplayer, double customHeroArmoreMulriplayer)
            {
                double HeroDamageLoss = customBossDamageMulriplayer * Damage - Damage * customHeroArmoreMulriplayer;
                hero.Health -= HeroDamageLoss;
                Console.WriteLine($"Босс атакует Вас и наносит {HeroDamageLoss} урона!" +
                    $"\nУ Вас осталось {hero.Health} ОЗ.\n");
            }            
        }

        public class Hero : Human
        {
            public bool IsBarrier = false;
            public bool IsCoopSpell = false;

            public Hero(double health, double damage, double armor) : base(health, damage, armor) { }

            public override void ShowStats()
            {
                Console.WriteLine("\t\tСтатистика Героя" +
                    $"\nОчки Здоровья: {Health}" +
                    $"\nАтака: {Damage}" +
                    $"\nБроня (процент отраженного урона): {Armor*100}%\n" /*+
                    $"\nОтрицательные эффекты: {ShowDebuffs()}"*/);
            }
            public void SelectAction()
            {
                if(IsCoopSpell)
                {
                    Console.WriteLine("Вы истощены после использования совместного заклинания! Вы пропускаете этот ход.");
                    IsCoopSpell = false;
                }
                else
                {
                    Console.WriteLine("Выберите действие:\n" +
                    $"\t- Attack - атакует босса на {Damage}\n" +
                    "\t- Spell - показывает список доступных заклинаний и применяет выбранное\n");
                    bool repeat = true;
                    while (repeat)
                    {
                        switch (Console.ReadLine())
                        {
                            case ("Attack"): { repeat = false; ShowAllStats(); Attack(boss, boss.Armor, 1); } break;
                            case ("Spell"): { repeat = false; ShowAllStats(); spells.ShowSpells(); } break;
                            default:
                                {
                                    Console.WriteLine("Комманда не распознана. Повторите ввод!");
                                }
                                break;
                        }
                    }
                }
                
            }

            public void Attack(Boss boss, double customBossArmor, double customHeroDamageMulriplayer)
            {
                double BossDamageLoss = customHeroDamageMulriplayer * Damage - Damage * customBossArmor;
                boss.Health -= BossDamageLoss;
                Console.WriteLine($"Вы атакуете Босса и наносите {BossDamageLoss} урона!" +
                    $"\nУ него осталось {boss.Health} ОЗ.\n");
            }
        }

        public class Spells
        {
            private Dictionary<string, ChoosenSpell> spells = new Dictionary<string, ChoosenSpell>
            {
                {"Heal", HealSpell},
                {"Thunder Strike", ThunderStrikeSpell},
                {"Summon", SummonSpell},
                {"Barrier", BarrierSpell},
                {"Coop", CoopSpell},
            };

            public void ShowSpells()
            {
                Console.WriteLine("Произнесите заклинание:\n" +
                    "\t- Heal - лечебное заклинание. Призывает \"Крем-Лекарь\". Восстанавливает 120 ОЗ.\n" +
                    "\t- Thunder Strike - призывает удар молнии по цели. Наносит 200% урона, игнорирует броню\n" +
                    "\t- Summon - призывает крылатого помощника (только 1 за игру). Каждый ход он наносит 70 урона\n" +
                    "\t- Barrier - создает барьер из чистой энергии. Игнорирует урон от босса на этот ход.\n" +
                    "\t- Coop - совместная атака с призванным помощником. Необходимо сначала призвать существо.\n" +
                    "\tНаносит 300% урона, Вы пропустите следующий ход для восстановления сил.");
                ChoosenSpell choosenSpell = HealSpell;
                bool repeat = true;
                while (repeat)
                {
                    try
                    {
                        choosenSpell = spells[Console.ReadLine()];
                        repeat = false;
                    }
                    catch
                    {
                        Console.WriteLine("Вы не знаете этого заклинания. Повторите ввод!");
                    }
                }
                choosenSpell();

            }

            static void HealSpell()
            {
                ShowAllStats();
                Console.WriteLine("Вы призвали \"Крем-Лекарь\". Восстановлено 120 ОЗ.");
                hero.Health += 120;
            }

            static void ThunderStrikeSpell()
            {
                ShowAllStats();
                Console.WriteLine("Вы призвали мощный удар молнией!");
                hero.Attack(boss, 0, 2);

            }

            private static int SummonCreaturesCount = 0;

            static void SummonSpell()
            {
                ShowAllStats();
                if (SummonCreaturesCount == 1)
                {
                    Console.WriteLine("Вы уже призвали своего помошника! За невнимательность Вы пропускаете ход!");
                }
                else
                {
                    SummonCreaturesCount++;
                    Console.WriteLine("Вы призвали летающего помощника! Общий урон повышен!");
                    hero.Damage += 70;
                }
            }

            static void BarrierSpell()
            {
                ShowAllStats();
                Console.WriteLine("Вы создали магический барьер вокруг себя, что позволит Вам избежать получение урона на 1 ход!");
                hero.IsBarrier = true;
            }

            static void CoopSpell()
            {
                ShowAllStats();
                if (SummonCreaturesCount != 1) Console.WriteLine("Сначала необходимо призвать существо! За невнимательность Вы пропускаете ход!");
                else
                {
                    Console.WriteLine("Вы проводите мощную магическую атаку вместе со своим существом!");
                    hero.Attack(boss, boss.Armor, 3);
                    hero.IsCoopSpell = true;
                }
            }
        }

        public static void ShowAllStats()
        {
            Console.Clear();
            Console.WriteLine($"Ход: {CountOfTurns}\n");

            boss.ShowStats();
            hero.ShowStats();
            Console.WriteLine("-----------------------------------------\n");
        }

        private static void FightFailed()
        {
            Console.Clear();
            Console.SetCursorPosition(30, 10);
            Console.WriteLine("Вы проиграли!");
            Console.SetCursorPosition(20, 11);
            Console.WriteLine("В следующий раз у вас точно все получится!");
            Console.ReadKey();
        }

        private static void FightWon()
        {
            Console.Clear();
            Console.SetCursorPosition(30, 10);
            Console.WriteLine("Поздравляем! Вы смогли одолеть босса!");
            Console.ReadKey();
        }
    }
}
