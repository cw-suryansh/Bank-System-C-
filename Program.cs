using System;
using System.Collections.Generic;

namespace FirstProject
{
  class Program
  {
    static void Main(string[] args)
    {
      List<Account> accounts = new List<Account>();
      int choice = 0;
      do
      {
        Console.WriteLine("\n\n1: Create Account");
        Console.WriteLine("2: Transaction");
        Console.WriteLine("3: Display Account");
        Console.WriteLine("4: Exit");
        Console.WriteLine("Enter you choice : ");
        choice = int.Parse(Console.ReadLine());
        switch (choice)
        {
          case 1:
            createAccount(accounts);
            break;
          case 2:
            int from, to;
            Console.WriteLine("From (ac_no) : ");
            from = int.Parse(Console.ReadLine());
            Console.WriteLine("To (ac_no) : ");
            to = int.Parse(Console.ReadLine());
            try
            {
              transaction(1000, 1001, accounts);
              Console.WriteLine("Transaction Successfull.");
            }
            catch (Exception e)
            {
              Console.WriteLine(e.Message);
            }
            break;
          case 3:
            int ac_no;
            Console.WriteLine("Enter your ac_no : ");
            ac_no = int.Parse(Console.ReadLine());
            show(ac_no, accounts);
            break;
          default:
            Console.WriteLine("Thankyou !!");
            break;
        }
      } while (choice < 4 && choice > 0);


      //Creates account balance, name, and password
      // createAccount(accounts,100, "Sam", "abc");
      // createAccount(accounts,200, "Sam2", "pwd");

      //Shows Account details
      // show(10100, accounts); 
      // In the above case it will show Account not found because Accont no. starts from 1000
      // and as only 2 accounts are created 1000 and 1001 acc_nos respectively , account 10100 
      // will be invalid

      // try
      // {

      //     transaction(1000, 1001, accounts);
      //     show(1000, accounts);
      //     show(1001, accounts);
      // }
      // catch (Exception e)
      // {
      //     Console.WriteLine(e.Message);
      // }


    }

    static void createAccount(List<Account> accounts)
    {
      int balance;
      string name, password;
      Console.WriteLine("Enter Name : ");
      name = Console.ReadLine();
      Console.WriteLine("Enter Password : ");
      password = Console.ReadLine();
      Console.WriteLine("Enter Initial Deposit : ");
      balance = int.Parse(Console.ReadLine());
      var acc = new Account(balance, name, password);
      Console.WriteLine("Account created successfully.");
      acc.display();
      accounts.Add(acc);
    }

    //parameter 
    // from: acc_no to be withdrawn from
    // to : acc_no in which amount will be deposited
    static void transaction(int from, int to, List<Account> accounts)
    {
      Account a = null, b = null;
      foreach (var item in accounts)
      {
        if (item.acc_no == from)
          a = item;
        if (item.acc_no == to)
          b = item;
      }
      if (a is null || b is null)
        throw new Exception("Invalid Accounts.");

      int amt = a.withdraw();
      b.deposit(amt);
    }

    static void show(int ac_no, List<Account> accounts)
    {
      Account a = null;
      foreach (var item in accounts)
      {
        if (item.acc_no == ac_no)
        {
          a = item;
          break;
        }
      }

      if (a is null)
        Console.WriteLine("Account not found.");
      else
      {
        a.display();
      }
    }
  }
}
