function store(input) {
    const store = {};
    while (input.length > 0) {
        const productInfo = input.shift().split(' : ');
        const name = productInfo[0];
        const letter = name[0];
        const price = +productInfo[1];
        if (store.hasOwnProperty(letter)) {
            store[letter].push(name + ": " + price);
        }
        else{
            store[letter] = [];
            store[letter].push(name + ": " + price);
        }
    }
    for (const key of Object.keys(store).sort()) {
        console.log(key);
        const items = store[key].sort((a,b) =>{
            return a.name - b.name;
        });
        for (const item of items.sort()) {
            console.log(item);
        }
    }
}
store(
    ['Appricot : 20.4',
'Fridge : 1500',
'TV : 1499',
'Deodorant : 10',
'Boiler : 300',
'Apple : 1.25',
'Anti-Bug Spray : 15',
'T-Shirt : 10']
);