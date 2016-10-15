

export default class EventDispatcher{
    constructor(){
        this.listeners = [];
    }

    listen(event, handler){
        this.listeners.push({
            event, handler
        });
    }

    unlisten(event){
        index = this.listeners.findIndex(listener =>listener.event === event);
        if(index > -1){
            this.listeners.splice(index, 1);
        }
    }

    publish(event, args){

        this.listeners.map(listener =>{
            if(listener.event===event){
                console.log(`publishing ${event} to ${listener.handler}`)
                listener.handler(args);
            }
        });
    }
}