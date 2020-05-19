package com.game;


public class Map {
    private static final int X=16;
    private static final int Y=16;
    public int[][] bitMap = new int[X][Y];



    public void writeMapToTerminal(){
        for (int i = 0; i <X; i++) {
            for (int j = 0; j <Y; j++) {
                System.out.print(bitMap[i][j]);
                System.out.print(" ");
            }
            System.out.print('\n');
        }

    }
}
