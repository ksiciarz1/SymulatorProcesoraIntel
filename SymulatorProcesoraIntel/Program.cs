using System;
using System.Collections.Generic;

namespace SymulatorProcesoraIntel
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, byte> rejestry = new Dictionary<string, byte>() // tworzenie wszystkich rejestrów
            {
                {"AH",0},
                {"AL",0},
                {"BH",0},
                {"BL",0},
                {"CH",0},
                {"CL",0},
                {"DH",0},
                {"DL",0}
            };

            Console.WriteLine("Czy chcesz ręcznie wpisać rejestry? (Tak/Nie)");
            string odpowiedz = Console.ReadLine();
            if (odpowiedz == "Tak")
            {
                foreach (KeyValuePair<string, byte> kvp in rejestry)
                {
                    string wartoscString;
                    int wartoscInt;
                    while (true)
                    {
                        Console.WriteLine($"Podaj wartość rejestru {kvp.Key} w postacie dziesiętnej");
                        wartoscString = Console.ReadLine();
                        if (!int.TryParse(wartoscString, out wartoscInt))
                        {
                            Console.WriteLine("Nie udało się zamienić podanej wartość na liczbę");
                        }
                        else
                        {
                            if (wartoscInt >= 0 && wartoscInt <= 255)
                            {
                                rejestry[kvp.Key] = (byte)wartoscInt;
                                break;
                            }
                        }
                    }
                }
            }
            else
            {
                foreach (KeyValuePair<string, byte> kvp in rejestry)
                {
                    Random random = new Random();
                    rejestry[kvp.Key] = (byte)random.Next(255);
                }
            }

            Console.Clear();
            Console.WriteLine("\nWyświetlanie rejestrów");

            foreach (KeyValuePair<string, byte> kvp in rejestry) // wyświetlanie całego rejestru
            {
                Console.WriteLine($"Rejestr: {kvp.Key} = {Convert.ToString(kvp.Value, 2).PadLeft(8, '0')}");
            }

            Console.WriteLine("\n");

            while (true)
            {
                Console.WriteLine("Podaj komendę");
                string wholeString = Console.ReadLine();
                string command = wholeString.Split(" ")[0];
                command = command.ToLower();
                if (wholeString.Split(" ").Length < 3)
                    continue;
                string[] argumenty = new string[] { Convert.ToString(wholeString.Split(" ")[1]).ToUpper(), Convert.ToString(wholeString.Split(" ")[2]).ToUpper() };
                switch (command)
                {
                    case "mov":
                        if (rejestry.ContainsKey(argumenty[0]) && rejestry.ContainsKey(argumenty[1]))
                        {
                            rejestry[argumenty[1]] = rejestry[argumenty[0]];
                        }
                        else
                            Console.WriteLine("Podano zły argument");
                        break;
                    case "xchg":
                        if (rejestry.ContainsKey(argumenty[0]) && rejestry.ContainsKey(argumenty[1]))
                        {
                            byte temp;
                            temp = rejestry[argumenty[0]];
                            rejestry[argumenty[0]] = rejestry[argumenty[1]];
                            rejestry[argumenty[1]] = temp;
                        }
                        else
                            Console.WriteLine("Podano zły argument");
                        break;
                    default:
                        Console.WriteLine("Nie znaleziona takiej komendy");
                        break;
                }

                Console.WriteLine("\n");

                foreach (KeyValuePair<string, byte> kvp in rejestry) // wyświetlanie całego rejestru
                    Console.WriteLine($"Rejestr: {kvp.Key} = {Convert.ToString(kvp.Value, 2).PadLeft(8, '0')}");
            }
        }
    }
}
