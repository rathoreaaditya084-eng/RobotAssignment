public class Robot
{
    public Position Position { get; internal set; }
    public Direction Direction { get; internal set; }
    public List<Position> Path { get; } = new List<Position>();

    private Grid grid;

    public Robot(Position start, Direction dir, Grid grid)
    {
        Position = start;
        Direction = dir;
        this.grid = grid;

        Path.Add(new Position(start.X, start.Y));
    }


    public void Execute(string commands)
    {
        foreach (char c in commands)
        {
            if (c == 'L') TurnLeft();
            else if (c == 'R') TurnRight();
            else if (c == 'F') MoveForward();
        }
    }

    private void TurnLeft()
    {
        Direction = (Direction)(((int)Direction + 3) % 4);
    }

    private void TurnRight()
    {
        Direction = (Direction)(((int)Direction + 1) % 4);
    }

    private void MoveForward()
    {
        int x = Position.X;
        int y = Position.Y;

        Position next = Direction switch
        {
            Direction.North => new Position(x, y + 1),
            Direction.East => new Position(x + 1, y),
            Direction.South => new Position(x, y - 1),
            Direction.West => new Position(x - 1, y),
            _ => Position
        };

        if (!grid.IsInside(next))
            return;

        var cell = grid.GetCell(next);

        if (cell.Obstacle != null)
        {
            if (cell.Obstacle.BlocksMovement)
                return;

            cell.Obstacle.Apply(this, next);
            return;
        }

        Position = next;
        Path.Add(new Position(Position.X, Position.Y));
    }
}
