namespace Core.Interfaces
{
    public interface IMatrix
    {
        int firstDimension { get; }
        int secondDimension { get; }

        double this[int row, int col] { get; set; }
    }
}
