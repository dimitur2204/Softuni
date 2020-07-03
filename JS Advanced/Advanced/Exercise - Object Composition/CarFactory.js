function assembleCar(carWanted) {
	const smallEngine = { power: 90, volume: 1800 };
	const normalEngine = { power: 120, volume: 2400 };
	const monsterEngine = { power: 200, volume: 3500 };
	function createEngine(power) {
		if (power <= 90) {
			return smallEngine;
		} else if (power > 90 && power <= 120) {
			return normalEngine;
		} else {
			return monsterEngine;
		}
	}
	function createCarriage(carriage, color) {
		if (carriage == 'coupe') {
			return { type: 'coupe', color };
		} else {
			return { type: 'hatchback', color };
		}
	}
	function createWheels(wheelsize) {
		if (wheelsize % 2 != 0) {
			return [wheelsize, wheelsize, wheelsize, wheelsize];
		}
		let wheelsizeNeeded = wheelsize - 1;
		return [wheelsizeNeeded, wheelsizeNeeded, wheelsizeNeeded, wheelsizeNeeded];
	}
	return {
		model: carWanted.model,
		engine: createEngine(carWanted.power),
		carriage: createCarriage(carWanted.carriage, carWanted.color),
		wheels: createWheels(carWanted.wheelsize),
	};
}
console.log(
	assembleCar({
		model: 'VW Golf II',
		power: 90,
		color: 'blue',
		carriage: 'hatchback',
		wheelsize: 14,
	})
);
