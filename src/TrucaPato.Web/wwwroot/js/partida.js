let _nomeDoUsuario;

$(function(){

    $('#entrar-em-partida').click(function(){

        $.post('api/Partida/Entrar').success(function() {

            window.location = 'Home/Partida';
        });
    });
});

function configurarUsuario(nomeDoUsuario) {
    
    _nomeDoUsuario = nomeDoUsuario;

    let connection = new signalR.HubConnection('/trucaPatoHub');

    connection.on('jogadoresDaPartida', function(nomeDoUsuario) { 
        
        jogadoresDaPartida(nomeDoUsuario);
    });

    connection.on('minhasCartas', function(cartas) {

        minhasCartas(cartas);
    });

    connection
        .start()
        .then(function(){ 
            connection.invoke('entrarNaPartida', _nomeDoUsuario)
        });
}

function jogadoresDaPartida(jogadores){
    
    $('#lista-de-usuarios li').remove();
    
    jogadores.forEach(function (jogador) {

        $('#lista-de-usuarios').append('<li>'+jogador.Nome+'</li>');
    });
}

function minhasCartas(cartas){
    
    cartas.forEach(function (carta) {

        $('#minhas-cartas')
            .append('<img src="/images/Cartas/' + carta.Nome + ' - ' + carta.Manilha.Nome + '.png"/>');
    });
    
}