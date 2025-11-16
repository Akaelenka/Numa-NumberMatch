using UnityEngine;

public class TableUtilities
{
    public static int GetRow(int index, int columns)
    {
        // Use zero-based indexing: row = index / columns
        return index / columns;
    }

    public static int GetCol(int index, int columns)
    {
        // Use zero-based indexing: col = index % columns
        return index % columns;
    }

    //public static bool IsHorizontal(int a, int b, int columns)
    //{
    //    return GetRow(a, columns) == GetRow(b, columns);
    //}

    //public static bool IsVertical(int a, int b, int columns)
    //{
    //    return GetCol(a, columns) == GetCol(b, columns);
    //} 

    //public static bool IsDiagonal(int a, int b, int columns)
    //{
    //    int r1 = GetRow(a, columns);
    //    int c1 = GetCol(a, columns);
    //    int r2 = GetRow(b, columns);
    //    int c2 = GetCol(b, columns);

    //    return Mathf.Abs(r1 - r2) == Mathf.Abs(c1 - c2);
    //}

    //public static bool IsFollowingDirection(int a, int b, int columns)
    //{
    //    if (IsHorizontal(a, b, columns))
    //    {
    //        return true;
    //    }
    //    if (IsVertical(a, b, columns))
    //    {
    //        return true;
    //    }
    //    if (IsDiagonal(a, b, columns))
    //    {
    //        return true;
    //    }
    //    return false;
    //}
}
