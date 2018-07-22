namespace Core.Extensions
{
    public static class CommonHelper
    {
        public static void SwapWith<T>(this T a, T b)
        {
            T temp = a;
            a = b;
            b = temp;
        }
    }
}
