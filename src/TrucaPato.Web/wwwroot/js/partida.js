let _nomeDoUsuario;
let _minhaEquipe;

$(function(){

    $('#entrar-em-partida').click(function(){

        $.post('api/Partida/Entrar').success(function() {

            window.location = 'Home/Partida';
        });
    });
});

function configurarUsuario(nomeDoUsuario) {
    
    _nomeDoUsuario = nomeDoUsuario;
    $('#eu').text(_nomeDoUsuario);

    let connection = new signalR.HubConnection('/trucaPatoHub');

    connection.on('jogadoresDaPartida', function(nomeDoUsuario) { 
        
        jogadoresDaPartida(nomeDoUsuario);
    });

    connection.on('minhasCartas', function(cartas) {

        minhasCartas(cartas);
    });

    connection.on('cartaDaRodada', function(carta) {

        cartaDaRodada(carta);
    });

    connection
        .start()
        .then(function(){ 
            connection.invoke('entrarNaPartida', _nomeDoUsuario)
        });
}

function jogadoresDaPartida(jogadores){
    
    limparMesa();
    
    jogadores.forEach(function (jogador) {

        if (jogador.Nome == _nomeDoUsuario)
            _minhaEquipe = jogador.Equipe;
    });

    jogadores.forEach(function (jogador) {

        if (jogador.Nome != _nomeDoUsuario){

            if (jogador.Equipe == _minhaEquipe)
                $('#meu-parceiro').text(jogador.Nome);

            else if (!$('#opnente-1').text())
                $('#opnente-1').text(jogador.Nome);

            else if (!$('#opnente-2').text())
                $('#opnente-2').text(jogador.Nome);
        }
    });
}

function limparMesa() {

    $('#meu-parceiro').text('');
    $('#opnente-1').text('');
    $('#opnente-2').text('');
}

function minhasCartas(cartas){

    $('#minhas-cartas img').remove();
    
    cartas.forEach(function (carta) {

        $('#minhas-cartas')
            .append('<img src="/images/Cartas/' + carta.Nome + ' - ' + carta.Manilha.Nome + '.png"/>');
    });
    
}

function cartaDaRodada(carta) {
    
    $('#carta-da-rodada').attr('src', '/images/Cartas/' + carta.Nome + ' - ' + carta.Manilha.Nome + '.png');
}