package com.game;

import java.util.ArrayList; // import the ArrayList class

public class Python {
    ArrayList<Coordinates> body = new ArrayList<Coordinates>(); // Create an ArrayList object


    public void AddNewCoordinates(int x, int y){
        Coordinates coordinates = new Coordinates(x,y);
        body.add(coordinates);
    }
    public void AddNewCoordinates(Coordinates coordinates){
        body.add(coordinates);
    }
    public void DeleteLastCoordinates(){
        body.remove(body.size()-1);
    }

}
