class ButtonComponent extends HTMLButtonElement {
	static get observedAttributes() {
		return ['btn-type', 'text'];
	}

	set btnType(newValue) {
		if (this._btnType) {
			this.classList.remove(this._btnType);
		}
		this._btnType = newValue;
		this.classList.add(newValue);
	}

	set text(newValue) {
		this.textContent = newValue;
	}

	constructor() {
		super();
		this.classList.add('btn');
	}

	attributeChangedCallback(name, _, newValue) {
		if (name === 'btn-type') {
			this.btnType = newValue;
		} else if (name === 'text') {
			this.text = newValue;
		}
	}
}

customElements.define('app-button', ButtonComponent, { extends: 'button' });
