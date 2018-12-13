"use strict";

var connection = new signalR.HubConnectionBuilder().withUrl("/myHub").build();

connection.on("ReceiveMessage", function (results) {
    //var msg = message.replace(/&/g, "&amp;").replace(/</g, "&lt;").replace(/>/g, "&gt;");
    //var encodedMsg = user + " says " + msg;
    //var li = document.createElement("li");
    //li.textContent = encodedMsg;
    //document.getElementById("messagesList").appendChild(li);
    document.getElementById('freshmen').innerHTML = results.freshman;
    document.getElementById('sophomores').innerHTML = results.sophomore;
    document.getElementById('juniors').innerHTML = results.junior;
    document.getElementById('seniors').innerHTML = results.senior;
    var ctx = document.getElementById("myChart");
    var myChart = new Chart(ctx, {
        type: 'pie',
        data: {
            labels: ["Freshman", "Sophomore", "Junior", "Senior"],
            datasets: [{
                data: [results.freshman, results.sophomore, results.junior, results.senior],
                backgroundColor: [
                    'rgba(0, 99, 132, 0.8)',
                    'rgba(54, 162, 235, 0.8)',
                    'rgba(255, 206, 86, 0.8)',
                    'rgba(75, 192, 192, 0.8)'
                ]
            }]
        }, options: {
            animation: {
                duration: 0
            }
        }
    });
});

connection.start().catch(function (err) {
    return console.error(err.toString());
});

document.getElementById("sendButton").addEventListener("click", function (event) {
    var data =  document.querySelector('input[name = "rank"]:checked').value;
    //var user = document.getElementById("userInput").value;
    //var message = document.getElementById("messageInput").value;
    connection.invoke("SendMessage", data).catch(function (err) {
        return console.error(err.toString());
    });
    event.preventDefault();
});