class EventEmitter {
	constructor() {
		this.subscriptions = {};
	}

	on(eventName, cb) {
		this.subscriptions[eventName] = (
			this.subscriptions[eventName] || []
		).concat([cb]);
	}

	emit(eventName, data) {
		(this.subscriptions[eventName] || []).forEach((cb) => {
			cb(data);
		});
	}
}
const emitter = new EventEmitter();
emitter.on('event', console.log);
