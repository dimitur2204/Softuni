import { html, render } from '../node_modules/lit-html/lit-html.js';

const getPopupTemplate = (context) => html`<style>
		.wrapper {
			position: relative;
		}

		.info {
			font-size: 0.8rem;
			width: 200px;
			display: inline-block;
			border: 1px solid black;
			padding: 10px;
			background: white;
			border-radius: 10px;
			opacity: 0;
			transition: 0.6s all;
			position: absolute;
			bottom: 20px;
			left: 10px;
			z-index: 3;
		}

		.icon:hover + .info,
		.icon:focus + .info {
			opacity: 1;
		}
	</style>
	<span class="wrapper">
		<span class="icon" tabindex="0">
			<slot name="icon"></slot>
		</span>

		<span class="info">
			<slot name="info"></slot>
		</span>
	</span>`;
class PopupText extends HTMLElement {
	constructor() {
		super();
		const root = this.attachShadow({ mode: 'closed' });

		this._render = function () {
			const templateResult = getPopupTemplate(this);
			render(templateResult, root);
		};

		this._render();
	}
}

customElements.define('app-popup', PopupText);
