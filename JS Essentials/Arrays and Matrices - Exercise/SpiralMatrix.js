function spiralMatrix(rows,cols) {
let matr = [];
    for (let row = 0; row < rows; row++) {
        matr[row]=[];
    }
    let minCol = 0;
    let minRow = 0;
    let maxCol = cols;
    let maxRow = rows;
    let number = 1;
    while (number <= cols*rows) {
        for (let c = minCol; c < maxCol; c++) {
            matr[minRow][c] = number;
            number++;      
        }
        minRow++;
        for (let r = minRow; r < maxRow; r++) {
            matr[r][maxCol - 1] = number;
            number++;
        }
        maxCol--;
        for (let c = maxCol - 1; c >= minCol; c--) {
            matr[maxRow - 1][c] = number;
            number++;
        }
        maxRow--;
        for (let r = maxRow - 1; r >= minRow; r--) {
            matr[r][minCol] = number;
            number++;
        }
        minCol++;
    }
    matr.forEach(x => console.log(x.join(" ")));
}
spiralMatrix(5,5);
