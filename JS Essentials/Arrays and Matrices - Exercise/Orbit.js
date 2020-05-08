function solve(arr) {
    let cols = arr[1];
    let rows = arr[0];
    let colIndex = arr[2];
    let rowIndex = arr[3];
    let matr = [];
    for (let row = 0; row < rows; row++) {
        matr.push([]);
    }
    for (let row = 0; row < rows; row++) {
        for (let col = 0; col < cols; col++) {
           matr[row][col] = Math.max(Math.abs(row - rowIndex),Math.abs(col - colIndex)) + 1;
        }       
    }
    console.log(matr.map(row => row.join(" ")).join("\n"));
}
solve([4, 4, 0, 0]);