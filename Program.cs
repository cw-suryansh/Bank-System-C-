using System;
using System.Collections.Generic;

namespace FirstProject
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Account> accounts = new List<Account>();
            //Creates account balance, name, and password
            createAccount(accounts,100, "Sam", "abc");
            createAccount(accounts,200, "Sam2", "pwd");

            //Shows Account details
            show(10100, accounts); 
            // In the above case it will show Account not found because Accont no. starts from 1000
            // and as only 2 accounts are created 1000 and 1001 acc_nos respectively , account 10100 
            // will be invalid
            
            try
            {
                
                transaction(1000, 1001, accounts);
                show(1000, accounts);
                show(1001, accounts);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            
            
        }

        static void createAccount(List<Account> accounts,int balance, string name, string password){
            var acc = new Account(balance, name, password);
            Console.WriteLine("Account created successfully.");
            acc.display();
            accounts.Add(acc);
        }

        //parameter 
        // from: acc_no to be withdrawn from
        // to : acc_no in which amount will be deposited
        static void transaction(int from, int to, List<Account> accounts){
            Account a = null,b=null;
            foreach (var item in accounts)
            {
                if(item.acc_no==from)
                    a=item;
                if(item.acc_no==to)
                    b=item;
            }
            if(a is null || b is null)
                throw new Exception("Invalid Accounts.");

            int amt = a.withdraw();
            b.deposit(amt);
        }

        static void show(int ac_no, List<Account> accounts){
            Account a=null;
            foreach (var item in accounts)
            {
                if(item.acc_no==ac_no){
                    a=item;
                    break;
                }
            }

            if(a is null)
                Console.WriteLine("Account not found.");
            else{
                a.display();
            }
        }
    }
}
