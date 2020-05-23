package com.game;

import java.awt.*;
import java.awt.event.KeyEvent;
import java.util.Random;


public class SinglePlay extends GameState {

    private static final int MAX_X=10;
    private static final int MAX_Y=10;
    private static final int SNAKE_SPEED = 300;
    private static final int STONES_QUONTITY = 5;

    //Sprajty:
    private static final Sprite allone_stone = new Sprite(0,0,50,mainSpriteSheet);
    private static final Sprite up_stone = new Sprite(1,0,50,mainSpriteSheet);
    private static final Sprite down_stone = new Sprite(2,0,50,mainSpriteSheet);
    private static final Sprite left_stone = new Sprite(4,0,50,mainSpriteSheet);
    private static final Sprite right_stone = new Sprite(3,0,50,mainSpriteSheet);
    private static final Sprite all_stone = new Sprite(5,0,50,mainSpriteSheet);
    private static final Sprite left_right_stone = new Sprite(6,0,50,mainSpriteSheet);
    private static final Sprite up_down_stone = new Sprite(7,0,50,mainSpriteSheet);

    private static final Sprite head_snake = new Sprite(0,1,50,mainSpriteSheet);
    private static final Sprite _snake = new Sprite(1,1,50,mainSpriteSheet);
    private static final Sprite papu = new Sprite(0,2,50,mainSpriteSheet);

    private Python python = new Python();
    private Stones stones = new Stones();
    private Random generator = new Random();
    private Coordinates papuCoordinates = new Coordinates(-20,-20);

    private double nextMoveTime = System.currentTimeMillis();

    public SinglePlay(){
        //Generowanie wenża:
        python.AddNewCoordinates(4,6);
        python.AddNewCoordinates(4,5);
        python.AddNewCoordinates(4,4);
        //Generowanie przeszkód:
        GenerateRandomStone(STONES_QUONTITY);
        //Generowanie papu
        GeneratePapu();
    }
    public void Update(){
        UpdateKaybord(); //Odczytanie klawiszy
        if(System.currentTimeMillis()-nextMoveTime >= SNAKE_SPEED) {
            nextMoveTime = System.currentTimeMillis();
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
        DrawStones(singlePlayScreen);
    }


    private void DrawSnake(Screen singlePlayScreen){
        //Rysowanie wenża:
        for (int i = 0; i < python.body.size(); i++) {
            if(i < python.body.size()-1)
                singlePlayScreen.RenderSprite(python.body.get(i).X * 50, python.body.get(i).Y * 50, _snake);
            else
                singlePlayScreen.RenderSprite(python.body.get(i).X*50, python.body.get(i).Y*50, head_snake);
        }
    }
    private void DrawPapu(Screen singlePlayScreen){
        //Rysowanie papu:
            singlePlayScreen.RenderSprite(papuCoordinates.X*50, papuCoordinates.Y*50, papu);
    }

    private void DrawStones(Screen singlePlayScreen){
        //Rysowanie kumieni:
        for(Coordinates coor: stones.body) {
            singlePlayScreen.RenderSprite(coor.X * 50, coor.Y * 50, allone_stone);
        }
    }

    private void  UpdateKaybord(){
    //Aktualizacja kierunku
    if(Keyboard.keys[KeyEvent.VK_UP] && python.actualDirection != 2)
        python.newActualDirection = 1;
    if(Keyboard.keys[KeyEvent.VK_DOWN] && python.actualDirection != 1)
        python.newActualDirection = 2;
    if(Keyboard.keys[KeyEvent.VK_LEFT] && python.actualDirection != 4)
        python.newActualDirection = 3;
    if(Keyboard.keys[KeyEvent.VK_RIGHT] && python.actualDirection != 3)
        python.newActualDirection = 4;
}

    private void GenerateRandomStone(int quontity){
        int temp_X = 0,temp_Y = 0;

        for(int q =0; q<quontity; q++) {
            boolean corect = false;
            while (corect == false) {
                temp_X = generator.nextInt(9);
                temp_Y = generator.nextInt(9);
                corect = true;
                for (int i = 0; i < python.body.size() - 1; i++) {
                    if (temp_X == python.body.get(i).X && temp_Y == python.body.get(i).Y)
                        corect = false;
                }
                for(int j = 0; j < stones.body.size() - 1; j++) {
                    if (temp_X == stones.body.get(j).X && temp_Y == stones.body.get(j).Y)
                        corect = false;
                }
                if((temp_X == 4 && temp_Y == 3) || (temp_X == 4 && temp_Y == 2) )
                    corect = false;
            }
            stones.AddNewCoordinates(temp_X, temp_Y);
            //System.out.println(temp_X +" - "+ temp_Y);

        }
    }

    private void SnakeMove(){
        int temp_X = python.body.get(python.body.size()-1).X;
        int temp_Y = python.body.get(python.body.size()-1).Y;

        //Ruch
        if(python.newActualDirection == 1) {
            if (temp_Y == 0) temp_Y = MAX_Y;
            temp_Y = temp_Y- 1;
            python.AddNewCoordinates(temp_X, temp_Y);
            python.actualDirection =1;
        }
        if(python.newActualDirection == 2) {
            if(temp_Y==MAX_Y-1) temp_Y = -1;
            temp_Y = temp_Y + 1;
            python.AddNewCoordinates(temp_X, temp_Y);
            python.actualDirection =2;
        }
        if(python.newActualDirection == 3) {
            if(temp_X==0) temp_X = MAX_X;
            temp_X = temp_X - 1;
            python.AddNewCoordinates(temp_X, temp_Y);
            python.actualDirection =3;
        }
        if(python.newActualDirection == 4) {
            if(temp_X==MAX_X-1) temp_X = -1;
            temp_X = temp_X + 1;
            python.AddNewCoordinates(temp_X, temp_Y);
            python.actualDirection =4;
        }

        //Usunięcie końca wenża:

        if(temp_X == papuCoordinates.X && temp_Y == papuCoordinates.Y ) {
            GeneratePapu();
        }
        else python.DeleteLastCoordinates();
    }

    private void GeneratePapu(){
        boolean ok = false;
        while (ok == false) {
            papuCoordinates.X = generator.nextInt(9);
            papuCoordinates.Y = generator.nextInt(9);
            ok = true;
            for (Coordinates coor : python.body) {
                if (papuCoordinates.X == coor.X && papuCoordinates.Y == coor.Y)
                    ok = false;
            }
            for(int j = 0; j < stones.body.size(); j++) {
                if (papuCoordinates.X == stones.body.get(j).X && papuCoordinates.Y == stones.body.get(j).Y)
                    ok = false;
            }
        }
    }

    private boolean DetectColision(){
        int temp_X = python.body.get(python.body.size()-1).X;
        int temp_Y = python.body.get(python.body.size()-1).Y;
        for(int i=0; i<python.body.size()-2; i++){
            if (temp_X == python.body.get(i).X && temp_Y == python.body.get(i).Y )
                return true;
        }
        for(int i=0; i<stones.body.size(); i++){
            if (temp_X == stones.body.get(i).X && temp_Y == stones.body.get(i).Y )
                return true;
        }
        return false;
    }


}
