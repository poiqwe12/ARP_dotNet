package com.company;

import com.game.Keyboard;
import com.game.Map;
import com.game.MyFrame;

import java.awt.*;

public class Main {

    public static void main(String[] args) {

        EventQueue.invokeLater(new Runnable() {
            @Override
            public void run() {
                new MyFrame();
            }
        });

        Map map = new Map();
        map.writeMapToTerminal();
while (true) {
    System.out.println(Keyboard.actualKeyboardChar);
}
    }
}

