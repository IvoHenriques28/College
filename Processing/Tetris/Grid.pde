class Grid {
  int [][] cells = new int[w][h];

  Grid() {
    for (int i = 0; i < w; i ++) {
      for (int j = 0; j < h; j ++) {
        cells[i][j] = 0;
        //        if(j>h-3 && i<w-1){
        //          cells[i][j] = color(23, 34, 189);
        //        }
      }
    }
  }

  Boolean isFree(int x, int y) {
    if (x > -1 && x < w && y > -1 && y < h) {
      return cells[x][y] == 0;
    } else if (y < 0) {
      return true;
    }
    
    return false;
  }

  Boolean pieceFits() {
    int x = piece.x;
    int y = piece.y;
    int[][][] pos = piece.pos;
    Boolean pieceOneStepDownOk = true;
    for (int i = 0; i < 4; i ++) {
      int tmpx = pos[r][i][0]+x;
      int tmpy = pos[r][i][1]+y;
      if (tmpy >= h || !isFree(tmpx, tmpy)) {
        pieceOneStepDownOk = false;
        break;
      }
    }
    return pieceOneStepDownOk;
  }

  void addPieceToGrid() {
    int x = piece.x;
    int y = piece.y;
   
    int[][][] pos = piece.pos;
    for (int i = 0; i < 4; i ++) {
      if(pos[r][i][1]+y >= 0){
        cells[pos[r][i][0]+x][pos[r][i][1]+y] = piece.c;
      }else{
        gameOn = false;
        gameOver = true;
      
        return;
      }
    }
    
    score.addPiecePoints();
    checkFullLines();
    goToNextPiece();
    drawGrid();
  }

  void checkFullLines() {
    int nb = 0;//number of full lines
    for (int j = 0; j < h; j ++) {
      Boolean fullLine = true;
      for (int i = 0; i < w; i++) {
        fullLine = cells[i][j] != 0;
        if (!fullLine) {
          break;
        }
      }
      
      if (fullLine) {
        nb++;
        for (int k = j; k > 0; k--) {
          for (int i = 0; i < w; i++) {
            cells[i][k] = cells[i][k-1];
          }
        }
       
        for (int i = 0; i < w; i++) {
          cells[i][0] = 0;
        }
      }
    }
    deleteLines(nb);
    
  }

  void deleteLines(int nb) {
    
    nbLines += nb;
    if (int(nbLines / 10) > level-1) {
      goToNextLevel();
    }
    score.addLinePoints(nb);
  }

  void setToBottom() {
    
    int j = 0;
    for (j = 0; j < h; j ++) {
      if (!pieceFits()) {
        break;
      } else {
        piece.y++;
      }
    }
    piece.y--;
    addPieceToGrid();
  }

  void drawGrid() {
    stroke(120);
    pushMatrix();
    translate(160, 40);
    for (int i = 0; i <= w; i ++) {
      line(i*q, 0, i*q, h*q);
    }
    for (int j = 0; j <= h; j ++) {
      line(0, j*q, w*q, j*q);
    }

    stroke(80);
    for (int i = 0; i < w; i ++) {
      for (int j = 0; j < h; j ++) {
        if (cells[i][j] != 0) {
          fill(cells[i][j]);
          rect(i*q, j*q, q, q);
        }
      }
    }
    popMatrix();
  }
}
