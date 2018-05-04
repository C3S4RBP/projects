(function () {
    'use strict';

    angular.module('marvelmodule',
        [
            'ui.router',
            
            'homemodule',
            'headermodule',
            'listmodule',
            'favoritesmodule'
        ]
    )
})();