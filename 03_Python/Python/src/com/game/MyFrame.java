package com.game;

import javax.swing.*;
import java.awt.*;
import java.awt.event.KeyAdapter;
import java.awt.event.KeyEvent;
import java.awt.event.KeyListener;

public class MyFrame extends JFrame implements KeyListener  {

    public char actualKeyChar = '0';

    public MyFrame() {
        super( "Python" );
        setPreferredSize(new Dimension(400, 400));
        setLocation(200,200);
        addKeyListener(this);

        pack();
        setVisible(true);
        setDefaultCloseOperation(JFrame.EXIT_ON_CLOSE);
    }

    @Override
    public void keyTyped(KeyEvent e) {

    }
    @Override
    public void keyPressed(KeyEvent e) {
        Keyboard.actualKeyboardChar = e.getKeyChar();
    }

    @Override
    public void keyReleased(KeyEvent e) {

    }

}


