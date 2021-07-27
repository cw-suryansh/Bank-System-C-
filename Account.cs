using System;

namespace FirstProject
{
    class Account
    {
        public int acc_no;
        public string name;
        private string password;
        public int balance;
        static private int def_ac=1000;


        public Account(int balance, string name, string password)
        {
          this.balance=balance;
          this.name=name;
          this.password=password;
          this.acc_no=Account.def_ac;
          Account.def_ac+=1;
        }

        private bool check_pwd(string pwd){
          if(password == pwd){
            return true;
          }
          return false;
        }

        public void deposit(int amt){
          balance+=amt;
        }

        public int withdraw(){
          Console.WriteLine("Enter your password : ");
          string pwd = Console.ReadLine();
          bool res = check_pwd(pwd);
          if (!res)
            throw new Exception("Wrong Password.");
          Console.WriteLine("Enter your amt : ");
          int amt = int.Parse(Console.ReadLine());
          int temp = balance - amt;
          if(temp<0){
            throw new Exception("Not enough balance.");
          }
          else{
            balance = temp;
          }
          return amt;
        }

        public void display(){
          Console.WriteLine($"A/C no.: {acc_no}");
          Console.WriteLine($"Name : {name}");
          Console.WriteLine($"Balance : {balance}\n\n");
          
        }
    }
}
