using System.Diagnostics;
using System.Runtime.InteropServices;

namespace SP_HM_1
{
    internal class Program
    {
        [DllImport("User32.dll", EntryPoint = "MessageBox", CharSet = CharSet.Auto)]
        internal static extern int MsgBox(IntPtr hWnd, string lpText, string lpCaption, uint uType);
        [DllImport("kernel32.dll")]
        public static extern bool Beep(int frequency, int duration);
        [DllImport("user32.dll")]
        public static extern bool MessageBeep(uint uType);

        static void Main(string[] args)
        {
            //  MAIN TASK

            /*Process process = Process.Start(new ProcessStartInfo("notepad.exe"));

            process.WaitForExit();
            Console.WriteLine(process.ExitCode);*/

            //  ADDITIONAL TASK 1

            /* MsgBox(0, "My name is Nazar", "Bio", 0);
             MsgBox(0, "I'm 19 years old", "Bio", 0);
             MsgBox(0, "Hard skills: C++ | C# | WinForms | WPF | UML", "Bio", 0);*/

            //  ADDITIONAL TASK 2

            /*for (int i = 0; i < 3; i++)
            {
                Beep(100, 500);

                Thread.Sleep(1000);

                MessageBeep(0xFFFFFFFF);

                Thread.Sleep(1000);
            }*/

            //  ADDITIONAL TASK 3

            /*Process process = Process.Start(new ProcessStartInfo("notepad.exe"));
            
            Console.WriteLine("Enter action:\n1 - Wait for exit and get exit code\n2 - Force exit");

            Console.Write("-> ");
            switch (Console.ReadLine())
            {
                case "1":
                    process.WaitForExit();
                    Console.WriteLine($"Exit code: {process.ExitCode}");
                    break;
                case "2":
                    process.CloseMainWindow();
                    break;
                default:
                    Console.WriteLine("Something went wrong!");
                    break;
            }*/

            // ADDITIONAL TASK 4

            /*const uint MB_OK = 0x00000000;
            const uint MB_YESNO = 0x00000004;
            const uint IDYES = 6;

            bool playAgain;
            do
            {
                playAgain = false;
                int countOfTries = 1;
                int min = 0;
                int max = 100;
                int guess;
                int response;

                MsgBox(0, "Guess a number between 0 and 100", "Guess the number", MB_OK);

                while (true)
                {
                    guess = (min + max) / 2;
                    response = MsgBox(0, $"Your number is {guess}?", "Guess the number", MB_YESNO);
                    if (response == IDYES)
                    {
                        MsgBox(0, $"Game if finished\nCount of tries: {countOfTries}", "Guess the number", MB_OK);
                        break;
                    }

                    response = MsgBox(0, $"Your number is greater than {guess}?", "Guess the number", MB_YESNO);
                    if (response == IDYES)
                    {
                        min = guess + 1;
                    }
                    else
                    {
                        max = guess - 1;
                    }
                    countOfTries++;
                }

                response = MsgBox(0, "Wanna play again?", "Guess the number", MB_YESNO);
                if (response == IDYES)
                {
                    playAgain = true;
                }
            } while (playAgain);*/

            //  ADDITIONAL TASK 5

            /*Process process;
            Console.Write("Which application you want to start:\n1 - Notepad\n2 - Calculator\n3 - Paint\n4 - Choose application by yourself\n-> ");
            switch (Console.ReadLine())
            {
                case "1":
                    process = Process.Start(new ProcessStartInfo("notepad.exe"));
                    break;
                case "2":
                    process = Process.Start(new ProcessStartInfo("calc.exe"));
                    break;
                case "3":
                    process = Process.Start(new ProcessStartInfo("mspaint.exe"));
                    break;
                case "4":
                    Console.Write("To start your own application you should insert full path to .exe file\n" +
                        @"Example: C:\Program Files\Google\Chrome\Application\chrome.exe" +
                        "\n\nYour path: ");
                    string path = Console.ReadLine();
                    process = Process.Start(new ProcessStartInfo(path));
                    break;
                default:
                    Console.WriteLine("Something went wrong!");
                    break;
            }*/
        }
    }
}
