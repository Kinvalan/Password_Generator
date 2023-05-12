
/*
(her er args[0] 14, og args[1] lLssdd). 
Det vil si at passordet skal bestå av 14 tegn, med en liten bokstav, en storbokstav, to spesialtegn og to tall 
*/


namespace Password_Generator
{
    internal class Program
    {
        static void Main(string[] args)
        {

            var isRunning = true;

            while (isRunning)
            {
                if(args.Length == 0)
                {
                    Console.WriteLine("det er ingen parametere");
                    infoForUser();
                    isRunning = false;
                }
                
                else if (args.Length == 2 && isInputANumber(args[0]) && isInputADesiredLetter(args[1])) 
                  /*
                  Hvis det er akkurat to kommandolinjeparametre og
                  det første parameteret er et siffer og
                  det andre parameteret består av de bokstavene jeg valgte
                  */
                {
                    Console.WriteLine("det er to parametere, det første er sifre og det andre er godkjente bokstaver");
                    isInputANumber(args[0]);
                    isInputADesiredLetter(args[1]);

                }
                
                else if(args.Length != 2)// Hvis det IKKE er akkurat to kommandolinsjeparametre
                {
                    Console.WriteLine("det er ikke akkurat to parametere");
                    infoForUser();
                    isRunning = false;
                }
            }
            
            /*
            isInputANumber() sjekker hvert symbol som blir skrevet inn i konsollen som første argument "args[0]" og
            hvis symbolene ikke er et tall så returnerer metoden false.

            Hvis det som skrives inn som første argument "args[0]" er tall, så returnerer metoden true.
            */

            static bool isInputANumber(string input) 
            
            {
                foreach (var symbol in input)
                {
                    if (!char.IsDigit(symbol))
                    {
                        return false;
                    }
                }
                return true;
            }


            static bool isInputADesiredLetter(string input)
            {
                foreach (var symbol in input)
                {
                    if(!(symbol == 'l' || symbol == 'L' || symbol == 'd' || symbol == 's'))
                    {
                        Console.WriteLine("Symbolene du brukte i args[1] tilfredsstiller ikke kravene");
                        infoForUser();
                        return false;
                    }
                }
                return true;
            }


        static void infoForUser()
        {
            string info = "PasswordGenerator  \r\n  Options:\r\n  - l = lower case letter\r\n  - L = upper case letter\r\n  - d = digit\r\n  - s = special character (!\"#¤%&/(){}[]\r\nExample: PasswordGenerator 14 lLssdd\r\n         Min. 1 lower case\r\n         Min. 1 upper case\r\n         Min. 2 special characters\r\n         Min. 2 digits";
            Console.WriteLine(info);
        }
        }
    }
}