function SetDotNetHelper() {
    alert("dfg");
}

var player;

function initialize() {
    //players.length = 0;
    //player = null;
    player = null;
    var tag = document.createElement('script');

    tag.src = "https://www.youtube.com/player_api";
    var firstScriptTag = document.getElementsByTagName('script')[0];
    firstScriptTag.parentNode.insertBefore(tag, firstScriptTag);

}

function ready(newId) {
    player = new YT.Player('player', {
        height: '360',
        width: '640',
        videoId: newId,
        playerVars: { 'rel': 0, 'controls': 1 },
        events: {
            'onReady': onPlayerReady,
            'onStateChange': onPlayerStateChange
        }
    });

    //players.push(player);
}

function onPlayerStateChange(event) {
    console.log("wykrzyknik");
    if (event.data == YT.PlayerState.PLAYING) {
        window.dotNetHelper.invokeMethodAsync('StartTimer');
        console.log("znak zapytania?");
        console.log(event.target.getVideoUrl());
    }
}

function onPlayerReady(event) {
    console.log(event.target.getVideoUrl());
    window.dotNetHelper.invokeMethodAsync('SongReady', event.target.getVideoUrl());
}

function loadNew(songId) {
player.loadVideoById({
        videoId: songId
    });
}

function SetDotNetHelper(dotNetHelper) {
    window.dotNetHelper = null;
    window.dotNetHelper = dotNetHelper;
}

function playVideo() {
    player.playVideo();
}

function pauseVideo() {
    player.seekTo(0);
    player.pauseVideo();
}

function getState(index) {
    console.log(player.getPlayerState());
    return player.getPlayerState();
}