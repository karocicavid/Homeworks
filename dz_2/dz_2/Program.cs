
using System;

class Account
{
    public double Total;
    public int Account_num;
    public int Date;

    public Account() { }
    public Account(double total, int account_num, int date)
    {
        Total = total; Account_num = account_num; Date = date;
    }
    public void Amount()
    {
        Console.WriteLine($"Сумма в вашем счету - {Total}");
    }
    public void Date_Screen()
    {
        Console.WriteLine($"Дата открытия счета - {Date}");
    }
}

class Individual : Account
{
    public string Account_type;
    public Individual(double total, int account_num, int date, string account_type)
        : base(total, account_num, date)
    {
        Account_type = account_type;
    }
    public static int Tryparse1()
    {
        int input = 0;
        if (int.TryParse(Console.ReadLine(), out input))
        {
            return input;
        }
        else { Console.WriteLine("Wrong input!"); return Tryparse1(); }
    }

    public void Withdrawing()
    {
        bool check = true;
        Console.Write("\nВведите сумму которые хотите снять : ");
        int money = Tryparse1();
        do
        {
            if (money < 0 || money > Total) { Console.Write("Баланса не хватает,повторите - "); money = Tryparse1(); }
            else { check = false; }
        } while (check == true);

        Console.WriteLine($"Снято - {money} Azn,в счету {Total - money} Azn");
    }
    public void Percent()
    {
        bool check = true;
        Console.WriteLine("Вычисление для физических лиц!");
        Console.Write("Выберите Процент займа : ");

        int percent = Tryparse1();
        do
        {
            if (percent < 0 || percent > 100) { Console.Write("Введены неверные данные!"); percent = Tryparse1(); check = true; }
            else { check = false; }
        } while (check == true); ;


        Console.Write("Выберите период года займа : ");
        int period = Tryparse1();
        do
        {
            if (period < 0) { Console.Write("Введены неверные данные!"); period = Tryparse1(); check = true; }
            else { check = false; }
        } while (check == true); ;


        Console.Write("Для простого начисления процента нажимаем - 1,для сложного 2 : ");
        int given = Tryparse1();
        double result = Total;
        do
        {
            if (given == 1)
            {
                for (int i = 1; i <= period; i++)
                {
                    result += Total * percent / 100;
                }
                Console.WriteLine("Результат суммы - " + result);
                check = false;
            }

            else if (given == 2)
            {
                for (int i = 1; i <= period; i++)
                {
                    result += Total * percent / 100;
                    Total = result;
                }
                Console.WriteLine("Результат суммы - " + result);
                check = false;
            }
            else { Console.Write("Введены неверные данные!"); given = Tryparse1(); }
        } while (check == true);

    }

}

class Entity : Account
{
    public Entity(double total, int account_num, int date)
        : base(total, account_num, date) { }

    public void Percent()
    {
        Console.WriteLine("\nВычисление для юридических лиц!");
        Console.Write("Выберите Процент займа : ");
        bool check = true;
        int percent = Tryparse1();
        do
        {
            if (percent < 0 || percent > 100)
            {
                Console.Write("Введены неверные данные!"); percent = Tryparse1(); check = true; 
            }
            else { check = false; }
        } while (check == true);


        Console.Write("Выберите период займа : ");
        int period = Tryparse1();
        do
        {
            if (period < 0)
            {

                Console.Write("Введены неверные данные!"); period = Tryparse1(); check = true;
            }
            else { check = false; }
        } while (check == true);

        Console.Write("Для простого начисления процента нажимаем - 1,для сложного 2 : ");
        int given = Tryparse1();
        double result = Total;

        if (given == 1)
        {
            for (int i = 1; i <= period; i++)
            {
                result += Total * percent / 100;

            }
            Console.WriteLine("Результат суммы -" + result);
        }

        else if (given == 2)
        {
            for (int i = 1; i <= period; i++)
            {
                result += Total * percent / 100;
                Total = result;
            }
            Console.WriteLine("Результат суммы -" + result);
        }
        else { Console.Write("Введены неверные данные!"); return; }

    }
    static int Tryparse1()
    {
        int input = 0;
        if (int.TryParse(Console.ReadLine(), out input))
        {
            return input;
        }
        else { Console.WriteLine("Wrong input!"); return Tryparse1(); }
    }
}

class Do
{
    static void Main()
    {
        Account person = new Account();
        bool check = true;
        Console.Write("Выбериту сумму на счету:");
        person.Total = Tryparse();
        do
        {
            if (person.Total < 0) { Console.Write("Введены невалидные данные!"); person.Total = Tryparse(); }
            else { check = false; }
        } while (check == true);


        Console.Write("Выбериту текущий год открытия  счета:");
        person.Date = Tryparse();
        do
        {
            if (person.Date != 2020) { Console.Write("Введены невалидные данные!"); person.Date = Tryparse();check = true; }
            else { check = false; }
        } while (check == true);


        Console.Write("Выбериту номер счета:");
        person.Account_num = Tryparse();
        do
        {
            if (person.Total < 0) { Console.Write("Введены невалидные данные!"); person.Total = Tryparse(); check = true; }
            else { check = false; }
        } while (check == true);

        person.Amount();
        person.Date_Screen();

        Individual individual = new Individual(person.Total, person.Date, person.Account_num, "Current");
        individual.Withdrawing();
        individual.Percent();


        Entity entity = new Entity(person.Total, person.Date, person.Account_num);
        entity.Percent();

        Console.ReadKey();
    }
    public static int Tryparse()
    {
        int input = 0;
        if (int.TryParse(Console.ReadLine(), out input))
        {
            return input;
        }
        else { Console.WriteLine("Wrong input!"); return Tryparse(); }
    }
}
