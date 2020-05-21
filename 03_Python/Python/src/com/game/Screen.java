package com.game;

import java.awt.image.BufferedImage;
import java.awt.image.DataBufferInt;
import java.util.Scanner;

public class Screen {
    public final int WIDTH;
    public final int HEIGHT;

    private BufferedImage bufferedImage;
    private int[] pixels;

    public Screen(int width, int height){
        WIDTH = width;
        HEIGHT = height;
        bufferedImage = new BufferedImage(WIDTH,HEIGHT,BufferedImage.TYPE_INT_RGB);
        pixels = ((DataBufferInt)bufferedImage.getRaster().getDataBuffer()).getData();
    }

    public void clear(int color){
        for(int i = 0; i < WIDTH*HEIGHT; i++ ){
            pixels[i] = color;
        }
    }
    public BufferedImage GetImage(){
        return bufferedImage;
    }

    public void  RenderSprite(int x, int y, Sprite sprite){
        for(int i = 0; i < sprite.size ;i++){
            for(int j = 0; j < sprite.size ;j++){
                DrawPixel(x+i,y+j, sprite.spriteSheet.pixels[(sprite.X*sprite.size)+i + ((sprite.Y*sprite.size) + j * sprite.spriteSheet.WIDTH)]);
            }
        }
    }

    public void DrawFillRectangle(int x, int y, int width, int height, int color){
        for(int i = 0; i < height ;i++){
            for(int j = 0; j < width ;j++){
                DrawPixel(x+i,y+j, color);
            }
        }
    }
    private void DrawPixel(int x,int y,int color){
        if(x<0 || x>=WIDTH ||
           y<0 || y>=HEIGHT || color == 0xFFFF00FF) return;
        pixels[x+y*WIDTH] = color;
    }

}
