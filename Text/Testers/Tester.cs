using TechSpecChecking.Text.Analisators;

namespace TechSpecChecking.Text.Testers
{
    public abstract class Tester
    {
        public abstract void Test();

        protected void PrintAnalisatorResult(IAnalisator analisator, bool result, string error)
        {
            if (result == false)
            {
                System.Console.WriteLine($"{analisator.Name} has finished its work unsuccessfully with error:");
                System.Console.WriteLine(error);
                System.Console.WriteLine();

                return;
            }

            System.Console.WriteLine($"{analisator.Name} has finished its work successfully.");
            System.Console.WriteLine();
        }
    }
}