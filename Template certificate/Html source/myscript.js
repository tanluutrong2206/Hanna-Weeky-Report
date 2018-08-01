function onload() {
    textAlert();

    setColorTimeRemainBar();
}

function textAlert() {
    var number_to_do = document.getElementById('number-to-do').innerText;
    number_to_do = parseFloat(number_to_do);
    var green = document.getElementById('green');
    var yellow = document.getElementById('yellow');
    var orange = document.getElementById('orange');
    var red = document.getElementById('red');

    if (number_to_do <= 16) {
        green.textContent = "YOU ARE HERE";
        green.style.color = "white";
    } else if (number_to_do <= 30) {
        yellow.textContent = "YOU ARE HERE";
        yellow.style.color = "black";
    } else if (number_to_do <= 60) {
        orange.textContent = "YOU ARE HERE";
        orange.style.color = "black";
    } else {
        red.textContent = "YOU ARE HERE";
        red.style.color = "black";
    }
}

function setColorTimeRemainBar() {
    
    var timeRemain = document.getElementById("time-remain");
    var progressBar = document.getElementById("progress-bar");
    var widthTimeRemain = timeRemain.offsetWidth;
    var widthProgressBar = progressBar.offsetWidth;

    // window.alert("width);
    var width = (widthTimeRemain/widthProgressBar).toFixed(2);


    if (width <= .25) {
        timeRemain.classList.add("bg-red");
    } else if (width <= .5) {
        timeRemain.classList.add("bg-orange");
    } else if (width <= .75) {
        timeRemain.classList.add("bg-yellow");
    } else {
        timeRemain.classList.add("bg-green");
    }
}