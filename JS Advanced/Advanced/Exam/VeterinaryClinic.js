class VeterinaryClinic {
	constructor(clinicName, capacity) {
		this.clinicName = clinicName;
		this.capacity = capacity;
		this.clients = [];
		this.customers = [];
		this.totalProfit = 0;
		this.currentWorkload = 0;
	}
	calculateWorkload() {
		const perc =
			(this.clients.filter((c) => c.procedures.length > 0).length /
				this.capacity) *
			100;
		this.currentWorkload = perc;
	}
	newCustomer(ownerName, petName, kind, procedures) {
		if (this.clients.filter((c) => c.procedures.length > 0) == this.capacity) {
			throw new Error('Sorry, we are not able to accept more patients!');
		}
		const pet = {
			name: petName,
			kind,
			procedures,
		};
		const customer = this.customers.find((c) => c.name == ownerName);
		if (customer) {
			let pet = customer.pets.find((p) => p.name == petName);
			if (pet && pet.procedures.length > 0) {
				throw new Error(
					`This pet is already registered under ${ownerName} name! ${petName} is on our lists, waiting for ${customer.pets.procedures.join(
						', '
					)}.`
				);
			} else if (pet) {
				pet.procedures = procedures;
			} else {
				pet = {
					name: petName,
					kind,
					procedures,
				};
				customer.pets.push(pet);
				this.clients.push(pet);
			}
		} else {
			const newCustomer = {
				name: ownerName,
				pets: [pet],
			};
			this.customers.push(newCustomer);
			this.clients.push(pet);
		}
		this.calculateWorkload();
		return `Welcome ${petName}!`;
	}
	onLeaving(ownerName, petName) {
		const customer = this.customers.find((c) => c.name == ownerName);
		if (!customer) {
			throw new Error('Sorry, there is no such client!');
		}
		const pet = customer.pets.find((p) => p.name == petName);
		if (!pet || pet.procedures.length == 0) {
			throw new Error(`Sorry, there are no procedures for ${petName}!`);
		}
		this.totalProfit += pet.procedures.length * 500;
		pet.procedures = [];
		this.calculateWorkload();
		return `Goodbye ${petName}. Stay safe!`;
	}
	toString() {
		let result = '';
		result += `${this.clinicName} is ${this.currentWorkload}% busy today!\n`;
		result += `Total profit: ${this.totalProfit.toFixed(2)}$\n`;
		for (const owner of this.customers.sort((a, b) => {
			return a.name.localeCompare(b.name);
		})) {
			result += `${owner.name} with:\n`;
			for (const pet of owner.pets.sort((a, b) => {
				return a.name.localeCompare(b.name);
			})) {
				result += `---${
					pet.name
				} - a ${pet.kind.toLowerCase()} that needs: ${pet.procedures.join(
					', '
				)}\n`;
			}
		}
		return result.trim();
	}
}
let clinic = new VeterinaryClinic('SoftCare', 10);
console.log(
	clinic.newCustomer('Jim Jones', 'Tom', 'Cat', ['A154B', '2C32B', '12CDB'])
);
console.log(
	clinic.newCustomer('Anna Morgan', 'Max', 'Dog', ['SK456', 'DFG45', 'KS456'])
);
console.log(clinic.newCustomer('Jim Jones', 'Tiny', 'Cat', ['A154B']));
console.log(clinic.onLeaving('Jim Jones', 'Tiny'));
console.log(clinic.toString());
clinic.newCustomer('Jim Jones', 'Sara', 'Dog', ['A154B']);
console.log(clinic.toString());
