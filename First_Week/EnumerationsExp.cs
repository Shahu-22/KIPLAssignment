using System;
class Program
{
    enum Status
    {
        Pending,
        Approved,
        Rejected
    }
    enum UserRole
{
    Admin,
    User,
    Guest
}

    static void Main()
    {
        Status currentStatus = Status.Approved;
        
        if (currentStatus == Status.Approved)
        {
            Console.WriteLine("Approved");
        }
        //convert to integer
        int value = (int)Status.Approved;
        Console.WriteLine(value);
        
        UserRole role = UserRole.Guest;

 switch (role)
{
    case UserRole.Admin:
        Console.WriteLine("Full access");
        break;
    case UserRole.User:
        Console.WriteLine("Limited access");
        break;
    case UserRole.Guest:
        Console.WriteLine("Read-only access");
        break;
}
    }
}
