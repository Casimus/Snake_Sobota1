using System.Numerics;
using Raylib_cs;

public class Snake
{
    private List<Vector2> body;
    private Vector2 direction;
    private bool isGrowing;

    public Snake()
    {
        body = new List<Vector2>();
        body.Add(new Vector2(Game.ScreenWidth / 2, Game.ScreenHeight / 2));
        direction = new Vector2(1, 0); // w prawo
        isGrowing = false;
    }

    // ruch węża
    public void Move()
    {
        Vector2 head = body[0];
        Vector2 newHead = new Vector2(
            head.X + direction.X * Game.CellSize,
            head.Y + direction.Y * Game.CellSize);

        if (isGrowing)
        {
            body.Insert(0, newHead);
            isGrowing = false;
        }
        else
        {
            for (int i = body.Count - 1; i > 0; i--)
            {
                body[i] = body[i - 1];
            }
            body[0] = newHead;
        }

        if (newHead.X >= Game.ScreenWidth) newHead.X = 0;
        if (newHead.X < 0) newHead.X = Game.ScreenWidth - Game.CellSize;

        if (newHead.Y >= Game.ScreenHeight) newHead.Y = 0;
        if (newHead.Y < 0) newHead.Y = Game.ScreenHeight - Game.CellSize;
        body[0] = newHead;
    }

    private void Grow()
    {
        isGrowing = true;
    }
    public void ChangeDirection(Vector2 newDirection)
    {
    }

    public void Draw()
    {
        foreach (var segment in body)
        {
            Raylib.DrawRectangle((int)segment.X, (int)segment.Y,
                Game.CellSize,
                Game.CellSize,
                Raylib_cs.Color.Green);
        }
    }
}