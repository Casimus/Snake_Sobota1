using Raylib_cs;

public class Game
{
    public static int ScreenWidth { get; private set; }
    public static int ScreenHeight { get; private set; }
    public static int CellSize { get; private set; }
    private int fps = 10;
    private int score;
    private bool isGameOver;
    private Snake snake;

    // inicjalizacja gry
    private void Init()
    {
        ScreenWidth = 800;
        ScreenHeight = 600;
        CellSize = 40;
        score = 0;
        isGameOver = false;

        snake = new Snake();

        Raylib.InitWindow(ScreenWidth, ScreenHeight, "Snake");
        Raylib.SetTargetFPS(fps);

    }
    // uruchomienie gry -- pętla gry
    public void Run()
    {
        Init();

        while (!Raylib.WindowShouldClose())
        {
            Update();
            Draw();
        }
        Raylib.CloseWindow();
    }
    // aktualizacja fizyki 
    private void Update()
    {
        snake.Move();
    }
    // aktualizacja grafiki
    private void Draw()
    {
        Raylib.BeginDrawing();
        Raylib.ClearBackground(Raylib_cs.Color.Black);

        Raylib.DrawText(score.ToString().PadLeft(2, '0'), 20, 20, 40,
            Raylib_cs.Color.White);

        if (isGameOver)
        {
            Raylib.DrawText("Koniec Gry",
                ScreenWidth / 2 - 180,
                ScreenHeight / 2 - 70,
                70,
                Raylib_cs.Color.Red);

            Raylib.DrawText("Nacisnij \"Enter\" aby zaczac ponownie",
                ScreenWidth / 2 - 270,
                ScreenHeight / 2 + 20,
                30,
                Raylib_cs.Color.White);
        }
        else
        {
            snake.Draw();
        }
        Raylib.EndDrawing();
    }
}