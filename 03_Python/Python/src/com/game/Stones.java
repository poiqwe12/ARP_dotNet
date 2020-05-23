package com.game;

import java.util.ArrayList;

public class Stones {
    public ArrayList<Coordinates> body = new ArrayList<Coordinates>();

    public Stones(){

    }
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
