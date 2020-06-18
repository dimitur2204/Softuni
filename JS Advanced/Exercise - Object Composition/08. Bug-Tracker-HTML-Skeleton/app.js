function solve() {
	const comparator = {
		ID: (a, b) => a.ID - b.ID,
		author: (a, b) => a.localeCompare(b),
		severity: (a, b) => a.severity - b.severity,
	};
	let currentId = 0;
	const displayEl = null;
	const reports = new Map();
	let status = 'Open';
	function report(author, description, reproducible, severity) {
		const currReport = {
			ID: currentId,
			author,
			description,
			reproducible,
			severity,
			get status() {
				return status;
			},
			set status(value) {
				this.status = value;
			},
		};
		reports.set(currentId, currReport);
		currentId++;
	}
	function setStatus(id, newStatus) {
		const report = reports.get(id);
		report.status = newStatus;
	}
	function remove(id) {
		reports.delete(id);
	}
	function sort(method) {
		for (const item of reports.entries()) {
			console.log(item);
		}
	}
	function render() {}
	function output(selector) {
		displayEl = document.querySelector(selector);
	}
	return {
		report,
		setStatus,
		remove,
		sort,
		output,
	};
}
var tracker = solve();
tracker.report('Peter', 'A big bug', true, 10);
tracker.sort();
