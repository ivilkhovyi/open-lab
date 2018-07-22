namespace Core.Interfaces
{
    public interface IVector : IMatrix
    {
        double this[int i] { get; set; }
    }
}
