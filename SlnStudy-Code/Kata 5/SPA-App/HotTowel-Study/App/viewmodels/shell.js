define(['durandal/system',
        'plugins/router',
        'services/logger',
        'services/datacontext'],
    function (system, router, logger, datacontext) {
        var shell = {
            activate: activate,
            router: router
        };
        
        return shell;

        //#region Internal Methods
        function activate() {
            return boot();
            //return datacontext.primeData()
            //    .then(boot)
            //    .fail(failedInit)
        }

        function boot() {
            log('Hot Towel SPA Loaded!', null, true);

            router.on('router:route:not-found', function (fragment) {
                logError('No Route Found', fragment, true);
            });

            var routes = [
                { route: '', moduleId: 'home', title: 'Home', nav: 1 },
                { route: 'details', moduleId: 'details', title: 'Details', nav: 2 },
                { route: 'sessions', moduleId: 'sessions', title: 'Sessions', nav: 3 }
            ];

            return router.makeRelative({ moduleId: 'viewmodels' }) // router will look here for viewmodels by convention
                .map(routes)            // Map the routes
                .buildNavigationModel() // Finds all nav routes and readies them
                .activate();            // Activate the router
        }

        function failedInit(error) {
            toastr.error('App init failed ' + error);
        }

        function log(msg, data, showToast) {
            logger.log(msg, data, system.getModuleId(shell), showToast);
        }

        function logError(msg, data, showToast) {
            logger.logError(msg, data, system.getModuleId(shell), showToast);
        }
        //#endregion
    });