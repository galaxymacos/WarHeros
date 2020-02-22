public class Position
{
    public Position(int row, int column)
    {
        this.row = row;
        this.column = column;
    }
    
    public int row;
    public int column;

    public string Convert()
    {
        return (char)(this.row + 65) + this.column.ToString();
    }
}