
using System;

class Account
{
    public double Total;
    public int Account_num;
    public int Date;

    public Account() { }
    public Account(double total,int account_num,int date)
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

class Individual:Account
{
    public string Account_type;
    public Individual(double total, int account_num, int date,string account_type)
        :base(total,account_num,date)
    {
        Account_type = account_type;
    }

    public void Withdrawing()
    {
        Console.Write("\nВведите сумму которые хотите снять : ");
        int money = int.Parse(Console.ReadLine());
        if (money < 0 || money > Total) { Console.Write("Введены невалидные данные!"); return; }
        Console.WriteLine($"Снято - {money} Azn,в счету {Total - money} Azn");
    }
    public void Percent()
    {
        Console.WriteLine("Вычисление для физических лиц!");
        Console.Write("Выберите Процент займа : ");
        int percent = int.Parse(Console.ReadLine());
        if (percent < 0 || percent > 100) { Console.Write("Введены неверные данные!");  return; }

        Console.Write("Выберите период года займа : ");
        int period = int.Parse(Console.ReadLine());
        if (period < 0) { Console.Write("Введены неверные данные!"); return; }

        Console.Write("Для простого начисления процента нажимаем - 1,для сложного 2 : ");
        int given = int.Parse(Console.ReadLine());
        double result =Total;

        if (given == 1)
        {
            for(int i = 1; i <= period; i++)
            {
                result += Total*percent/100;
            }
            Console.WriteLine("Результат суммы - " + result);
        }

        else if (given == 2)
        {
            for (int i = 1; i <= period; i++)
            {
                result += Total * percent / 100;
                Total = result;
            }
            Console.WriteLine("Результат суммы - " + result);
        }
        else { Console.Write("Введены неверные данные!"); return; }
    }

}

class Entity:Account
{
    public Entity(double total, int account_num, int date)
        : base(total, account_num, date) { }

    public void Percent()
    {
        Console.WriteLine("\nВычисление для юридических лиц!");
        Console.Write("Выберите Процент займа : ");
        int percent = int.Parse(Console.ReadLine());
        if (percent < 0 || percent > 100) { Console.Write("Введены неверные данные!"); return; }

        Console.Write("Выберите период займа : ");
        int period = int.Parse(Console.ReadLine());
        if (period < 0) { Console.Write("Введены неверные данные!"); return; }

        Console.Write("Для простого начисления процента нажимаем - 1,для сложного 2 : ");
        int given = int.Parse(Console.ReadLine());
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
}

class Do
{
    static void Main()
    {
        Account person = new Account();

        Console.Write("Выбериту сумму на счету:");
        person.Total = double.Parse(Console.ReadLine());
        if (person.Total < 0) { Console.Write("Введены невалидные данные!");return; }

        Console.Write("Выбериту текущий год открытия  счета:");
        person.Date = int.Parse(Console.ReadLine());
        if (person.Date != 2020) { Console.Write("Введены невалидные данные!"); return; }

        Console.Write("Выбериту номер счета:");
        person.Account_num = int.Parse(Console.ReadLine());
        if (person.Total <0) { Console.Write("Введены невалидные данные!"); return; }

        person.Amount();
        person.Date_Screen();

        Individual individual = new Individual(person.Total,person.Date,person.Account_num,"Current");
        individual.Withdrawing();
        individual.Percent();
        

        Entity entity = new Entity(person.Total, person.Date, person.Account_num);
        entity.Percent();

        Console.ReadKey();
    }
}