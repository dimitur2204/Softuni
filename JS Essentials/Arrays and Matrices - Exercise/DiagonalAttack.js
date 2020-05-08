function solve(matr) {
    function mainDiagSum(matr) {
        let sum = 0;
        for (let i = 0; i < matr.length; i++) {
            for (let j = 0; j < matr[i].length; j++) {
                if (i == j) {
                    sum+=matr[i][j];
                }
            }
        }
        return sum;
    }
    function secDiagSum(params) {
        let sum = 0;
        for (let i = 0; i < matr.length; i++) {
            for (let j = 0; j < matr[i].length; j++) {
                if (i == matr.length - j - 1) {
                    sum+=matr[i][j];
                }
            }
        }
        return sum;
    }
    for (let index = 0; index < matr.length; index++) {
        matr[index] = matr[index].split(" ").map(Number);
    }
    if (mainDiagSum(matr) == secDiagSum(matr)) {
        for (let i = 0; i < matr.length; i++) {
            for (let j = 0; j < matr[i].length; j++) {
                if (i != j && i != matr.length - j - 1) {
                    matr[i][j]=mainDiagSum(matr);
                }
            }
        }
    }
matr.forEach(element => {
    console.log(element.join(" "));
});
}
solve(
['5 3 12 3 1',
'11 4 23 2 5',
'101 12 3 21 10',
'1 4 5 2 2',
'5 22 33 11 1']
);