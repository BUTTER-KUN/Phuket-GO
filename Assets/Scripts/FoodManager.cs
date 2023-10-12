using System;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public static class FoodManager
{
    
    /// <summary>
    /// This script takes the information from the CSV file with all of the fish
    /// information and creates a list of the Fish class with an instance for
    /// each fish in the csv file!
    /// </summary>
    
    public static List<Food> allFood = new List<Food>();

    //Run this when we hit play always
    [RuntimeInitializeOnLoadMethod]
    public static void InitFishManager() {
        //Access the csv file that contains fish data
        var textAsset = Resources.Load<TextAsset>("CSV/Food");
        
        //Split the text asset up into each line
        var splitData = textAsset.text.Split('\n');
        foreach (var line in splitData) { //Loop through the array we made of each line
            var lineData = line.Split(','); //Split each line up at the comma
            if (lineData[0] != "Food Name") { //Fish Name is contained on the first row, so we ignore that
                var newFood = new Food(lineData[0], lineData[1], Int32.Parse(lineData[2]), Int32.Parse(lineData[3])); //We then create a fish instance with the info we have read
                allFood.Add(newFood); //Add the new fish to the list
            }
        }
    }

    public static Food GetRandomFish() {
        //Picks out a random fish from the list
        return allFood[Random.Range(0, allFood.Count)];
    }

    public static Food GetRandomFishWeighted() {
        //Picks out a random fish using spoke weights
        var totalSpoke = 0;
        foreach (var fish in allFood) {
            totalSpoke += fish.spokeWeight;
        }
        var valueChosen = Random.Range(0, totalSpoke);
        foreach (var fish in allFood) {
            if (valueChosen < fish.spokeWeight) {
                return fish;
            } else {
                valueChosen -= fish.spokeWeight;
            }
        }
        return null;
    }
}
