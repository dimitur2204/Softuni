function createReporter() {
	let elementToDeploy = '';
	function report(author, description, reproducible, severity) {
		const bugs = Array.from(document.querySelectorAll('.report'));
		const bug = {
			ID: bugs.length,
			author: author,
			description: description,
			reproducible: reproducible,
			severity: severity,
			status: 'Open',
		};
		let html = `<div id="report_${bug.ID}" class="report">
  <div class="body">
    <p>${bug.description}</p>
  </div>
  <div class="title">
    <span class="author">Submitted by: ${bug.author}</span>
    <span class="status">${bug.status} | ${bug.severity}</span>
  </div>
</div>`;
		elementToDeploy.innerHTML += html;
	}
	function setStatus(id, newStatus) {
		const bugs = Array.from(document.querySelectorAll('.report'));
		const bug = bugs.find((b) => b.id == `report_${id}`);
		bug.querySelector('.status').innerHTML = `${newStatus} | ${bug.severity}`;
	}
	function remove(id) {
		const bugs = Array.from(document.querySelectorAll('.report'));
		const bug = bugs.find((b) => b.id == `report_${id}`);
		bug.remove();
	}
	function sort(method) {
		bugs.sort((a, b) => {
			if (method == 'author') {
				return a.localeCompare(b);
			} else {
				return a[method] - b[method];
			}
		});
	}
	function output(selector) {
		elementToDeploy = selector;
	}
	return {
		report,
		setStatus,
		remove,
		sort,
		output,
	};
}
let tracker = createReporter();
let elementToDeploy = document.getElementById('content');
tracker.output(elementToDeploy);
tracker.report('asdf', 'asdf', true, 5);
tracker.setStatus(3, 'else');
