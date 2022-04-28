using System;
using System.Threading.Tasks;

/*
If you mark a method with the async modifier, you can use the await operator in the method. 
when control reaches an await expression in the async method, control returns to the caller, 
and progress in the method is suspended until the awaited task completes. 
When the task is complete, execution can resume in the method.
https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/concepts/async/
 */
namespace AsyncBreakfast
{
    /*
     The Coffee, Egg, Bacon, Toast, and Juice classes are empty. 
    They are simply marker classes for the purpose of demonstration, contain no properties, and serve no other purpose.
     */
    class Coffee { }
    class Egg { }
    class Bacon { }

    class Test
    {
        static async Task Main()
        {
            Coffee cup = PourCoffee();
            Console.WriteLine("Coffee is ready");

            // egg炒完後再做培根
            Task<Egg> eggsTask = FryEggsAsync(2);
            Task<Bacon> baconTask = FryBaconAsync(3);

            // 當FryEggsAsync完成才列印
            //Egg eggs = await eggsTask;
            //Bacon bacon = await baconTask;

            //await Task.WhenAll(eggsTask, baconTask);
            //Console.WriteLine("Eggs are ready");
            //Console.WriteLine("Bacon is ready");

            var breakfastTasks = new List<Task>() { eggsTask, baconTask };

            while (breakfastTasks.Count > 0)
            {
                Task finishTask = await Task.WhenAny(breakfastTasks);

                if (finishTask == eggsTask)
                {
                    Console.WriteLine("Eggs are ready");
                }
                else
                {
                    Console.WriteLine("Bacon is ready");
                }

                breakfastTasks.Remove(finishTask);
            }

        }


        private static Coffee PourCoffee()
        {
            Console.WriteLine("Pouring coffee...");
            return new Coffee();
        }
        private static async Task<Egg> FryEggsAsync(int numEgg)
        {
            Console.WriteLine("Warming the pan");
            //Task.Delay(3000).Wait();
            //Console.WriteLine($"Cooking {numEgg} eggs...");
            Task.Delay(10000).Wait();

            return new Egg();
        }
        private static async Task<Bacon> FryBaconAsync(int slices)
        {
            Console.WriteLine($"putting {slices} slices of bacon in the pan");
            Console.WriteLine("cooking first side of bacon...");
            Task.Delay(1000).Wait();
            for (int slice = 0; slice < slices; slice++)
            {
                Console.WriteLine("flipping a slice of bacon");
            }
            Console.WriteLine("cooking the second side of bacon...");
            Task.Delay(1000).Wait();
            Console.WriteLine("Put bacon on plate");

            return new Bacon();
        }
    }
}

