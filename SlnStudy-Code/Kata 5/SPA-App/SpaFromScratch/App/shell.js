
define(['../Scripts/durandal/system', 'logger'],
    function(system, logger) {
        var shell = {
            activate: activate
        };

        return shell;

        function activate() {
            logger.log('Begin!', null, system.getModuleId(shell), true);
        }
    }
);