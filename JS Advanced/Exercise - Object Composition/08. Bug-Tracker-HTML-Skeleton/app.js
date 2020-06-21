function solve() {
	const comparator = {
		ID: (a, b) => a[0] - b[0],
		author: (a, b) => a[1].author.localeCompare(b[1].author),
		severity: (a, b) => a[1].severity - b[1].severity,
	};
	let currentId = 0;
	const displayEl = null;
	let reports = new Map();
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
		const reportsEntries = Array.from(reports.entries());
		if (method == 'ID') {
			reportsEntries.sort((a, b) => comparator.ID(a, b));
		} else if (method == 'author') {
			reportsEntries.sort((a, b) => comparator.author(a, b));
		} else if (method == 'severity') {
			reportsEntries.sort((a, b) => comparator.severity(a, b));
		}
		reports = reportsEntries.reduce((acc, curr) => {
			acc.set(curr[0], curr[1]);
			return acc;
		}, new Map());
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
tracker.report('Gosho', 'A big bug', true, 10);
tracker.report('Asen', 'Buggy', true, 5);
tracker.report('Sasho', 'Annoying bug', true, 1);
tracker.sort('author');
