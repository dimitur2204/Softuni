function solve(input) {
    let propertyInfo = input.shift()
    .split("|")
    .map(x => x.trim())
    .filter(x => x != "");
    let townProperty = propertyInfo[0];
    let latitude = propertyInfo[1];
    let longitude = propertyInfo[2];
    let town1 = input.shift()    
    .split("|")
    .map(x => x.trim())
    .filter(x => x != "");
    function townInfo(input) {
        let town = {};
        town.Town = input.shift();
        town.Latitude = Number(input.shift());
        town.Longitude = Number(input.shift());
        return town;
    }
    let towns = [];
    if (input.length > 0) {
        let town2 = input.shift()    
        .split("|")
        .map(x => x.trim())
        .filter(x => x != "");
        towns.push(JSON.stringify(townInfo(town2)));
    }
    towns.push(JSON.stringify(townInfo(town1)));
    console.log(`[${towns.reverse().join(",")}]`);
}
solve(['| Town | Latitude | Longitude ','| Random Town | 0.00 | 0.00 |']
);