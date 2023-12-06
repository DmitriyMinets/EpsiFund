namespace FindElement
{
    public class BinarySearch
    {
        public static int FindElement(int[] sortArr, int targetValue)
        {
            int left = 0;
            int right = sortArr.Length - 1;

            while (left <= right)
            {
                int middle = left + (right - left) / 2;
                if (sortArr[middle] == targetValue)
                    return middle;
                else if (sortArr[middle] < targetValue)
                    left = middle + 1;
                else
                    right = middle - 1;
            }
            return -1;
        }
    }
}
