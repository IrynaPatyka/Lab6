using System;

class Telephone
{
    
    public delegate void Event1Handler(object sender, EventArgs e);
    public event Event1Handler Event1;

    public void MakeCall()
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;
        Console.ForegroundColor = ConsoleColor.Magenta;
        Console.WriteLine("Телефонує телефон.");
        Console.ResetColor();
        Event1?.Invoke(this, EventArgs.Empty);
    }
}

class Subscriber
{
   
    public delegate void Event2Handler(object sender, EventArgs e);
    public delegate void Event3Handler(object sender, EventArgs e);

    
    public event Event2Handler Event2;
    public event Event3Handler Event3;

    public void HandleEvent1(object sender, EventArgs e)
    {
       
        Random random = new Random();
        if (random.Next(2) == 0)
        {
            Event2?.Invoke(this, EventArgs.Empty);
        }
        else
        {
            Event3?.Invoke(this, EventArgs.Empty);
        }
    }
}

class Answerphone
{
    public void HandleEvent2(object sender, EventArgs e)
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("Не зняли слухавку.Автовідповідач:введіть повідомлення: ");
        Console.ResetColor();
        string message = Console.ReadLine();
    }
}

class Talk
{
    public void HandleEvent3(object sender, EventArgs e)
    {
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("Зняли трубку: Алло? Слухаю вас.");
        Console.ResetColor();
    }
}

class Program
{
    static void Main(string[] args)
    {
        Telephone telephone = new Telephone();
        Subscriber subscriber = new Subscriber();
        Answerphone answerphone = new Answerphone();
        Talk talk = new Talk();

        telephone.Event1 += subscriber.HandleEvent1;
        subscriber.Event2 += answerphone.HandleEvent2;
        subscriber.Event3 += talk.HandleEvent3;

        telephone.MakeCall();
    }
}
