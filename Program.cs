using Discord;
using Discord.Gateway;
using System;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.IO;
using System.Drawing;
using System.Collections;
using Console = Colorful.Console;

namespace DiscordCommands
{
    class Program
    {
        static void Main(string[] args)
        {
          
            Console.Title = "Discord HypeBadge Manager || By Poordev";
            Console.WriteLine("Please Enter Your Token: ", System.Drawing.Color.ForestGreen);

            var token = Console.ReadLine();

            DiscordSocketClient client = new DiscordSocketClient();
            client.OnLoggedIn += Client_OnLoggedIn;

            try
            {
                client.Login(token);
                Console.WriteLine("Logging in...", System.Drawing.Color.LightGreen);
                Console.Clear();
                Thread.Sleep(-1);

            }
            catch (Exception)
            {
                Console.Clear();
                Console.WriteLine("Invalid Token", System.Drawing.Color.Red);
                Console.ResetColor();
            }

        }

        private static void Client_OnLoggedIn(DiscordSocketClient client, LoginEventArgs args)
        {
            Console.WriteLine($"                                      Logged in as {client.GetClientUser()}\n\n", System.Drawing.Color.Cyan);
            Console.WriteLine("Which HypeSquad badge would you prefer. Brilliance, Bravery, Balance, Rotate, or None?");
            var chosen = Console.ReadLine();

            if (chosen.ToUpper() == "BRILLIANCE") client.User.SetHypesquad(Hypesquad.Brilliance);
            else if (chosen.ToUpper() == "BRAVERY") client.User.SetHypesquad(Hypesquad.Bravery);
            else if (chosen.ToUpper() == "BALANCE") client.User.SetHypesquad(Hypesquad.Balance);
            else if (chosen.ToUpper() == "NONE") client.User.SetHypesquad(Hypesquad.None);
            else if (chosen.ToUpper() == "ROTATE")
            {
                    while (true)
                    {
                        Thread.Sleep(15000);
                        client.User.SetHypesquad(Hypesquad.Balance);
                        Thread.Sleep(17000);
                        client.User.SetHypesquad(Hypesquad.Brilliance);
                        Thread.Sleep(5);
                        Thread.Sleep(15000);
                        client.User.SetHypesquad(Hypesquad.Bravery);

                    }

            }
            else Console.WriteLine("Nevermind then.");

            Console.WriteLine("Finished Hypesquad Badge Update.", System.Drawing.Color.LightGreen);
 

            Thread.Sleep(100);
            Console.WriteLine("DONE! You Can Now Close The Program", System.Drawing.Color.LightCoral);
        }

    }

}
