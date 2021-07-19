var timeBegan = null
    , timeStopped = null
    , stoppedDuration = 0
    , started = null;

function start() {
    if (timeBegan === null) {
        timeBegan = new Date();
    }

    if (timeStopped !== null) {
        stoppedDuration += (new Date() - timeStopped);
    }
    console.log(stoppedDuration);

    started = setInterval(clockRunning, 10);
}

function clockRunning() {
    var d = new Date(),
        seconds = d.getTime(),//(d.getHours()) * 60 * 60 + (d.getMinutes()) * 60 + (d.getSeconds()); 
        currentTime = (seconds - $("#tattime").val())
        , timeElapsed = new Date(currentTime)
        , hour = timeElapsed.getUTCHours()
        , min = timeElapsed.getUTCMinutes()
        , sec = timeElapsed.getUTCSeconds()
        , ms = timeElapsed.getUTCMilliseconds();
    //alert(seconds);
    document.getElementById('timeTAT').innerHTML =
        (hour > 9 ? hour : "0" + hour) + ":" +
        (min > 9 ? min : "0" + min) + ":" +
        (sec > 9 ? sec : "0" + sec) + "." +
        (ms > 99 ? ms : ms > 9 ? "0" + ms : "00" + ms);
};

$(document).ready(function () {
    start();
});