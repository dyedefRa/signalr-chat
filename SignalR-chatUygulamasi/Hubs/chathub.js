/// <reference path="../scripts/jquery-1.6.4.min.js" />
/// <reference path="../scripts/jquery.signalr-2.3.0.min.js" />

$(() => {

    var currentdate = new Date();
    var datetime = currentdate.getDate() + "/"
        + (currentdate.getMonth() + 1) + "/"
        + currentdate.getFullYear() + " @ "
        + currentdate.getHours() + ":"
        + currentdate.getMinutes() + ":"
        + currentdate.getSeconds();

    var name = prompt('Kullanıcı Adınızı Giriniz');
    $('#titleName').html('Hoşgeldiniz ' + name);
    var hub = $.connection.chaty;
    var $btnSend = $('#btnSend'),
        $txtMessage = $('#txtMessage');
        $chatList = $('#chatList');
 

    hub.client.hubtanAl = function (msg) {
        $chatList.append(`<li style='color:blue;'> ${msg}        <p> ${datetime} </p></li>`);
        console.log('Mesaj alindi');
    }
    hub.client.hubtanKendineAl = function (mesaj) {
        $chatList.append(`<li style='color:green;'> ${mesaj}       <p> ${datetime} </p></li>`);
        console.log('Mesaji kendine aldin');
    }


    $.connection.hub.start().done(() => {
        $btnSend.click(() => {

            hub.server.hubaGonder(name, $txtMessage.val());
            $txtMessage.val(null);
            console.log('Gonderildi');

        });

    });
})