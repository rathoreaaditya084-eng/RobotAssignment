public class Hole : IObstacle
{
    private Position _connected;

    public Hole(Position connectedPosition)
    {
        _connected = connectedPosition;
    }

    public bool BlocksMovement => false;

    public void Apply(Robot robot, Position target)
    {
        robot.Position = new Position(_connected.X, _connected.Y);
        robot.Path.Add(new Position(_connected.X, _connected.Y));
    }
}
