package com.game;

import java.awt.event.KeyEvent;

public class Menu extends GameState {

    public Menu(){

    }
    public void Update(){
        //Kiedy wciśniemy enter to przejdze do SinglePlayer
        if (Keyboard.keys[KeyEvent.VK_ENTER]) {
            System.out.println("hue");
            GameStateManager.ChangeGameState(GameStateManager.GAME_STATE_SINGLEPLAY);
        }
    }
    public void Renderer(Screen menuScreen){
        menuScreen.clear(0x00ff00);
    }
}
