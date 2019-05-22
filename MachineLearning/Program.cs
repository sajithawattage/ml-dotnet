using System;

namespace MachineLearning
{
    class Program
    {
        static void Main(string[] args)
        {

            HelloWorld.MachineLearningHelloWorld hello = new HelloWorld.MachineLearningHelloWorld();

            var predict = hello.GetPredictedHousePriceBySize(2.5f);

            Console.WriteLine($"Predicted price for size: {2.5f * 1000} sq ft= {predict.Price * 100:C}k");

            Console.WriteLine("Hello World!");

            Console.ReadKey();
        }
    }
}
