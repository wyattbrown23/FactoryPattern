using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FactoryPattern
{
    class Program
    {
        static void Main(string[] args)
        {
            EquipmentFactory equipmentFactory = new EquipmentFactory();
            Dictionary<string, object> data = new Dictionary<string, object>();
            data.Add("ID", 1);
            Armor armor = equipmentFactory.Get(EquipmentType.Armor, data) as Armor;
            Weapon weapon = equipmentFactory.Get(EquipmentType.Weapon, data) as Weapon;
            Console.WriteLine(armor.GetData());
            Console.WriteLine(weapon.GetData());
            Console.ReadLine();
            
        }
    }

    enum EquipmentType
    {
        Armor,
        Weapon
    }
    class EquipmentFactory
    {
        private EquipmentType _type;
        private Dictionary<string, object> _data;
        public IEquipment Get(EquipmentType type, Dictionary<string, object> data)
        {
            _type = type;
            _data = data;
            return GetEquipment();
        }
        private IEquipment GetEquipment()
        {
            IEquipment equipment = null;

            int id = Convert.ToInt32(_data["ID"]) ;
            switch (_type) 
            {
                case EquipmentType.Armor:
                    if(id == 1)
                    {
                        equipment = new Armor()
                        {
                            Id = 1,
                            Name = "Dragon hide chest plate",
                            Defense = 100,
                            Type = "Dragon Hide",
                            Weight = 5
                        };
                    }
                    break;
                case EquipmentType.Weapon:
                    if (id == 1)
                    {
                        equipment = new Weapon()
                        {
                            Id = 1,
                            Name = "Dragonslayer Sword",
                            Damage = 1000,
                            Type = "Dragon Bone",
                            Weight = 12
                        };
                    }
                    break;
                default:
                    equipment = null;
                    break;
            }
            return equipment;
        }
    }

    interface IEquipment
    {
        string GetData();
    }

    class Armor : IEquipment
    {
        public int Id;
        public string Name;
        public int Defense;
        public int Weight;
        public string Type;

        public virtual string GetData()
        {
            return string.Format("Armor name is: {0}.  Defense is {1}.  Weight is {2}.  Type is {3}.", Name, Defense, Weight, Type);

        }
    }

    class Weapon : IEquipment
    {
        public int Id;
        public string Name;
        public int Damage;
        public int Weight;
        public string Type;

        public virtual string GetData()
        {
            return string.Format("Weapon name is: {0}.  Damage is {1}.  Weight is {2}.  Type is {3}.", Name, Damage, Weight, Type);
        }
    }
}
