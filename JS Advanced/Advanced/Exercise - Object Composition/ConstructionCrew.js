function solution(worker) {
	if (worker.dizziness) {
		const waterNeeded = worker.experience * worker.weight * 0.1;
		worker.levelOfHydrated += waterNeeded;
		worker.dizziness = false;
	}
	return worker;
}
console.log(
	solution({ weight: 95, experience: 3, levelOfHydrated: 0, dizziness: false })
);
