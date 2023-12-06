using FindElement;

namespace Tests
{
    [TestClass]
    public class BinarySearchTests
    {
        int[] sortedArray = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
        [TestMethod]
        public void FindElementReturnCorrectIndex()
        {
            int result = BinarySearch.FindElement(sortedArray, 4);

            Assert.AreEqual(3, result);
        }

        [TestMethod]
        public void FindElementReturnMinusOne()
        {
            int result = BinarySearch.FindElement(sortedArray, 345);

            Assert.AreEqual(-1, result);
        }

        [TestMethod]
        public void FindFirstElementReturnCorrectIndex()
        {
            int result = BinarySearch.FindElement(sortedArray, 1);

            Assert.AreEqual(0, result);
        }

        [TestMethod]
        public void FindLastElementReturnCorrectIndex()
        {
            int result = BinarySearch.FindElement(sortedArray, 10);

            Assert.AreEqual(9, result);
        }

        [TestMethod]
        public void FindMiddleElementReturnCorrectIndex()
        {
            int result = BinarySearch.FindElement(sortedArray, 5);

            Assert.AreEqual(4, result);
        }
    }
}