using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Multithreading
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            var toastTask = MakeToast();
            var eggsTask = MakeEggs();
            var breakfastTasks = new List<Task> { toastTask , eggsTask};

            while (breakfastTasks.Count > 0) 
            {
                Task finishedTask = await Task.WhenAny(breakfastTasks);

                if (finishedTask == toastTask) 
                {
                    Console.WriteLine("Toast is ready");
                }
                else if (finishedTask == eggsTask) 
                {
                    Console.WriteLine("Eggs are ready");
                }
                breakfastTasks.Remove(finishedTask);
            }

            Console.WriteLine("Breakfast is ready");
            await Task.Delay(500000);
        }

        private static async Task<Toast> MakeToast() 
        {
            var toast = await ToastBreadAsync();

            return toast;
        }

        private static async Task<Toast> ToastBreadAsync() 
        {
            Console.WriteLine("Starting toasting");
            await Task.Delay(3000);
            Console.WriteLine("Bread toasted");
            return new Toast();
        }

        private static async Task<Eggs> MakeEggs()
        {
            var eggs = await CookEggsAsync(6000);

            return eggs;
        }

        private static async Task<Eggs> CookEggsAsync(int time) 
        {
            await ReadyPanAsync(3000);
            Console.WriteLine("Cooking eggs");
            await Task.Delay(time);
            Console.WriteLine("Eggs are cooked");
            return new Eggs();
        }
        private static async Task<Eggs> ReadyPanAsync(int time) 
        {
            Console.WriteLine("Warming up pan");
            await Task.Delay(time);
            Console.WriteLine("Pan is ready");
            return new Eggs();
        }
    }

    internal class Toast { }
    internal class Eggs { }
}
