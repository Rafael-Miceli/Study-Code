﻿
define(['dataservice'],
function (dataService) {
    
    var speakers = ko.observableArray();
    var initialized = false;

    var vm = {
        activate: activate,
        speakers: speakers,
        title: "Speakers",
        refresh: refresh
    };

    return vm;
        
    function activate() {
        if (initialized) 
            return;
        
        initialized = true;
        return refresh();
    }
    
    function refresh() {
        return dataService.getSpeakersPartials(speakers);
    }
});