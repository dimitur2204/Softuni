function solve(fundamentals,advanced,apps,form) {
    let price = 0;
    if (fundamentals) {
        price += 170;
    }
    if (advanced) {
        price += 180;
    }
    if (apps) {
        price += 190;
    }
    if (fundametals && advanced) {
        
    }
    if (form == "online") {
        price *= 0.94;
    }
    console.log(Math.round(price));
}
solve(true, true, true, "online");