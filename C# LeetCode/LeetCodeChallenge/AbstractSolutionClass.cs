
namespace LeetcodeSolutions
{
    //TInput and TOutput used as generics for abstract class
    public abstract class SolutionClass<TInput, TOutput>
    {
        protected abstract TOutput Solution(TInput input);
        public void Test(TInput testCase, TOutput expected)
        {
            TOutput result = this.Solution(testCase);
            Console.WriteLine($"{result}, expected: {expected}");
        }
    }
}