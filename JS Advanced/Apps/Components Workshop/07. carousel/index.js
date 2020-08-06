import { html, render } from '../node_modules/lit-html/lit-html.js';
import { classMap } from '../node_modules/lit-html/directives/class-map.js';
const getTemplate = (context) => html` <style>
		.carousel-container {
			max-width: 60rem;
			position: relative;
			margin: 0 auto;
		}

		.carousel-controls {
			text-align: center;
		}

		.carousel-slide {
			display: none;
		}

		.carousel-slide > img {
			width: 100%;
		}

		/* Next & previous buttons */

		.prev,
		.next {
			cursor: pointer;
			position: absolute;
			top: 50%;
			width: auto;
			margin-top: -22px;
			padding: 16px;
			color: white;
			font-weight: bold;
			font-size: 18px;
			transition: 0.6s ease;
			border-radius: 0 3px 3px 0;
			user-select: none;
		}

		/* Position the "next button" to the right */

		.next {
			right: 0;
			border-radius: 3px 0 0 3px;
		}

		/* On hover, add a black background color with a little bit see-through */

		.prev:hover,
		.next:hover {
			background-color: rgba(0, 0, 0, 0.8);
		}

		/* Caption text */

		.text {
			color: #f2f2f2;
			font-size: 15px;
			padding: 8px 12px;
			position: absolute;
			bottom: 8px;
			width: 100%;
			text-align: center;
		}

		/* Number text (1/3 etc) */

		.numbertext {
			color: #f2f2f2;
			font-size: 12px;
			padding: 8px 12px;
			position: absolute;
			top: 0;
		}

		/* The dots/bullets/indicators */
		.carousel-controls > .dot {
			cursor: pointer;
			height: 15px;
			width: 15px;
			margin: 0 2px;
			background-color: #bbb;
			border-radius: 50%;
			display: inline-block;
			transition: background-color 0.6s ease;
		}

		.active,
		.dot:hover {
			background-color: #717171;
		}
		.show {
			display: inline;
		}
		img {
			max-width: 1280px;
			max-height: 720px;
		}
		/* Fading animation */

		.fade {
			-webkit-animation-name: fade;
			-webkit-animation-duration: 1.5s;
			animation-name: fade;
			animation-duration: 1.5s;
		}

		@-webkit-keyframes fade {
			from {
				opacity: 0.4;
			}

			to {
				opacity: 1;
			}
		}

		@keyframes fade {
			from {
				opacity: 0.4;
			}

			to {
				opacity: 1;
			}
		}
	</style>
	<div class="carousel-container">
		<article class="carousel-slide ${classMap(context.firstSlideClasses)}">
			<p class="number-text">1 / 3</p>
			<img src="${context.firstImageUrl}" alt="" />
			<p class="caption-text">${context.firstImageCaption}</p>
		</article>

		<article class="carousel-slide ${classMap(context.secondSlideClasses)}">
			<p class="number-text">2 / 3</p>
			<img src="${context.secondImageUrl}" alt="" />
			<p class="caption-text">${context.secondImageCaption}</p>
		</article>

		<article class="carousel-slide ${classMap(context.thirdSlideClasses)}">
			<p class="number-text">3 / 3</p>
			<img src="${context.thirdImageUrl}" alt="" />
			<p class="caption-text">${context.thirdImageCaption}</p>
		</article>

		<a @click=${context.previousClicked.bind(context)} class="prev">&#10094;</a>
		<a @click=${context.nextClicked.bind(context)} class="next">&#10095;</a>
	</div>
	<div @click=${(e) => context.dotClicked(e.target)} class="carousel-controls">
		<span id="1" class="dot"></span>
		<span id="2" class="dot"></span>
		<span id="3" class="dot"></span>
	</div>`;
class Carousel extends HTMLElement {
	static get observedAttributes() {
		return [
			'first-img-url',
			'second-img-url',
			'third-img-url',
			'first-img-caption',
			'second-img-caption',
			'third-img-caption',
		];
	}
	constructor() {
		super();
		this.firstSlideClasses = { show: false };
		this.secondSlideClasses = { show: false };
		this.thirdSlideClasses = { show: false };
		this.currentSlide = 1;
		const root = this.attachShadow({ mode: 'closed' });
		this._render = () => {
			const tempalte = getTemplate(this);
			render(tempalte, root);
		};
		this._render();
	}
	set currentSlide(val) {
		if (val == 1) {
			this.firstSlideClasses.show = true;
			this.secondSlideClasses.show = false;
			this.thirdSlideClasses.show = false;
		} else if (val == 2) {
			this.secondSlideClasses.show = true;
			this.firstSlideClasses.show = false;
			this.thirdSlideClasses.show = false;
		} else if (val == 3) {
			this.thirdSlideClasses.show = true;
			this.firstSlideClasses.show = false;
			this.secondSlideClasses.show = false;
		}
		this._currentSlide = val;
	}

	get currentSlide() {
		return this._currentSlide;
	}
	attributeChangedCallback(name, _, newValue) {
		if (name === 'first-img-url') {
			this.firstImageUrl = newValue;
		} else if (name === 'second-img-url') {
			this.secondImageUrl = newValue;
		} else if (name === 'third-img-url') {
			this.thirdImageUrl = newValue;
		} else if (name === 'first-img-caption') {
			this.firstImageCaption = newValue;
		} else if (name === 'second-img-caption') {
			this.secondImageCaption = newValue;
		} else if (name === 'first-img-caption') {
			this.thirdImageCaption = newValue;
		}
		this._render();
	}
	previousClicked(context) {
		if (this.currentSlide == 1) {
			this.currentSlide = 3;
			return;
		}
		this.currentSlide--;
		this._render();
	}
	nextClicked(context) {
		if (this.currentSlide == 3) {
			this.currentSlide = 1;
			return;
		}
		this.currentSlide++;
		this._render();
	}
	dotClicked(target) {
		if (target.classList.contains('dot')) {
			this.currentSlide = +target.id;
		}
		this._render();
	}
}
customElements.define('app-carousel', Carousel);
