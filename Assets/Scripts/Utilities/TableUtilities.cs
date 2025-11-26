public class TableUtilities
{
    public static int GetRow(int index, int columns)
    {
        return index / columns;
    }

    public static int GetCol(int index, int columns)
    {
        return index % columns;
    }
}
