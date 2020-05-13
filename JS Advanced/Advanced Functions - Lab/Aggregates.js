function solve(input) {
    function reducer(arr,operator,initial) {
        let result = initial;
        for (const element in arr) {
            result = operator(result,arr[element]);
        }
        return result;
    }
    console.log('Sum = ' + reducer(input,(a,b) => a + b,0));
    console.log('Min = ' + reducer(input,(a,b) => Math.min(a,b),0));
    console.log('Max = ' + reducer(input,(a,b) => Math.max(a,b),0));
    console.log('Product = ' + reducer(input,(a,b) => a*b,1));
    console.log('Join = ' + reducer(input,(a,b) =>a.toString()+b.toString(),''));
}
solve([5, -3, 20, 7, 0.5]);