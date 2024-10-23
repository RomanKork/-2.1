class Human{
    public bool Less30YO { get; set; }
    public bool IsInRussia { get; set; }
    public Human()
    {
        Less30YO = false;
        IsInRussia = false;
    }
    public Human(bool x, bool y)
    {
        Less30YO = x;
        IsInRussia = y;
    }
    public Human(Human OtherHuman)
    {
        Less30YO = OtherHuman.Less30YO;
        IsInRussia = OtherHuman.IsInRussia;
    }
    public void MirrorHuman()
    {
        Less30YO = !Less30YO;
        IsInRussia = !IsInRussia;
    }
    public override string ToString()
    {
        return $"Less30YO: {Less30YO}, IsInRussia: {IsInRussia} ";
    }
}
class HumanGoToArmy : Human
{
    public bool ThatMan { get; set; }
    public HumanGoToArmy() : base()
    {
        ThatMan = false;
    }
    public HumanGoToArmy(bool x, bool y, bool z) : base(x, y)
    {
        ThatMan = z;
    }
    public bool MustGoInArmy()
    {
        return Less30YO && IsInRussia && ThatMan;
    }
    public void OtkositOtArmy()
    {
        Less30YO = false;
        IsInRussia = false;
        ThatMan = false;
    }
    public override string ToString()
    {
        return base.ToString() + $", ThatMan {ThatMan}";
    }
}
internal class Program
{
    private static void Main(string[] args)
    {
        Console.WriteLine("Проверка базового класса.\nЗаполните два логических поля для Дениса: 1.Возраст меньше 30 лет? 2. Находиться в России?");
        bool test1 = Enter();
        bool test2 = Enter();
        Console.WriteLine("\nДанные для Антона скопируем у Дениса и сделаем отрицание его полей: ");
        Human denis = new Human(test1,test2);
        Human anton = new Human(denis);
        anton.MirrorHuman();
        Console.WriteLine("Сведения о Денисе: " + denis.ToString());
        Console.WriteLine("Сведения о Антоне: " + anton.ToString());

        Console.WriteLine("Проверка дочернего класса(Проверяет пойдёт ли человек в армию?). \nТеперь заполните три логических поля для Вовы: 1.Возраст меньше 30 лет? 2. Находиться в России? 3. Человек - мужчина?");
        bool test3 = Enter();
        bool test4 = Enter();
        bool test5 = Enter();
        HumanGoToArmy Vova = new HumanGoToArmy(test3,test4,test5);
        Console.WriteLine("Данные для Человека: " + Vova.ToString());
        if (Vova.MustGoInArmy() == true)
        {
            Console.WriteLine("Человек пойдёт в армию.");
            Console.WriteLine("Теперь Человек звонит в 'Призыва.нет'");
            Vova.OtkositOtArmy();
            Console.WriteLine("Данные для Человека: " + Vova.ToString());
            if (Vova.MustGoInArmy() == true)
                Console.WriteLine("Человек пойдёт в армию.");
            else
                Console.WriteLine("Человек не пойдёт в армию.");
        }
        else
            Console.WriteLine("Человек не пойдёт в армию.");
        

    }
    public static bool Enter()
    {
        Console.WriteLine("Введите цифру 1 или 0 для опеределения логического значения переменной: ");
        int y;
        if (int.TryParse(Console.ReadLine(), out y))
        {
            if (y == 1)
                return true;
            if (y == 0)
                return false;
        }
        Console.WriteLine("Вы ввели неправильное значение, повторите попытку.");
        return Enter();
    }
}