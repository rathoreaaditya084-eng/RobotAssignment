class Program
{
    static void Main()
    {
        var grid = new Grid(10, 10);

        grid.AddObstacle(2, 2, new Rock());
        grid.AddObstacle(3, 3, new Hole(new Position(0, 0)));
        grid.AddObstacle(4, 4, new Spinner(1));

        Robot robot = new Robot(new Position(1, 1), Direction.North, grid);

        robot.Execute("LFFRFF");

        Console.WriteLine("Final Position: " + robot.Position);
        Console.WriteLine("Direction: " + robot.Direction);

        Console.WriteLine("Path:");
        foreach (var p in robot.Path)
            Console.WriteLine(p);

        Console.ReadKey();
    }
}





