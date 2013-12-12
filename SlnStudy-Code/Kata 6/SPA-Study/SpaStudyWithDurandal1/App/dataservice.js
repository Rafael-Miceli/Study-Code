define(function () {

    var getSpeakersPartials = function (speakersObservable) {
        //reset the observable
        speakersObservable([]);

        //set ajax call
        var option = {            
            url: '/api/speakers',
            type: 'GET',
            dataType: 'json'
        };

        //make ajax call


        //handle ajax callback
    };

    var dataService = {
        getSpeakersPartials: getSpeakersPartials
    };

    return dataService;


});