window.addEventListener("DOMContentLoaded", (event)=>{
    getVisitsCounter();
})

const visitsCounterAPI = '';

const getVisitsCounter = () =>{
    let counter = 0;
    fetch(visitsCounterAPI).then(response => response.json()).then(response => {
        console.log(response);
        counter = response.counter;
        document.getElementById("counter").innerHTML = counter;
    }).catch(error => {
        console.log(error);
    })
    return counter;
}