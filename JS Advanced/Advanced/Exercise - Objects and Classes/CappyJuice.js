function cappy(input) {
    const juices = {};
    const bottles = {};
    while (input.length > 0) {
        const juiceInfo = input.shift().split(' => ');
        const juiceType = juiceInfo[0];
        const juiceQuant = Number(juiceInfo[1]);
        if (juices.hasOwnProperty(juiceType)) {
            juices[juiceType] += juiceQuant;
        }
        else{
            juices[juiceType] = 0;
            juices[juiceType] += juiceQuant;
        }
        while (juices[juiceType] >= 1000) {
            if (bottles.hasOwnProperty(juiceType)) {
                bottles[juiceType]++;
            }
            else{
                bottles[juiceType] = 0;
                bottles[juiceType]++;
            }
            juices[juiceType] -= 1000;
        }
    }
    for (const key in bottles) {
        if (bottles.hasOwnProperty(key)) {
            const element = bottles[key];
            console.log(key + ' => ' + element);
        }
    }
}
cappy(['Orange => 2000',
'Peach => 1432',
'Banana => 450',
'Peach => 600',
'Strawberry => 549']

);