public class Grid
{
    private GridCell[,] cells;
    private int width, height;

    public Grid(int width, int height)
    {
        this.width = width;
        this.height = height;

        cells = new GridCell[width, height];

        for (int x = 0; x < width; x++)
            for (int y = 0; y < height; y++)
                cells[x, y] = new GridCell();
    }
    
    public bool IsInside(Position p)
    {
        return p.X >= 0 && p.X < width && p.Y >= 0 && p.Y < height;
    }

    public GridCell GetCell(Position p)
    {
        return cells[p.X, p.Y];
    }
    
    public void AddObstacle(int x, int y, IObstacle obstacle)
    {
        cells[x, y].Obstacle = obstacle;
    }
}
