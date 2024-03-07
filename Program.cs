namespace Romaghghg {
    class Program {
        static void Main(string[] args) {
            Tank[] tanks = GetTanks(); ;//помещаю кол-во резервуаров,установок,и заводов в соответствующие переменные
            Unit[] units = GetUnits();
            Factory[] factories = GetFactories();
            while (true) {
                Console.WriteLine("make a choice: 0 - get total volume, 1- print all tanks,\n" +
                    "2- search tank, 3- search unit, 4 - search factory, 5- exit\n");
                Console.WriteLine();


                int choice;
                if (!int.TryParse(Console.ReadLine(), out choice)) {
                    Console.WriteLine("incorrect value\n");
                }
                switch (choice) {
                    case 0:
                        int volume = GetTotalVolume(tanks);
                        Console.WriteLine(" Total volume is " + volume + "\n");
                        break;
                    case 1:
                        printalltanks(tanks, units, factories);
                        break;
                    case 2:
                        Console.WriteLine("which tank you want to get?\n");
                        string? nametank;
                        do {
                            nametank = Console.ReadLine();
                        } while (nametank == "");
                        Tank tank = searchtank(tanks, nametank);
                        break;
                    case 3:
                        Console.WriteLine("which unit you want to get?\n");
                        string? nameunit;
                        do {
                            nameunit = Console.ReadLine();
                        } while (nameunit == "");
                        Unit unit = searchunit(units, nameunit);
                        break;
                    case 4:
                        Console.WriteLine("which factory you want to get?\n");
                        string? namefactory;
                        do {
                            namefactory = Console.ReadLine();
                        } while (namefactory == "");
                        Factory factory = searchfactory(factories, namefactory);
                        break;
                    case 5:
                        return;
                    case 6:

                        break;
                    case 7:
                    default:
                        break;
                }
            }
        }
        //метод, возвращающий массив резервуаров
        public static Tank[] GetTanks() {
            Tank[] arrtank = new Tank[6];
            arrtank[0] = new Tank(1, "Резервуар 1", "Надземный - вертикальный", 1500, 2000, 1);
            arrtank[1] = new Tank(2, "Резервуар 2", "Надземный - горизонтальный", 2500, 3000, 1);
            arrtank[2] = new Tank(3, "Дополнительный резервуар 24", "Надземный - горизонтальный", 3000, 3000, 2);
            arrtank[3] = new Tank(4, "Резервуар 35", "Надземный - вертикальный", 3000, 3000, 2);
            arrtank[4] = new Tank(5, "Резервуар 47", "Подземный - двустенный", 4000, 5000, 2);
            arrtank[5] = new Tank(6, "Резервуар 256", "Подводный", 500, 500, 3);
            return arrtank;
        }
        // метод, возвращающий массив установок
        public static Unit[] GetUnits() {
            Unit[] arrunit = new Unit[3];
            arrunit[0] = new Unit(1, "ГФУ - 2", "Газофракционирующая установка", 1);
            arrunit[1] = new Unit(2, "АВТ - 6", " Атмосферно - вакуумная трубчатка", 1);
            arrunit[2] = new Unit(3, "АВТ - 10", "Атмосферно - вакуумная трубчатка", 2);
            return arrunit;
        }
        //метод, возвращающий массив заводов
        public static Factory[] GetFactories() {
            Factory[] arrfactory = new Factory[2];
            arrfactory[0] = new Factory(1, "НПЗ№1", "Первый нефтеперерабатывающий завод");
            arrfactory[1] = new Factory(2, "НПЗ№2", "Второй нефтеперерабатывающий завод");
            return arrfactory;
        }

        // метод для поиска установки по имени резервуара
        public static Unit FindUnit(Unit[] arrunit, Tank[] arrtank, string tankName) {
            Unit unit = new Unit(0, "", "", 0);
            int unitid = 0;
            for (int i = 0; i < arrtank.Length; i++) {
                if (arrtank[i].name == tankName) {
                    unitid = arrtank[i].unitid;
                }
            }
            for (int i = 0; i < arrunit.Length; i++) {
                if (arrunit[i].id == unitid) {
                    unit = arrunit[i];
                }
            }
            return unit;
        }

        // метод для поиска завода по установке
        public static Factory FindFactory(Factory[] arrfactory, Unit unit) {
            Factory factory = new Factory(0, "", "");
            int factoryid = 0;
            factoryid = unit.factoryid;

            for (int i = 0; i < arrfactory.Length; i++) {
                if (arrfactory[i].id == factoryid) {
                    factory = arrfactory[i];
                }
            }
            return factory;
        }

        // метод, возвращающий суммарный объем резервуаров в массиве
        public static int GetTotalVolume(Tank[] arrtank) {
            int vol = 0;
            for (int i = 0; i < arrtank.Length; i++) {
                vol += arrtank[i].volume;
            }
            return vol;
        }
        //метод для вывода всех резервуаров с их установками и заводами
        public static void printalltanks(Tank[] arrtank, Unit[] arrunit, Factory[] arrfactory) {
            int unitid = 0, factoryid = 0;
            string unitname = "", factoryname = "";
            for (int i = 0; i < arrtank.Length; i++) {
                unitid = arrtank[i].unitid;
                for (int j = 0; j < arrunit.Length; j++) {
                    if (arrunit[j].id == unitid) {
                        unitname = arrunit[j].name;
                        factoryid = arrunit[j].factoryid;
                    }
                }
                for (int h = 0; h < arrfactory.Length; h++) {
                    if (arrfactory[h].id == factoryid) {
                        factoryname = arrfactory[h].name;
                    }
                }
                Console.WriteLine(arrtank[i].name + " находиться в установке" + unitname + " и на заводе " + factoryname + "\n");
            }

        }
        //поиск резервуара по имени
        public static Tank searchtank(Tank[] arrtank, string nametank) {
            for (int i = 0; i < arrtank.Length; i++) {
                if (arrtank[i].name == nametank) {
                    Console.WriteLine("tank is founded!");
                    return arrtank[i];
                }
            }
            Console.WriteLine("tank is not founded!");
            return null;
        }
        //поиск установки по имени
        public static Unit searchunit(Unit[] arrunit, string nameunit) {
            for (int i = 0; i < arrunit.Length; i++) {
                if (arrunit[i].name == nameunit) {
                    Console.WriteLine("unit is founded!");
                    return arrunit[i];
                }
            }
            Console.WriteLine("unit is not founded!");
            return null;
        }
        //поиск завода по имени
        public static Factory searchfactory(Factory[] arrfactory, string namefactory) {
            for (int i = 0; i < arrfactory.Length; i++) {
                if (arrfactory[i].name == namefactory) {
                    Console.WriteLine("factory is founded!");
                    return arrfactory[i];
                }
            }
            Console.WriteLine("factory is not founded!");
            return null;
        }
    }

    //класс завода
    public class Factory {
        public int id { get; set; } = 0;
        public string name { get; set; } = "";
        public string description { get; set; } = "";
        public Factory(int id, string name, string description) {
            this.id = id;
            this.name = name;
            this.description = description;
        }
    }

    //класс установки
    public class Unit {
        public int id { get; set; } = 0;
        public string name { get; set; } = "";
        public string description { get; set; } = "";
        public int factoryid { get; set; } = 0;
        public Unit(int id, string name, string description, int factoryid) {
            this.id = id;
            this.name = name;
            this.description = description;
            this.factoryid = factoryid;
        }
    }

    //класс резервуара
    public class Tank {
        public int id { get; set; } = 0;
        public string name { get; set; } = "";
        public string description { get; set; } = "";
        public int volume { get; set; } = 0;
        public int max_volume { get; set; } = 0;
        public int unitid { get; set; } = 0;
        public Tank(int id, string name, string description, int volume, int max_volume, int unitid) {
            this.id = id;
            this.name = name;
            this.description = description;
            this.volume = volume;
            this.max_volume = max_volume;
            this.unitid = unitid;
        }
    }
}
