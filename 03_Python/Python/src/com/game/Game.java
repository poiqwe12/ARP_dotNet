package com.game;

import javax.swing.*;
import javax.swing.text.Style;
import java.awt.*;
import java.awt.event.KeyAdapter;
import java.awt.event.KeyEvent;
import java.awt.event.KeyListener;
import java.awt.image.BufferStrategy;
import java.awt.image.BufferedImage;
import java.awt.image.DataBufferInt;

public class Game extends Canvas implements Runnable {
   //Zmienne do okienka
    private static final int WIDTH = 400;
    private static final int HEIGHT = 400;
    private JFrame jFrame;
    private BufferedImage image = new BufferedImage(50,50,BufferedImage.TYPE_INT_RGB);
    private int[] pixels = ((DataBufferInt)image.getRaster().getDataBuffer()).getData();
    //Obsługa klatek:
    private boolean running = false;
    private double timer = System.currentTimeMillis();
    private int FPS = 0;
    private int UPS = 0;
    private static final int UPS_MAX = 60;
    private double frametime = 1000000000 / UPS_MAX;
    private long timeNow = System.nanoTime();
    private long timeLast = System.nanoTime();
    private double delta;

    //Zażądzanie:
    private  GameStateManager gameStateManager;
    private Keyboard keyboard = new Keyboard();
    private Screen screen;

    public Game() {
        setPreferredSize(new Dimension(WIDTH, HEIGHT));
        jFrame = new JFrame("PYTHON");
        addKeyListener(new Keyboard());
        jFrame.add(this);
        jFrame.setLocation(200,200);
        jFrame.pack();

        jFrame.setResizable(false);
        jFrame.setVisible(true);
        jFrame.setDefaultCloseOperation(JFrame.EXIT_ON_CLOSE);

        screen = new Screen(10*50,10*50);
        gameStateManager = new GameStateManager();
    }

    public void Start(){
        if(running) return;  //Raz wykonana będzię natychmiast przerywana
        running = true;
        new Thread(this,"Game").start();
    }
    private void Stop(){
        if(!running) return;  //Raz wykonana będzię natychmiast przerywana
        running = false;
        jFrame.dispose();
        System.exit(0);
    }

    private void Update(){
        gameStateManager.Update();
    }

    private void Render(){
        BufferStrategy bufferStrategy = getBufferStrategy();
        if(bufferStrategy == null){
            createBufferStrategy(3);
           return;
        }
        Graphics graphics = bufferStrategy.getDrawGraphics();

        //Definiowanie tego co ma się wyświetlić:
        gameStateManager.Renderer(screen);
        graphics.drawImage(screen.GetImage(),0,0,WIDTH,HEIGHT,null);
        //Renderowanie klatki:
        graphics.dispose();
        bufferStrategy.show();
    }

    @Override
    public void run() {
        while (running){
            //Ograniczenie aktualizacji:
            timeNow = System.nanoTime();
            delta += (timeNow - timeLast) / frametime;
            timeLast = timeNow;
            while (delta>=1) {
                Update();   //LOGIKA
                UPS++;
                delta -= 1;
            }
            Render();   //GRAFIKA

            FPS++; //Zliczanie klatek
            if(System.currentTimeMillis()-timer >= 1000){
                timer = System.currentTimeMillis();
                System.out.println("FPS: "+ FPS);
                System.out.println("UPS: "+ UPS);
                FPS = 0;
                UPS = 0;
            }
        }
        Stop();
    }

    // @Override
   // public void keyTyped(KeyEvent e) {

    //}
   // @Override
   // public void keyPressed(KeyEvent e) {
    //    Keyboard.actualKeyboardChar = e.getKeyChar();
    //}

   // @Override
   // public void keyReleased(KeyEvent e) {

    //}

}


