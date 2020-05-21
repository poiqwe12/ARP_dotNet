package com.company;

import com.game.Game;

import java.awt.*;

public class Main {

    public static void main(String[] args) {

        EventQueue.invokeLater(new Runnable() {
            @Override
            public void run() {
                new Game().Start();
            }
        });

    }
}

