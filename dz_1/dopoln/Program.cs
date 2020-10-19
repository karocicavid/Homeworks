using System;
namespace cavid
{
    class Student
    {

        public string Surname;
        public string Name;
        public int Course;
        public int Book_num;
        public Student (string surname, string name, int course, int book_num)
        {
            Surname = surname; Name = name; Course = course; Book_num = book_num;
        }
    }
    class Aspirant : Student
    {
        public string Record_book;
        public Aspirant(string surname, string name, int course, int book_num, string record_book)
            : base(surname, name, course, book_num)
        {
            Record_book = record_book;
        }
    }
    class Call
    {
        static int aspirant_quantity = 0;
        static int student_quantity = 0;
        static int TryParse(int x = 0)
        { 
            int num1 = 0;
            bool triger = false;
            while (triger == false)
            {
                if (int.TryParse(Console.ReadLine(), out num1))
                {
                    triger = true;
                }
                else
                {
                    Console.WriteLine("Введите число заново");
                }
            }
            return num1;
        }
        public void Display()
        {
            Console.WriteLine($"\nКоличество аспирантов - {aspirant_quantity},количество - {student_quantity}");
        }
        public void Define(int x = 0)
        {
            Console.Write("\nЕсли хотите добавить студента нажмите - 1 :\nЕсли хотите добавить аспиранта нажмите - 2 :\nЕсли хотите выйти и получить данные нажмите - 3 :  ");
            int input = TryParse();
            if (input  == 1)
            {
                Console.Write("\nВведите имя студента - ");
                string Name = Alphabet_chechker();
                Console.Write("Введите фамилию студента - ");
                string Surname = Alphabet_chechker();
                Console.Write("Выберите курс обучения - ");
                int course = TryParse();

                bool check = true;
                do
                {
                    if (course > 0 || course <= 5) { check = false; }
                    else { Console.WriteLine("Введите реальный курс студента!"); course = TryParse(); }

                } while (check == true);
      
                Console.Write("Выберите номер зачетной книги - ");
                int Book_num  = TryParse();
                do
                {
                    if (Book_num > 0) { check = false; }
                    else { Console.WriteLine("Введите еще раз!"); Book_num = TryParse(); }
                } while (check == true);
               
                student_quantity++;
                Student student = new Student(Name, Surname,course,Book_num);
                Console.WriteLine($"\nИмя студента - {Name},фамилия - {Surname },курс - {course },номер зачетной книги -  {Book_num}");
                Define();
            }
            else if (input == 2)
            {
                Console.Write("\nВведите имя аспиранта - ");
                string Name = Alphabet_chechker();
                Console.Write("Введите фамилию аспиранта - ");
                string Surname = Alphabet_chechker();
                Console.Write("Выберите курс обучения - ");
                int course = TryParse();

                bool check = true;
                do
                {
                    if (course > 0 || course <= 5) { check = false; }
                    else { Console.WriteLine("Введите реальный курс студента!"); course = TryParse(); }

                } while (check == true);

                Console.Write("Выберите номер зачетной книги - ");
                int Book_num = TryParse();
                do
                {
                    if (Book_num > 0) { check = false; }
                    else { Console.WriteLine("Введите еще раз!"); Book_num = TryParse(); }
                } while (check == true);

                Console.Write("Выберите номер  книги дисертации - ");
                string Record_book = Console.ReadLine();
                aspirant_quantity++;
                Aspirant asp = new Aspirant(Surname, Name, course, Book_num, Record_book);
                Console.WriteLine($"\nИмя аспиранта - {Name},фамилия - {Surname },курс - {course },номер зачетной книги -  {Book_num},книга диссертации - {Record_book }");
                Define();
            }
            else if (input == 3) { Console.WriteLine("Количество аспирантов - {0}, количество студентов - {1}",aspirant_quantity,student_quantity); }
            else { Console.WriteLine("Попробуйте ввести  еще раз!\n"); Define(); }
        }
        static void Main()
        {
            Console.WriteLine($"Привет!");
            Call name = new Call();
            name.Define();
            Console.Read();
        }
        static string Alphabet_chechker()
        {
            bool check = true;
            string input;
            do
            {
                input = Console.ReadLine();
                if (string.IsNullOrEmpty(input))
                {
                    { Console.WriteLine("Empty input!"); check = false; return Alphabet_chechker(); }
                }
                foreach (char i in input)
                {

                    if (i < '0' || i > '9')
                    {
                        foreach (char a in "thequickbrownfoxjumpsoverthelazydogTHEQUICKBROWNFOXJUMPSOVERTHELAZYDOG")
                        {
                            if (a == i) { check = true; break; }
                            else { check = false; }
                        }
                    }
                    else { Console.WriteLine("input again!"); check = false; break; }
                    if (check == false) { Console.WriteLine("input again!"); break; }
                }
            } while (check == false);
            return input;
        }
    }
}
