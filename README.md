# LightsOutGame

## Details

This game is implemented as a WinForms solution, c# .Net.


The game for a 5 by 5 grid in the .Net environment. Each new game starts with a random number generated, causing the tiles to be displayed in a random fashion. 

If you want to start a new game, you can do this via the 'New Game' button.  

If you want to exit the game you can do this by hiting the 'Exit' button.


## Development

The Solution as ben split into a Classes and Interfaces folder, with the Form1.cs and Program.cs

The basis of each of the files are as fllows:

      Program.cs - This is the main entry point for the application, the GameGrid interface is used here to create the GameGrid and this is passed into the Form, with .Run (See GameGrid.cs in the clases folder)

      Form1.cs - This contains code for the button events and also the 'painting' of the grid upon the user clicking in the 5 x 5 grid.  The constructor of this class takes in   the GameGrid interface.  This is then used within Form1_Paint and Form1_MouseDown methods. 
      
      GameGrid.cs - The method GameGrid(), which in turn calls a private method - PopulateAndSetUpGrid(), which is used for both a new game via the button, in which case a random selection of tiles will be populated, and for initialisation of the grid upfrnt - in which case no tiles will be pre-sected. 
      
      A private variable - bool[,] - This 2-D 5 x 5 boolean array is used for the setting up of the grid, populated: 
                0 to 4 (5), e.g. elements 0,0 (false) 0,1 (false),  0,2 (false),  0,3 (false),  0,4 (false)
                                          1,0 (false) 1,1 (false),  1,2 (false),  1,3 (false),  1,4 (false)
                                          
      This array forms the basis of the logic for the game - with the values set in this aray correspopnding to the 5 x 5 cells in the grid. 
                   
                  - The method StartNewGame() - this is called when the 'New Game' button is clicked.
                  
                  - The method InvertTileSelection() - this is called to invert the boolean array values based on the click event.
                  
                  - The method GameWon() this is used to determine is the player has won.  It is called in the Form1_MouseDown method.
                   

## Unit Tests

There are a small number of unit tests implemented in the solution - these do give some coverage but given the time permitted I have kept these to a minimum. 
                                          




