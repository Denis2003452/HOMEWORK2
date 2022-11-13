using System.ComponentModel.Design.Serialization;
using System.Net;
using System.Runtime.CompilerServices;
using static HOMEWORK2.Program;

namespace HOMEWORK2
{
    internal class Program
    {
        static Random rnd = new Random();
        static void Main()
        {
            List<Entity> entities = new List<Entity>();
            List<Entity> bufferlist1 = new List<Entity>();
            //List<Entity> bufferlist2 = new List<Entity>();
           
            for (int i = 0; i < 100; i++)
            {
                entities.Add(new Entity(rnd.Next(0, 200), rnd.Next(0, 20), rnd.Next(0, 30), rnd.Next(0, 50)));
            }
            for (int i = 0; i < 3; i++)
            {
                int i1 = 1;

                //Драка и старение
                foreach (Entity entity in entities)
                {

                    entity.FightAndAging(entities[entities.Count - i1]);
                    i1++;
                }

                int i2 = 50;
                int i3 = 1;

                //Занесение в буфер
                for (int i5 = 0; i5 < 50; i5++)
                {

                    if (entities[entities.Count - i2].Health <= entities[entities.Count - i3].Health)
                    {
                        bufferlist1.Add(entities[entities.Count - i2]);
                    }
                    else
                        bufferlist1.Add(entities[entities.Count - i3]);
                    i2++;
                    i3++;
                }

                //Удаление пострадавших из основного списка
                foreach (Entity buffer in bufferlist1)
                {
                    entities.Remove(buffer);
                }

                //Занесение стариков в буфер
                //foreach (Entity entity in entities)
                //{
                //    if (entity.Age > 30)
                //        bufferlist1.Add(entity);
                //}
                ////Удаление стариков из основного списка
                //foreach (Entity buffer in bufferlist2)
                //{
                //    entities.Remove(buffer);
                //}

                Console.WriteLine(entities.Count);

                //Создание нового поколения на основе старого
                int i4 = 1;
                for (int i5 = 0; i5 < 50; i5++)
                {
                    entities.Add(new Entity(rnd.Next(Calculating1(entities[entities.Count - i4].Health), Calculating2(entities[entities.Count - i4].Health)), rnd.Next(Calculating1(entities[entities.Count - i4].Armor), Calculating2(entities[entities.Count - i4].Armor)), 0, rnd.Next(Calculating1(entities[entities.Count - i4].Strength), Calculating2(entities[entities.Count - i4].Strength))));
                    i4++;
                }

                Console.WriteLine(entities.Count);
            }
            double avarageHealth = entities.Average(e => e.Health);
            double avarageArmor = entities.Average(e => e.Age);
            double avarageAge = entities.Average(e => e.Age);
            double avarageStrength = entities.Average(e => e.Strength);
            Console.WriteLine($"Среднии значения популяции: Здоровье:{avarageHealth} Броня:{avarageArmor} Возраст:{avarageAge} Сила:{avarageStrength}");

        }
        static int Calculating1(int x)
        {
            return Convert.ToInt16(x / 2 * 1.2);
        }
        static int Calculating2(int x)
        {
            return Convert.ToInt16(x * 1.2);
        }

        internal class Entity
        {
            private int _health;
            public int Health
            {
                set
                {
                    if (value >= 0 && value <= 200)
                        _health = value;
                }
                get { return _health; }
            }
            private int _armor;

            public int Armor
            {
                set
                {
                    if (value >= 0 && value <= 20)
                        _armor = value;
                }
                get { return _armor; }

            }
            private int _age;

            public int Age
            {
                set
                {
                    if (value >= 0 && value <= 30)
                        _age = value;
                }
                get { return _age; }
            }
            private int _strength;

            public int Strength
            {
                set
                {
                    if (value >= 0 && value <= 50)
                        _strength = value;
                }
                get { return _strength; }
            }
            public Entity(int _health, int _armor, int _age, int _strength)
            {
                Health = _health;
                Armor = _armor;
                Age = _age;
                Strength = _strength;
            }
            public void FightAndAging(Entity otherentity)
            {
                int Damage1 = otherentity.Strength - this.Armor;
                this.Age += 1;
                otherentity.Age += 1;
                if (Damage1 <= 0)
                    this.Health -= 0;
                else
                    this.Health -= Damage1;
                //int Damage2 = this.Strength - otherentity.Armor;
                //if (Damage2 < 0)
                //    otherentity.Health -= 0;
                //else
                //    otherentity.Health -= Damage2;
            }

        }
    }
}