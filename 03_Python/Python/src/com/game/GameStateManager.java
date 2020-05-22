package com.game;

public class GameStateManager {
    public static final int GAME_STATE_MENU = 0;
    public static final int GAME_STATE_SINGLEPLAY = 1;

    private static GameState gameState;

    public GameStateManager(){
        ChangeGameState(GAME_STATE_MENU);
    }

    public static void ChangeGameState(int ID){
        if(ID == GAME_STATE_MENU) gameState = new Menu();
        if(ID == GAME_STATE_SINGLEPLAY) gameState = new SinglePlay();
    }

    public void Update(){
        gameState.Update();

    }
    public void Renderer(Screen screen){
        gameState.Renderer(screen);
    }

}
