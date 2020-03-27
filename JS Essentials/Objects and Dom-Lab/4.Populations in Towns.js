function solve(input) {
    let result = {};
    
    while (input.length > 0) {     
        let  townSth = input.shift();
         let townInfo = townSth.split(" <-> ");
            if(!result[townInfo[0]]){
                result[townInfo[0]]=0;
            }
            result[townInfo[0]]+=Number(townInfo[1]);
    }
    for (const town in result) {
console.log(`${town} : ${result[town]}`);
    }
}
solve(["Sofia <-> 1200000",
    "Montana <-> 20000",
    "New York <-> 10000000",
    "Washington <-> 2345000",
    "Las Vegas <-> 1000000",
    ]);