var Ticket = (function () {
    function Ticket(destination, price, status) {
        this.destination = destination;
        this.price = price;
        this.status = status;
    }
    return Ticket;
}());
var solution = function (inputs, crit) {
    var tickets = inputs.map(function (input) {
        var tokens = input.split('|');
        var name = tokens[0], priceStr = tokens[1], statusStr = tokens[2];
        return new Ticket(name, Number(priceStr), statusStr);
    }).sort(function (a, b) {
        if (crit === 'price') {
            return a.price - b.price;
        }
        if (crit === 'destination') {
            return a.destination.localeCompare(b.destination);
        }
        if (crit === 'status') {
            return a.status.localeCompare(b.status);
        }
    });
    console.log(tickets);
};
solution([
    'Philadelphia|94.20|available',
    'New York City|95.99|available',
    'New York City|95.99|sold',
    'Boston|126.20|departed'
], 'destination');
console.log('First Test');
solution([
    'Philadelphia|94.20|available',
    'New York City|95.99|available',
    'New York City|95.99|sold',
    'Boston|126.20|departed'
], 'status');
//# sourceMappingURL=tickets.js.map