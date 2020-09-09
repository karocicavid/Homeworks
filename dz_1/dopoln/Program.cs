

using OpenTK;
using System;

class Student
{
    public string Surname;
    public string Name;
    public int Course;
    private int num;
    public int Book_num
    {
        set { num = value;}
        get { return num; }
    }
    public Student() { }
    public Student(string surname,string name,int course,int book_num)
    {
        Surname = surname; Name = name; Course = course; Book_num = book_num;
    }
}

class Aspirant:Student
{
    public Aspirant(string surname, string name, int course, int book_num)
        : base(surname, name, course, book_num)
    {

    }

    public void  Print()
    {
        Console.WriteLine($"\nAspirant {Name} {Surname} study in {Course} course by grade book number {Book_num}");
    }
}

class Call
{
    static int student_num = 1;
    static int aspirant_num = 1;
    static void Define(int x=0)
    {
        Student student = new Student();
        bool check = true;

        while (check == true)
        {
            Console.Write("Введите имя студента - ");
            student.Name = Console.ReadLine();
            Console.Write("Введите фамилию студента - ");
            student.Surname = Console.ReadLine();
            foreach (char a in student.Name + student.Surname)
            {
                if (a >= '0' && a <= '9')
                {
                    Console.WriteLine("Попробуйте ввести  еще раз!\n");
                    check = true;
                    break;
                }
                else
                {
                    check = false;
                }
            }
        }
        

        Console.Write("Выберите курс обучения - ");
        student.Course = int.Parse(Console.ReadLine());
        Console.Write("Выберите номер зачетной книги - ");
        student.Book_num = int.Parse(Console.ReadLine());
        if (student.Course > 5 || student.Course < 1 || student.Book_num < 1) { Console.WriteLine("Введены невалидные данные!"); return; }
        else
        {
            Aspirant aspirant = new Aspirant(student.Name, student.Surname, student.Course, student.Book_num);
            aspirant.Print();
            Recurs();
            
        }
    }

    static void Recurs()
    {
        Console.Write("Если хотите добавить добавить студентов нажмите - 1,если нет то - 2 :  ");
        int given = int.Parse(Console.ReadLine());
        if (given == 1)
        {
              student_num ++; 
              aspirant_num ++;
              Define();

        }
        else if(given==2)
        {
            Console.WriteLine($"Количество студентов - {student_num},количество аспирантов -{aspirant_num}");
            return;
        }
        
    }

    static void Main()
    {
        Console.WriteLine($"Привет!");
        Define();
    }
}