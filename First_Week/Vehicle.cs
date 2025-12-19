using System;
class Vehicle{
  int Wheels;
  string color;
  int price;
 public Vehicle(int Wheels,string color,int price){
     this.Wheels=Wheels;
     this.color=color;
     this.price=price;
 }
 public void Display(){
     Console.WriteLine("NO of Wheels  : "+Wheels);
     Console.WriteLine("Vehicle color  : "+color);
     Console.WriteLine("Vehicle price  : "+price);
 }
 public static void Main(string[] args){
     Vehicle v=new Vehicle(4,"red",500000);
     v.Display();
 }
}