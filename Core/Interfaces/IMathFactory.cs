namespace Core.Interfaces
{
    public interface IMathFactory
    {
        IMatrix CreateMatrix(int rows, int cols);
        IVector CreateVector(int len);
        IScalarFunction CreateScalarFunction(string textual);
    }
}
