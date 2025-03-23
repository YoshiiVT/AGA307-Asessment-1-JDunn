using UnityEngine;


public enum GameState
{
    Start,
    Playing,
    Paused
}
public enum Difficulty
{
    Easy,
    Medium,
    Hard
}
public class GameManager : Singleton<GameManager>
{
    public int Score;
    public GameState gameState;
    public Difficulty difficulty; 

}
