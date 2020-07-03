function solve() {
	function mage(input) {
		const mageName = input;
		let mageHealth = 100;
		let mageMana = 100;
		function name(mageName) {
			return mageName;
		}
		function cast(spellName) {
			console.log(`${mageName} cast ${spellName}`);
			mageMana--;
		}
		return {
			get name() {
				return mageName;
			},
			get health() {
				return mageHealth;
			},
			get mana() {
				return mageMana;
			},
			cast,
		};
	}
	function fighter(input) {
		const fighterName = input;
		let fighterHealth = 100;
		let fighterStamina = 100;
		function fight() {
			console.log(`${fighterName} slashes at the foe!`);
			fighterStamina--;
		}
		return {
			get name() {
				return fighterName;
			},
			get health() {
				return fighterHealth;
			},
			get stamina() {
				return fighterStamina;
			},
			fight,
		};
	}
	return {
		mage,
		fighter,
	};
}
let create = solve();
const scorcher = create.mage('Scorcher');
scorcher.cast('fireball');
scorcher.cast('thunder');
scorcher.cast('light');

const scorcher2 = create.fighter('Scorcher 2');
scorcher2.fight();

console.log(scorcher2.stamina);
console.log(scorcher.mana);
