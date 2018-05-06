(function () {
    'use strict';

    angular.module('marvelmodule',
        [
            'ui.router',
            'ngMaterial',
            'ngStorage',

            'homemodule',
            'headermodule',
            'listmodule',
            'favoritesmodule'
        ]
    )
})();