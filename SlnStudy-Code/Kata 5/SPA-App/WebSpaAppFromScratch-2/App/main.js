require.config({    
    paths: { "text": "../Scripts/text" }
});

define(function(require) {
    var system = require('../Scripts/durandal/system');
    var app = require('../Scripts/durandal/app');
    
    system.debug(true);
    app.start().then(function () {
        app.setRoot('shell');
    });
});