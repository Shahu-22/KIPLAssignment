using System;
delegate int NumChange(int num){
    class TestDelegate{
        static int num=10;
         public static int Addnum(int p){
            num+=p;
            return num;
         }
         public int Mulnum(int m){
            num*=m;
          return num;    
        } 
        public static int getNum(){
            return num;
        }
        public static void Main(string[] args){
            //Delegate instances 
            NumChange nc1=new NumChange(Addnum);
            NumChange nc2=new NumChange(Mulnum);
            nc1(20);
            nc2(5);
            Console.WriteLine("Value of Num : {0}",getNum());
            Console.ReadKey();
        }
    }
}