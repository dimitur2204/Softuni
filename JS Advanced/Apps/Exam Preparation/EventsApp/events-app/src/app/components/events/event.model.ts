export class Event{
    constructor(
       public name:string,
       public date:string,
       public description:string,
       public imageURL:string,
       public organizerId:string,
       public peopleInterested:number = 0,
       public id:string = "") {
        
    }
}