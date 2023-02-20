using System;

class test
{
    struct User
    {
        public int age;
        public double height;

        public User(int _age, double _height)
        {
            this.age = _age;
            this.height = _height;
        }
    }

    public static void Main()
    {
        User u = new(18, 175.0);
        Console.WriteLine($"{u.age}, {u.height}");
    }
}