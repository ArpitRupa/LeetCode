
namespace LeetcodeSolutions
{
    public abstract class SolutionClass
    {
        protected abstract int Solution(string s);
        public void Test(string testCase, int expected)
        {
            int result = this.Solution(testCase);
            Console.WriteLine($"{result}, expected: {expected}");
        }
    }
}