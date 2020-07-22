function solve() {
	const comparator = {
		ID: (a, b) => a[0] - b[0],
		author: (a, b) => a[1].author.localeCompare(b[1].author),
		severity: (a, b) => a[1].severity - b[1].severity,
	};
	let currentId = 0;
	let displayEl = null;
	let reports = new Map();
	let status = 'Open';
	function report(author, description, reproducible, severity) {
		const currReport = {
			ID: currentId,
			author,
			description,
			reproducible,
			severity,
			status,
		};
		reports.set(currentId, currReport);
		currentId++;
		render();
	}
	function setStatus(id, newStatus) {
		const report = reports.get(id);
		report.status = newStatus;
		render();
	}
	function remove(id) {
		reports.delete(id);
		render();
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
		render();
	}
	function render() {
		displayEl.innerHTML = '';
		for (const report of Array.from(reports.values())) {
			let htmlString = `<div id="report_${report.ID}" class="report">
			<div class="body">
			  <p>${report.description}</p>
			</div>
			<div class="title">
			  <span class="author">Submitted by: ${report.author}</span>
			  <span class="status">${report.status} | ${report.severity}</span>
			</div>
		  </div>
		  `;
			displayEl.innerHTML += htmlString;
		}
	}
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
let tracker = solve();
tracker.output('#content');
tracker.report('Gosho', 'A big bug', true, 10);
tracker.report('Asen', 'Buggy', true, 5);
tracker.report('Sasho', 'Annoying bug', true, 1);
tracker.sort('author');
tracker.setStatus(1, 'WOOOW');
tracker.remove(1);
