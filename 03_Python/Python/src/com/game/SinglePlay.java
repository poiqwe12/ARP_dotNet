package com.game;

import java.awt.*;
import java.awt.event.KeyEvent;
import java.util.Random;


public class SinglePlay extends GameState {

    private static final int MAX_X=10;
    private static final int MAX_Y=10;

    private static final Sprite allone_stone = new Sprite(0,0,50,mainSpriteSheet);
    private static final Sprite allone_snake = new Sprite(0,1,50,mainSpriteSheet);
    private static final Sprite papu = new Sprite(0,2,50,mainSpriteSheet);

    private Python python = new Python();
    private Random generator = new Random();
    private Coordinates papuCoordinates = new Coordinates(2,2);

    private double nextMoveTime = System.currentTimeMillis();

    public SinglePlay(){
        python.AddNewCoordinates(4,6);
        python.AddNewCoordinates(4,5);
        python.AddNewCoordinates(4,4);

    }
    public void Update(){
        if(System.currentTimeMillis()-nextMoveTime >= 200) {
            nextMoveTime = System.currentTimeMillis();
            UpdateKaybord(); //Odczytanie klawiszy
            SnakeMove(); //Ruch wenża
            if(DetectColision()) { //Sprawdzenie kolizji
                while (System.currentTimeMillis() - nextMoveTime <= 3000);
                GameStateManager.ChangeGameState(GameStateManager.GAME_STATE_MENU);
            }
        }

    }
    public void Renderer(Screen singlePlayScreen){
        singlePlayScreen.clear(Color.BLACK.getRGB());
        DrawSnake(singlePlayScreen);
        DrawPapu(singlePlayScreen);
    }


    private void DrawSnake(Screen singlePlayScreen){
        //Rysowanie wenża:
        for (Coordinates cor: python.body)
        {
            singlePlayScreen.RenderSprite(cor.X*50, cor.Y*50, allone_snake);
        }
    }
    private void DrawPapu(Screen singlePlayScreen){
        //Rysowanie papu:
            singlePlayScreen.RenderSprite(papuCoordinates.X*50, papuCoordinates.Y*50, papu);
    }
private void  UpdateKaybord(){
    //Aktualizacja kierunku
    if(Keyboard.keys[KeyEvent.VK_UP] && python.actualDirection != 2)
        python.actualDirection = 1;
    if(Keyboard.keys[KeyEvent.VK_DOWN] && python.actualDirection != 1)
        python.actualDirection = 2;
    if(Keyboard.keys[KeyEvent.VK_LEFT] && python.actualDirection != 4)
        python.actualDirection = 3;
    if(Keyboard.keys[KeyEvent.VK_RIGHT] && python.actualDirection != 3)
        python.actualDirection = 4;
}

    private void SnakeMove(){
        int temp_X = python.body.get(python.body.size()-1).X;
        int temp_Y = python.body.get(python.body.size()-1).Y;

        //Ruch
        if(python.actualDirection == 1) {
            if (temp_Y == 0) temp_Y = MAX_Y;
            temp_Y = temp_Y- 1;
            python.AddNewCoordinates(temp_X, temp_Y);
        }
        if(python.actualDirection == 2) {
            if(temp_Y==MAX_Y-1) temp_Y = -1;
            temp_Y = temp_Y + 1;
            python.AddNewCoordinates(temp_X, temp_Y);
        }
        if(python.actualDirection == 3) {
            if(temp_X==0) temp_X = MAX_X;
            temp_X = temp_X - 1;
            python.AddNewCoordinates(temp_X, temp_Y);
        }
        if(python.actualDirection == 4) {
            if(temp_X==MAX_X-1) temp_X = -1;
            temp_X = temp_X + 1;
            python.AddNewCoordinates(temp_X, temp_Y);
        }

        //Usunięcie końca wenża:
        boolean ok = false;
        if(temp_X == papuCoordinates.X && temp_Y == papuCoordinates.Y ) {
            while (ok == false) {
                papuCoordinates.X = generator.nextInt(9);
                papuCoordinates.Y = generator.nextInt(9);
                ok = true;
                for (Coordinates coor : python.body) {
                    if (papuCoordinates.X == coor.X && papuCoordinates.Y == coor.Y)
                    ok = false;
                }
            }
        }
        else python.DeleteLastCoordinates();
    }

    private boolean DetectColision(){
        int temp_X = python.body.get(python.body.size()-1).X;
        int temp_Y = python.body.get(python.body.size()-1).Y;
        for(int i=0; i<python.body.size()-2; i++){
            if (temp_X == python.body.get(i).X && temp_Y == python.body.get(i).Y )
                return true;
        }
        return false;
    }


}
