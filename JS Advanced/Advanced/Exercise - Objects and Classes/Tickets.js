function tickets(input,criteria) {
    const tokens = input;
    class Ticket{
        constructor(destination,price,status){
            this.destination = destination;
            this.price = price;
            this.status = status;
        }
    }
    const tickets = [];
    while (tokens.length > 0) {
        const ticketInfo = tokens.shift().split('|');
        const destination = ticketInfo[0];
        const price = Number(ticketInfo[1]);
        const status = ticketInfo[2];
        const ticket = new Ticket(destination,price,status);
        tickets.push(ticket);
    }
    switch (criteria) {
        case 'destination':
            tickets.sort((a,b) =>{
                return a.destination.localeCompare(b.destination);
            });
            break;

        case 'price':
            tickets.sort((a,b) =>{
                return a.price - b.price;
            });
            break;
            
        case 'status':
            tickets.sort((a,b) =>{
                return a.status.localeCompare(b.status);
            });
            break;
    
        default:
            break;
    }
    console.log(tickets);
    return tickets;
}
tickets(['Philadelphia|94.20|available',
'New York City|95.99|available',
'New York City|95.99|sold',
'Boston|126.20|departed'],
'status'
);