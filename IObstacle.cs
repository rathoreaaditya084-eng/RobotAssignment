public interface IObstacle
{
    bool BlocksMovement { get; }
    void Apply(Robot robot, Position target);
}
