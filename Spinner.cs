public class Spinner : IObstacle
{
    private int _rotation;

    public Spinner(int rotationParameter)
    {
        _rotation = rotationParameter;
    }

    public bool BlocksMovement => false;

    public void Apply(Robot robot, Position target)
    {
        robot.Position = new Position(target.X, target.Y);
        robot.Direction = (Direction)(((int)robot.Direction + _rotation) % 4);
        robot.Path.Add(new Position(target.X, target.Y));
    }
}
