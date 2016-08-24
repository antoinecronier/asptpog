$(document).ready(function () {
    startTime();
    backup();
});

function backup() {
    var val0 = $('#ResourceVal0').html();
    var val1 = $('#ResourceVal1').html();
    var id0 = $('#ResourceId0').val();
    var id1 = $('#ResourceId1').val();

    var toSend = id0 + ";" +val0 + ";" + id1 + ";" + val1;

    var t = setTimeout(backup, 10000);

    $.ajax({
        url: '/OGamePlanets/UpdateResources',
        type: 'POST',
        data: { data: toSend}
    })
}

function startTime() {
    $('#ResourceVal0').html(parseInt($('#ResourceVal0').html()) + 2 + 5 * parseInt($('#BitCoinMineLvl').html()));
    $('#ResourceVal1').html(parseInt($('#ResourceVal1').html()) + 2 + 2 * parseInt($('#GoldMineLvl').html()));
    var t = setTimeout(startTime, 1000);
}

function checkTime(i) {
    if (i < 10) { i = "0" + i };  // add zero in front of numbers < 10
    return i;
}