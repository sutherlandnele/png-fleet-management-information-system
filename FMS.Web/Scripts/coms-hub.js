
$(document).ready(function () {

        // Reference the auto-generated proxy for the hub.
        var coms = $.connection.comsHub;

        // Need to register at least one client method so that OnConnected event handler can be called on the hub
        coms.client.userConnected = function (userName) { };

        coms.client.Signout = function () {
            $("#logoutForm").submit();
            $.connection.hub.stop();
        };

        //uncomment below to enable tracing  when debugging errors
        //$.connection.hub.logging = true;

        window.hubReady = $.connection.hub.start();

});
