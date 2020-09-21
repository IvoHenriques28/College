int w = 10;
int h = 20;
int q = 20;//blocks width and height
int dt;// delay between each move
int currentTime;
Grid grid;
Piece piece;
Piece nextPiece;
Pieces pieces;
Score score;
int r = 0;//rotation status, from 0 to 3
int level = 1;
int nbLines = 0;

int txtSize = 20;
int textColor = color(34, 230, 190);

Boolean gameOver = false;
Boolean gameOn = false;
Boolean isMuted = false;

PImage startMenu;
PImage gameMenu;

import processing.sound.*;
SoundFile file;


void setup()
{
  size(600, 480, P2D);
  textSize(20);
  file = new SoundFile (this, "Tetris.mp3");
  file.play();
  file.loop();
  startMenu = loadImage("Menu.png");
  gameMenu = loadImage("Jogo.png");
}

void initialize() {
  level = 1;
  nbLines = 0;
  dt = 1000;
  currentTime = millis();
  score = new Score();
  grid = new Grid();
  pieces = new Pieces();
  piece = new Piece(-1);
  nextPiece = new Piece(-1);
}

void draw()
{
  background(gameMenu);

  if (grid != null) {
    grid.drawGrid();
    int now = millis();
    if (gameOn) {

      if(isMuted == false){
        file.amp(0.2);
      }


      if (now - currentTime > dt) {
        currentTime = now;
        piece.oneStepDown();
      }
    }
    piece.display(false);
    score.display();
  }
  if (gameOver) {
    noStroke();
    fill(255, 60);
    rect(110, 195, 240, 2*txtSize, 3);
    fill(textColor);
    text("Game Over", 120, 220);
  }
  if (!gameOn) {
   background(startMenu);
  }
}

void goToNextPiece() {
  
  piece = new Piece(nextPiece.kind);
  nextPiece = new Piece(-1);
  r = 0;
}

void goToNextLevel() {
  score.addLevelPoints();
  level = 1 + int(nbLines / 10);
  dt *= .8;

}

void keyPressed() {
  if (key == CODED && gameOn) {
    switch(keyCode) {
    case LEFT:
    case RIGHT:
    case DOWN:
    case UP:
    case SHIFT:
      piece.inputKey(keyCode);
      break;
    }
  } else if (keyCode == 80) {// "p"
    if (!gameOn) {
      initialize();
      
      gameOver = false;
      gameOn = true;
    }
  } else if (keyCode == 77) {// "m"
    if (isMuted == false && !gameOn) {
      file.amp(0);
      isMuted = true;
    } else if (isMuted == true && !gameOn) {
      file.amp(1);
      isMuted = false;
    } else if (isMuted == true && gameOn) {
      file.amp(0.2);
      isMuted = false;
    } else if (isMuted == false && gameOn) {
      file.amp(0);
      isMuted = true;
    }
  }
}
