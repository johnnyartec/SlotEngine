using ConsoleClient.Command;
using Microsoft.Extensions.Hosting;

/*
Host.CreateDefaultBuilder().ConfigureServices((context, service) =>
{

}).Build()
.RunAsync();
*/


string action = string.Empty;

while(!action.ToUpper().Equals("Q")){
    Console.WriteLine("Choose Action(Q=Quit)");
    action = Console.ReadLine()!;
    Console.WriteLine($"action={action}");

    if(action.ToUpper() != "Q"){
        try
        {
            ICommand cmd = CommandFactory.Create(action.ToUpper());
            cmd.Execute();
        }
        catch (ArgumentException e)
        {
            Console.WriteLine(e.Message + " " + e.StackTrace);
        }

    }
    Console.WriteLine($"action={action} Done");
}


