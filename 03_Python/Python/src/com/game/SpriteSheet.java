package com.game;

import javax.imageio.ImageIO;
import java.awt.image.BufferedImage;
import java.io.File;
import java.io.IOException;

public class SpriteSheet {
    public int  WIDTH, HEIGHT;
    public int[] pixels;

    public SpriteSheet(String path){
        try {
            File imageFile = new File(path);
            BufferedImage image = ImageIO.read(imageFile);
            WIDTH = image.getWidth();
            HEIGHT = image.getHeight();
            pixels = new int[WIDTH*HEIGHT];
            image.getRGB(0,0, WIDTH, HEIGHT, pixels,0,WIDTH);

        }
        catch (IOException e){
            e.printStackTrace();
        }
    }
}
