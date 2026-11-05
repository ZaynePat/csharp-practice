Dog rex = new Dog();
rex.Name = "Rex";
rex.Age = 3;
rex.Bark();                       // Rex says woof!

class Dog
{
    public string Name { get; set; } = "";
    public int Age { get; set; }

    public void Bark()
    {
        Console.WriteLine($"{Name} says woof!");
    }
}