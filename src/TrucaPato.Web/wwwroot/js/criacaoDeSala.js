$(function(){

    $('#nova-sala').click(function(){

        $.post('api/sala').success(function() {

            window.location = 'Home/Sala';
        });
    });
});