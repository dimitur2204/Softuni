function solve(matr) {
    let isMagical = true;
    let magicalRows = true;
    let magicalCols = true;
    let previousSum;
    let previousColsSum;
    for (let row = 0; row < matr.length; row++) {
        let rowsSum = 0;    

        for (let col = 0; col < matr[row].length; col++) {
            rowsSum += matr[row][col];
        }
        if(rowsSum != previousSum && row != 0){
            magicalRows = false;
        }
        previousSum = rowsSum; 
    }
    for (let row = 0; row < matr.length; row++) { 
        let colsSum = 0; 
        for (let col = 0; col < matr.length; col++) {
            colsSum += matr[col][row];
        }
        if(colsSum != previousSum && row != 0){
            magicalCols = false;
        }
        previousColsSum = colsSum;     
    }
    console.log(magicalRows && magicalCols);
}
solve(
    [[1, 0, 0],
    [0, 0, 1],
    [0, 1, 0]]  
);