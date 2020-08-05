import { html, render } from '../node_modules/lit-html/lit-html.js';
const getTemplate = (context) => html` <style>
		.user-card {
			display: flex;
			font-family: 'Arial', sans-serif;
			background-color: #eee;
			border-bottom: 5px solid darkorchid;
			width: 100%;
		}

		.user-card img {
			width: 200px;
			height: 200px;
			border: 1px solid darkorchid;
		}

		.info {
			display: flex;
			flex-direction: column;
		}

		.info h3 {
			font-weight: bold;
			margin-top: 1em;
			text-align: center;
		}

		.info button {
			outline: none;
			border: none;
			cursor: pointer;
			background-color: darkorchid;
			color: white;
			padding: 0.5em 1em;
		}

		@media only screen and (max-width: 500px) {
			.user-card {
				flex-direction: column;
				margin-bottom: 1em;
			}

			.user-card figure,
			.info button {
				align-self: center;
			}

			.info button {
				margin-bottom: 1em;
			}

			.info p {
				padding-left: 1em;
			}
		}
	</style>
	<div class="user-card">
		<figure>
			<img src="${context.avatar}" />
		</figure>
		<div class="info">
			<h3>${context.name}</h3>
			<div>
				<p>
					${context.email}
				</p>
				<p>
					${context.phone}
				</p>
			</div>

			<button @click=${context.toggleInfo} class="toggle-info-btn">
				${context.isInfoToggled ? 'Hide Info' : 'Show Info'}
			</button>
		</div>
	</div>`;
class CardElement extends HTMLElement {
	static get observedAttributes() {
		return ['name', 'avatar', 'email', 'phone'];
	}
	constructor() {
		super();
		this.isInfoToggled = false;
		const root = this.attachShadow({ mode: 'closed' });
		this._render = function () {
			const templateResult = getTemplate(this);
			render(templateResult, root);
		};
		this._render();
	}
	connectedCallback() {
		this._render();
	}
	attributeChangedCallback(name, _, newValue) {
		if (name === 'name') {
			this.name = newValue;
		} else if (name === 'avatar') {
			this.avatar = newValue;
		} else if (name === 'email') {
			this.email = newValue;
		} else if (name === 'phone') {
			this.phone = newValue;
		}
	}
	toggleInfo(e) {
		const infoDiv = e.target.parentElement.children[1];
		console.log(infoDiv);
		if (this.isInfoToggled) {
			infoDiv.style.display = 'none';
			this.isInfoToggled = false;
			return;
		}
		infoDiv.style.display = 'block';
		this.isInfoToggled = true;
		return;
	}
}
customElements.define('app-card', CardElement);
