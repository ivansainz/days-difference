using System;
using System.Globalization;

namespace DaysDifference
{
    static class Program
    {
        static void Main(string[] args)
        {
            ConsoleKeyInfo keyInfo;

            do
            {
                ConsoleKeyInfo menuOption;

                do
                {
                    menuOption = MainMenu();
                } while (!CheckIfMainMenuOptionIsOk(menuOption));

                if (menuOption.Key == ConsoleKey.Escape)
                {
                    Environment.Exit(0);
                }

                switch (menuOption.KeyChar)
                {
                    case '1':
                        double daysFromDate = DaysFromDate();
                        Console.WriteLine($"{daysFromDate} days");
                        break;
                    case '2':
                        double daysBetweenDates = DaysBetweenDates();
                        Console.WriteLine($"{daysBetweenDates} days");
                        break;
                    case '3':
                        DateTime dateAfterDays = DateAfterXDays();
                        Console.WriteLine($"The date will be {dateAfterDays} after those days");
                        break;
                }

                Console.WriteLine("Press a key to start again or Esc to exit");
                keyInfo = Console.ReadKey(); 
            } while (keyInfo.Key != ConsoleKey.Escape);
        }

        /// <summary>
        /// Shows main menu
        /// </summary>
        /// <returns>Key pressed</returns>
        static ConsoleKeyInfo MainMenu()
        {
            Console.Clear();
            Console.WriteLine("Choose an option or Esc to exit:");
            Console.WriteLine("1. Calculate days from date until now");
            Console.WriteLine("2. Calculate days between two dates");
            Console.WriteLine("3. Calculate date after x days");
            return Console.ReadKey();
        }

        /// <summary>
        /// Checks if the option pressed is valid
        /// </summary>
        /// <param name="option">Option to be evaluated</param>
        /// <returns>True if it is valid</returns>
        static bool CheckIfMainMenuOptionIsOk(ConsoleKeyInfo option)
        {
            if (option.KeyChar == '1' || option.KeyChar == '2' || option.KeyChar == '3' || option.Key == ConsoleKey.Escape)
            {
                return true;
            }

            return false;
        }

        /// <summary>
        /// Calculates the number of days between a given day and now
        /// </summary>
        /// <returns>Number of days</returns>
        static double DaysFromDate()
        {
            DateTime startDateTime;
            DateTime endDateTime = DateTime.Now;
            bool parsingResult;

            do
            {
                Console.WriteLine();
                Console.Write("Enter a valid passed date (YYYY-MM-DD or YYYY-MM-DD HH:MM:SS): ");
                string startDateTimeNotParsed = Console.ReadLine();
                parsingResult = DateTime.TryParse(startDateTimeNotParsed, out startDateTime);
            } while (!parsingResult);

            return (endDateTime-startDateTime).TotalDays;
        }

        /// <summary>
        /// Calculates the number of days between two given dates
        /// </summary>
        /// <returns>Number of days</returns>
        static double DaysBetweenDates()
        {
            DateTime startDateTime;
            DateTime endDateTime;
            bool parsingResult;

            do
            {
                Console.WriteLine();
                Console.Write("Enter a valid older date (YYYY-MM-DD or YYYY-MM-DD HH:MM:SS): ");
                string startDateTimeNotParsed = Console.ReadLine();
                parsingResult = DateTime.TryParse(startDateTimeNotParsed, out startDateTime);
            } while (!parsingResult);

            do
            {
                Console.WriteLine();
                Console.Write("Enter a valid newer date (YYYY-MM-DD or YYYY-MM-DD HH:MM:SS) or Enter for NOW: ");
                string endDateTimeNotParsed = Console.ReadLine();
                endDateTimeNotParsed = (endDateTimeNotParsed?.Trim() == string.Empty) ? DateTime.Now.ToString("s") : endDateTimeNotParsed;
                parsingResult = DateTime.TryParse(endDateTimeNotParsed, out endDateTime);
            } while (!parsingResult);

            return (endDateTime-startDateTime).TotalDays;
        }

        /// <summary>
        /// Calculates the date resulting of adding a given day and a given number of additional days
        /// </summary>
        /// <returns>Resulting date</returns>
        static DateTime DateAfterXDays()
        {
            DateTime startDateTime;
            int daysSpan;
            bool parsingResult;

            do
            {
                Console.WriteLine();
                Console.Write("Enter a valid date (YYYY-MM-DD or YYYY-MM-DD HH:MM:SS): ");
                string startDateTimeNotParsed = Console.ReadLine();
                parsingResult = DateTime.TryParse(startDateTimeNotParsed, out startDateTime);
            } while (!parsingResult);

            do
            {
                Console.WriteLine();
                Console.Write("Enter a valid number of days: ");
                string daysSpanNotParsed = Console.ReadLine();
                parsingResult = Int32.TryParse(daysSpanNotParsed, out daysSpan); 
            } while (!parsingResult);

            return startDateTime.AddDays(daysSpan);
        }
    }
}
