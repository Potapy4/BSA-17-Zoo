namespace ConsoleApp
{
    class Program
    {        
        static void Main(string[] args)
        {
            Menu menu = Menu.Instance;
            menu.WaitUserCommand();            
        }
    }
}
