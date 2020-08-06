import { html, render } from '../node_modules/lit-html/lit-html.js';
import { repeat } from '../node_modules/lit-html/directives/repeat.js';
const getItemTemplate = (item) => html`<li>
	<p class="editable-list-item-value">${item.name}</p>
	<button class="editable-list-remove-item icon">
		&ominus;
	</button>
</li>`;
const getListTemplate = (context) => html` <style>
		.container {
			max-width: 500px;
			margin: 50px auto;
			border-radius: 20px;
			border: solid 8px #2c3033;
			background: white;
			box-shadow: 0 0 0px 1px rgba(255, 255, 255, 0.4), 0 0 0px 3px #2c3033;
		}

		.editable-list-header {
			margin: 0;
			border-radius: 10px 10px 0 0px;
			background-image: linear-gradient(#687480 0%, #3b4755 100%);
			font: bold 18px/50px arial;
			text-align: center;
			color: white;
			box-shadow: inset 0 -2px 3px 2px rgba(0, 0, 0, 0.4),
				0 2px 2px 2px rgba(0, 0, 0, 0.4);
		}

		.editable-list {
			padding-left: 0;
		}

		.editable-list > li,
		.editable-list-add-container {
			display: flex;
			align-items: center;
		}

		.editable-list > li {
			justify-content: space-between;
			padding: 0 1em;
		}

		.editable-list-add-container {
			justify-content: space-evenly;
		}

		.editable-list > li:nth-child(odd) {
			background-color: rgb(229, 229, 234);
		}

		.editable-list > li:nth-child(even) {
			background-color: rgb(255, 255, 255);
		}

		.editable-list-add-container > label {
			font-weight: bold;
			text-transform: uppercase;
		}

		.icon {
			background: none;
			border: none;
			cursor: pointer;
			font-size: 1.8rem;
			outline: none;
		}
	</style>
	<article class="container">
		<h1 class="editable-list-header">${context.mainTitle}</h1>

		<ul @click=${(e) => context.onListClick(e.target)} class="editable-list">
			${repeat(context.items, (_, i) => i, getItemTemplate)}
		</ul>

		<div class="editable-list-add-container">
			<label>ADD NEW ${context.itemTitle}</label>
			<input
				@input="${(e) => context.updateInput(e.target, context)};"
				.value=${context.inputValue}
				class="add-new-list-item-input"
				type="text"
			/>
			<button
				@click=${(e) => context.onAddClicked(e, context)}
				class="editable-list-add-item icon"
			>
				&oplus;
			</button>
		</div>
	</article>`;
class EditableList extends HTMLElement {
	static get observedAttributes() {
		return ['list-title', 'item-title'];
	}
	constructor() {
		super();
		const root = this.attachShadow({ mode: 'closed' });

		this.items = [];
		this.inputValue = '';
		this._render = function () {
			const templateResult = getListTemplate(this);
			render(templateResult, root);
		};
	}
	connectedCallback() {
		this._render();
	}

	attributeChangedCallback(name, _, newValue) {
		if (name === 'list-title') {
			this.mainTitle = newValue;
		} else if (name == 'item-title') {
			this.itemTitle = newValue;
		}
		this._render();
	}
	onAddClicked(target) {
		this.items.push({ name: this.inputValue });
		this.inputValue = '';
		this._render();
	}
	updateInput(target, context) {
		context.inputValue = target.value;
	}
	onListClick(target) {
		if (target.classList.contains('editable-list-remove-item')) {
			target.parentElement.remove();
		}
	}
}
customElements.define('editable-list', EditableList);
