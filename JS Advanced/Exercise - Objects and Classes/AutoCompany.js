function autoComp(input) {
    const cars = {};
    while (input.length > 0) {
        const carInfo = input.shift().split(' | ');
        const carBrand = carInfo[0];
        const carModel = carInfo[1];
        const carPrice = Number(carInfo[2]);
        if (cars.hasOwnProperty(carBrand)) {
            if (cars[carBrand].hasOwnProperty(carModel)) {
                cars[carBrand][carModel] += carPrice;   
            }
            else{
                cars[carBrand][carModel] = carPrice;
            }
        }
        else{
            cars[carBrand] = {};
            cars[carBrand][carModel] = carPrice;
        }
    }
    for (const key in cars) {
            console.log(key);
            for (const carName in cars[key]) {
                    const carPrice = cars[key][carName];
                    console.log('###' + carName + ' -> ' + carPrice);
            }
    }
}
autoComp(
['Audi | Q7 | 1000',
'Audi | Q6 | 100',
'BMW | X5 | 1000',
'BMW | X6 | 100',
'Citroen | C4 | 123',
'Volga | GAZ-24 | 1000000',
'Lada | Niva | 1000000',
'Lada | Jigula | 1000000',
'Citroen | C4 | 22',
'Citroen | C5 | 10']
);