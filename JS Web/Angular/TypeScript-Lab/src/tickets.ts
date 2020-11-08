class Ticket{
    constructor(public destination:string,public price:number,public status:string){

    }
}

const solution = (inputs:string[],crit:string) => {
    const tickets = inputs.map(input => {
        const tokens = input.split('|');
        const [name,priceStr,statusStr] = tokens;
        return new Ticket(name,Number(priceStr),statusStr);
    }).sort((a,b) => {
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
}

solution([
    'Philadelphia|94.20|available',
     'New York City|95.99|available',
     'New York City|95.99|sold',
     'Boston|126.20|departed'
    ],
    'destination'
    )
console.log('First Test');
solution([
    'Philadelphia|94.20|available',
     'New York City|95.99|available',
     'New York City|95.99|sold',
     'Boston|126.20|departed'
    ],
    'status'    
    )