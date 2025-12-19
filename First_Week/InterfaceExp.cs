 using System;
// interface ICustomer{
//     void print();
// }
// interface second{
//     void Message();
// }
// class Customer:ICustomer,second{
//     public void print(){
//         Console.WriteLine("Interface Print Method");
//     }
//      public void Message(){
//         Console.WriteLine("Interface 2 Print Method");
//     }
// }
// Abstract class
// public abstract class cust1{
//     public abstract void print();
// }
// public class Customer:cust1{
//     public override void print(){
//         Console.WriteLine("Abstract method declared");
//     }
// }
// public class Program{
//     public static void Main(){
//         Customer c1=new Customer();
//         c1.print();
//         // c1.Message();
//     }
// }

//multiple inheritance
public class Vehicle
{
    public void Move()
    {
        Console.WriteLine("Vehicle is moving...");
    }
}

public interface IFlyable
{
    void Fly();
}

public interface ISailable
{
    void Sail();
}

public class AmphibiousPlane : Vehicle, IFlyable, ISailable
{
    public void Fly()
    {
        Console.WriteLine("Plane is flying.");
    }

    public void Sail()
    {
        Console.WriteLine("Plane is sailing on water.");
    }
}

public class InterfaceExp
{
    public static void Main()
    {
        AmphibiousPlane ap = new AmphibiousPlane();
        ap.Move();
        ap.Fly();
        ap.Sail();
    }
}