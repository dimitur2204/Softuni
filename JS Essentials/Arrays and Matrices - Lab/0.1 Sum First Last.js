function solve(matr) {
    let count = 0;
    for (let i = 0; i < matr.length; i++) {
        for (let j = 0; j < matr[i].length; j++) {
            if (i == matr.length - 1) {
                if(matr[i][j] == matr[i][j + 1]) {
                    count ++;                  
                }
                continue;
            }
            if(matr[i][j] == matr [i + 1][j] || matr[i][j] == matr[i][j + 1]) {
                count ++;              
            }
        }
    }
    console.log(count);
}
solve(
    [['2', '3', '4', '7', '0'],
    ['4', '0', '5', '3', '4'],
    ['2', '3', '5', '4', '2'],
    ['9', '8', '7', '5', '4']]
   
)
