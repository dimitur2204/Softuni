function solve(input) {
    let heroes = [];
    while (input.length > 0) {
        heroInfo = input.shift().split(' / ');
        const name = heroInfo[0];
        const level = Number(heroInfo[1]);
        let items = heroInfo[2];
        items = items ? heroInfo[2].split(', ') : [];
        heroes.push({name,level,items});
    }
    console.log(JSON.stringify(heroes));
}
solve(
    ['Isacc / 25 / Apple, GravityGun',
'Derek / 12 / BarrelVest, DestructionSword',
'Hes / 1 / Desolator, Sentinel, Antara']
);