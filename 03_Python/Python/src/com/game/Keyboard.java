package com.game;

import java.awt.event.KeyEvent;
import java.awt.event.KeyListener;

public class Keyboard implements KeyListener {
    private static final int actualKeyRead = 200;
    public static boolean keys[] = new boolean[actualKeyRead];

    public Keyboard(){
        for(int i=0; i<actualKeyRead;i++){
            keys[i] = false;
        }
    }

    @Override
    public void keyTyped(KeyEvent e) {

    }

    @Override
    public void keyPressed(KeyEvent e) {
        keys[e.getKeyCode()] = true;
    }

    @Override
    public void keyReleased(KeyEvent e) {
        keys[e.getKeyCode()] = false;

    }
}
