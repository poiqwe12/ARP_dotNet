package com.game;

import java.util.ArrayList; // import the ArrayList class

public class Python {
   public ArrayList<Coordinates> body = new ArrayList<Coordinates>();
   public int actualDirection= 1;

    public void AddNewCoordinates(int x, int y){
        Coordinates coordinates = new Coordinates(x,y);
        body.add(coordinates);
    }
    public void AddNewCoordinates(Coordinates coordinates){
        body.add(coordinates);
    }
    public void DeleteLastCoordinates(){
        body.remove(0);
    }

}
