public class NurseChess: Chess
{
    public NurseChess(Position position) : base(position)
    {
    }
    
    public void Move(int x, int y)
    {
        position.x += x;
        position.y += y;
    }
}