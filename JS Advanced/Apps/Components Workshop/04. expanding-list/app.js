class ExpandingList extends HTMLUListElement {
	set toggled(val) {
		this._toggled = val;
	}
	get toggled() {
		return this._toggled;
	}
	constructor() {
		super();
		this.toggled = false;
		this.querySelectorAll('li').forEach((e) => {
			if (e.children.length > 0) {
				e.classList.add('closed');
				Array.from(e.children).forEach((e) => {
					e.style.display = 'none';
				});
			}
		});
		this.addEventListener('click', (e) => {
			const liEl = e.target;
			if (liEl.tagName.toLowerCase() === 'li' && liEl.children.length > 0) {
				if (liEl.classList.contains('closed')) {
					liEl.classList.remove('closed');
					liEl.classList.add('open');
					Array.from(liEl.children).forEach((e) => {
						e.style.display = '';
					});
					return;
				}
				liEl.classList.remove('open');
				liEl.classList.add('closed');
				Array.from(liEl.children).forEach((e) => {
					e.style.display = 'none';
				});
				return;
			}
		});
	}
}
customElements.define('ul-expand', ExpandingList, { extends: 'ul' });
