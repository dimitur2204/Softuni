import { Handlebars } from "sammy";

export function home(hbs: Handlebars){
    const template = hbs.swap("<h1>HOME PAGE</h1>",() =>{});
}