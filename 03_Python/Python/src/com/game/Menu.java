package com.game;

import java.awt.event.KeyEvent;

public class Menu extends GameState {
    public static final int QUONTITY_OF_LVL = 10;
    public static final int KEY_FRQ = 200;

    private double nextMoveTime = System.currentTimeMillis();

    //Sprajty:
    private static final Sprite lvl1 = new Sprite(0,3,50,mainSpriteSheet);
    private static final Sprite lvl2 = new Sprite(1,3,50,mainSpriteSheet);
    private static final Sprite lvl3 = new Sprite(2,3,50,mainSpriteSheet);
    private static final Sprite lvl4 = new Sprite(3,3,50,mainSpriteSheet);
    private static final Sprite lvl5 = new Sprite(4,3,50,mainSpriteSheet);
    private static final Sprite lvl6 = new Sprite(5,3,50,mainSpriteSheet);
    private static final Sprite lvl7 = new Sprite(6,3,50,mainSpriteSheet);
    private static final Sprite lvl8 = new Sprite(7,3,50,mainSpriteSheet);
    private static final Sprite lvl9 = new Sprite(8,3,50,mainSpriteSheet);
    private static final Sprite lvl10 = new Sprite(9,3,50,mainSpriteSheet);

    private static final Sprite lockLvL = new Sprite(0,4,50,mainSpriteSheet);
    private static final Sprite activeLvL = new Sprite(1,4,50,mainSpriteSheet);


    boolean[] levelsActive = new boolean[QUONTITY_OF_LVL];

    public Menu(){
        for(int i=0; i<QUONTITY_OF_LVL; i++){
            levelsActive[i] = false;
        }
        levelsActive[0] = true;
    }
    public void Update(){
        if(System.currentTimeMillis()-nextMoveTime >= KEY_FRQ) {
            nextMoveTime = System.currentTimeMillis();
            int temp_gameLvL = GameStateManager.GetGameLvL();
        if (Keyboard.keys[KeyEvent.VK_LEFT]) {
            if(temp_gameLvL == 1) {
                GameStateManager.ChangeGameLvL(QUONTITY_OF_LVL);
            }
            else {
                GameStateManager.ChangeGameLvL(temp_gameLvL-1);
            }
        }
        if (Keyboard.keys[KeyEvent.VK_RIGHT]) {
            if(temp_gameLvL == QUONTITY_OF_LVL) {
                GameStateManager.ChangeGameLvL(1);
            }
            else {
                GameStateManager.ChangeGameLvL(temp_gameLvL+1);
            }
        }
        //Kiedy wciśniemy enter to przejdze do SinglePlayer
            if(levelsActive[GameStateManager.GetGameLvL()-1]==true){
                if (Keyboard.keys[KeyEvent.VK_ENTER]) {
                    GameStateManager.ChangeGameState(GameStateManager.GAME_STATE_SINGLEPLAY);
                }
            }
        }
    }
    public void Renderer(Screen menuScreen){
        menuScreen.clear(0xbfbfbf);
        DrawLevelIcon(menuScreen);
        DrawDisactiveIcon(menuScreen);
        DrawActualChoosenIcon(menuScreen);
    }

    private void DrawLevelIcon( Screen menuScreen){
        menuScreen.RenderSprite(1 * 50, 1 * 50, lvl1);
        menuScreen.RenderSprite(3 * 50, 1 * 50, lvl2);
        menuScreen.RenderSprite(5 * 50, 1 * 50, lvl3);
        menuScreen.RenderSprite(7 * 50, 1 * 50, lvl4);
        menuScreen.RenderSprite(1 * 50, 3 * 50, lvl5);
        menuScreen.RenderSprite(3 * 50, 3 * 50, lvl6);
        menuScreen.RenderSprite(5 * 50, 3 * 50, lvl7);
        menuScreen.RenderSprite(7 * 50, 3 * 50, lvl8);
        menuScreen.RenderSprite(1 * 50, 5 * 50, lvl9);
        menuScreen.RenderSprite(3 * 50, 5 * 50, lvl10);
    }

    public void DrawDisactiveIcon(Screen menuScreen){
        menuScreen.RenderSprite(3 * 50, 1 * 50, lockLvL);
        menuScreen.RenderSprite(5 * 50, 1 * 50, lockLvL);
        menuScreen.RenderSprite(7 * 50, 1 * 50, lockLvL);
        menuScreen.RenderSprite(1 * 50, 3 * 50, lockLvL);
        menuScreen.RenderSprite(3 * 50, 3 * 50, lockLvL);
        menuScreen.RenderSprite(5 * 50, 3 * 50, lockLvL);
        menuScreen.RenderSprite(7 * 50, 3 * 50, lockLvL);
        menuScreen.RenderSprite(1 * 50, 5 * 50, lockLvL);
        menuScreen.RenderSprite(3 * 50, 5 * 50, lockLvL);
    }
    public void DrawActualChoosenIcon(Screen menuScreen){
        if(GameStateManager.GetGameLvL()==1)
            menuScreen.RenderSprite(1 * 50, 1 * 50, activeLvL);
        if(GameStateManager.GetGameLvL()==2)
            menuScreen.RenderSprite(3 * 50, 1 * 50, activeLvL);
        if(GameStateManager.GetGameLvL()==3)
            menuScreen.RenderSprite(5 * 50, 1 * 50, activeLvL);
        if(GameStateManager.GetGameLvL()==4)
            menuScreen.RenderSprite(7 * 50, 1 * 50, activeLvL);
        if(GameStateManager.GetGameLvL()==5)
            menuScreen.RenderSprite(1 * 50, 3 * 50, activeLvL);
        if(GameStateManager.GetGameLvL()==6)
            menuScreen.RenderSprite(3 * 50, 3 * 50, activeLvL);
        if(GameStateManager.GetGameLvL()==7)
            menuScreen.RenderSprite(5 * 50, 3 * 50, activeLvL);
        if(GameStateManager.GetGameLvL()==8)
            menuScreen.RenderSprite(7 * 50, 3 * 50, activeLvL);
        if(GameStateManager.GetGameLvL()==9)
            menuScreen.RenderSprite(1 * 50, 5 * 50, activeLvL);
        if(GameStateManager.GetGameLvL()==10)
            menuScreen.RenderSprite(3 * 50, 5 * 50, activeLvL);
    }
}
