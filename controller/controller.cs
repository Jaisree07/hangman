using System;
using Model;
using View;

namespace Controller
{
    public class HangmanController
    {
        private readonly Admin adminModel=new Admin();
        private readonly User userModel=new User();
        public void Run()
        {
            Console.Write("Are you Admin(A) or User(U): ");
            char choice = Char.ToUpper(Console.ReadKey().KeyChar);
            Console.WriteLine();

            if (choice == 'A')
            {
                adminModel.Run();   
            }
            else if (choice == 'U')
            {
                userModel.Run();    
            }
            else
            {
                HangmanView.ShowMessage("Invalid choice");
            }
        }
    }
}
