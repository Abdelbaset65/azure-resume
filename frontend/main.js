window.addEventListener("DOMContentLoaded", (event)=>{
    getVisitsCounter();
})

const visitsCounterAPI = "http://localhost:7071/api/GetResumeViewsCounter";

const getVisitsCounter = () =>{
    let counter = 0;
    fetch(visitsCounterAPI).then(response => response.json()).then(response => {
        console.log(response);
        counter = response.count;
        document.getElementById("counter").innerHTML = counter;
    }).catch(error => {
        console.log(error);
    })
    return counter;
}