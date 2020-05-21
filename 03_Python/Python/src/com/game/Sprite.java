package com.game;

public class Sprite {
    public int X,Y, size;
    public SpriteSheet spriteSheet;

    public Sprite(int x, int y, int newSize, SpriteSheet newSpriteSheet){
        X=x;
        Y=y;
        spriteSheet = newSpriteSheet;
        size = newSize;
    }


}
