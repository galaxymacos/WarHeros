public class NurseMoveCommand: Command
{
    public NurseChess nurse;
    public ChessMoveDirection ChessMoveDirection;

    public NurseMoveCommand(NurseChess chess, ChessMoveDirection chessMoveDirection)
    {
        nurse = chess;
        this.ChessMoveDirection = chessMoveDirection;
    }
    
    public override void Execute()
    {
        switch (ChessMoveDirection)
        {
            case ChessMoveDirection.top:
                nurse.Move(0,1);
                break;
            case ChessMoveDirection.down:
                nurse.Move(0,-1);
                break;
            case ChessMoveDirection.left:
                nurse.Move(-1,0);
                break;
            case ChessMoveDirection.right:
                nurse.Move(1, 0);
                break;
        }
    }
}