class Piece {
  final color[] colors = {
    color(128, 12, 128), //purple
    color(230, 12, 12), //red
    color(12, 230, 12), //green
    color(9, 239, 230), //cyan 
    color(230, 230, 9), //yellow
    color(230, 128, 9), //orange
    color(12, 12, 230) //blue
  };

  
  final int[][][] pos;
  int x = int(w/2);
  int y = 0;
  int kind;
  int c;

  Piece(int k) {
    kind = k < 0 ? int(random(0, 7)) : k;
    c = colors[kind];
    r = 0;
    pos = pieces.pos[kind];
  }

  void display(Boolean still) {
    stroke(250);
    fill(c);
    pushMatrix();
    if (!still) {
      translate(160, 40);
      translate(x*q, y*q);
    }
    int rot = still ? 0 : r;
    for (int i = 0; i < 4; i++) {
      rect(pos[rot][i][0] * q, pos[rot][i][1] * q, 20, 20);
    }
    popMatrix();
  }

  
  void oneStepDown() {
    y += 1;
    if(!grid.pieceFits()){
      piece.y -= 1;
      grid.addPieceToGrid();
    }
  }

  
  void oneStepLeft() {
    x -= 1;
    
      x+=1;
    }
  

 
  void oneStepRight() {
    x += 1;
    
      x -= 1;
    }
  

  void goToBottom() {
    grid.setToBottom();
  }

  void inputKey(int k) {
    switch(k) {
    case LEFT:
      x --;
      if(grid.pieceFits()){
        
      }else {
         x++; 
      }
      break;
    case RIGHT:
      x ++;
      if(grid.pieceFits()){
        
      }else{
         x--; 
      }
      break;
    case DOWN:
      oneStepDown();
      break;
    case UP:
      r = (r+1)%4;
      if(!grid.pieceFits()){
         r = r-1 < 0 ? 3 : r-1; 
        
      }else{
        
      }
      break;
    case SHIFT:
      goToBottom();
      break;
    }
  }
}
