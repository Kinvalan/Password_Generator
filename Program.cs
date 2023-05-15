
/*
(her er args[0] 14, og args[1] lLssdd). 
Det vil si at passordet skal bestå av 14 tegn, med en liten bokstav, en storbokstav, to spesialtegn og to tall 
*/


using System.Runtime.InteropServices;

namespace Password_Generator
{
    internal class Program
    {
        static bool _running = true;

        static void Main(string[] args)
        {
            while (_running)
            {
                Console.Clear();
                PasswordGenerator(args);
                Console.WriteLine("\n\n\nPress Escape to exit, or any other key to generate a new password.");
                var key = Console.ReadKey();

                if (key.Key == ConsoleKey.Escape) Environment.Exit(0);
            }
        }

        static void PasswordGenerator(string[] args)
        {
            if (!isValid(args))
            {
                showHelpText();
                return;
            }
            var length = Convert.ToInt32(args[0]);
            var options = args[1];

            var pattern = options.PadRight(length, 'l'); //fyller opp args[1] med 'l' til den har en lengde på 14 (args[0])
            var password = string.Empty;

            foreach (var category in pattern)
            {
                if (category == 'l') password += getRandomLowerCaseLetter();
                else if (category == 'L') password += getRandomUpperCaseLetter();
                else if (category == 'd') password += getRandomDigit();
                else password += getRandomSpecialCharacter();
            }
            Console.WriteLine(password);
        }

        static char getRandomSpecialCharacter()
        {
            var allSpecialCharacters = "!\"#¤%&/(){}[])";
            var random = new Random();
            var randomIndex = random.Next(0, allSpecialCharacters.Length-1);
            return allSpecialCharacters[randomIndex];
        }

        static char getRandomDigit()
        {
            var random = new Random();
            return random.Next(0, 9).ToString()[0];
        }

        
        private static char getRandomLetter(char min, char max)
        {
            var random = new Random();
            return (char)random.Next(min, max); // Bruker casting (ta denne tingen og tolk det som en annen datatype).
        }

        static char getRandomLowerCaseLetter()
        {
            return getRandomLetter('a', 'z');
        }
        
        static char getRandomUpperCaseLetter()
        {
            return getRandomLetter('A', 'Z');
        }


        static bool isValid(string[] args)
            {
                // Sjekk at antall argumenter er nøyaktig 2
                if (args.Length != 2) return false;

                var lengthString = args[0];
                var options = args[1];


                foreach (char charachter in options)
                {
                    //var acceptedCharacters = options.ToCharArray();
                    //if (!acceptedCharacters.Contains(charachter)) return false;
                    if(charachter != 'l'
                      && charachter != 'L'
                      && charachter != 'd'
                      && charachter != 's')
                    {
                        return false;
                    } 
                }

                foreach (var characther in lengthString)
                {
                    if (!char.IsDigit(characther))
                    {
                        return false;
                    }
                }
                return true;
            }


            static void showHelpText()
            {
                Console.WriteLine("PasswordGenerator");
                Console.WriteLine("Options:");
                Console.WriteLine("  - l = lowercase letter");
                Console.WriteLine("  - L = uppercase letter");
                Console.WriteLine("  - d = digit");
                Console.WriteLine("  - s = special character (!\"#¤%&/(){}[])");
                Console.WriteLine("Example: PasswordGenerator 14 lLssdd");
                Console.WriteLine("         Min. 1 lowercase");
                Console.WriteLine("         Min. 1 uppercase");
                Console.WriteLine("         Min. 2 special characters");
                Console.WriteLine("         Min. 2 digits");
            }
    }
}
           
    

         