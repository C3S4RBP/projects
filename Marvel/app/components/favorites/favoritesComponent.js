(function () {
    'use strict';
    angular
        .module('favoritesmodule', [])
        .component('favoritesComponent', {
            templateUrl: 'app/components/favorites/view/favorites.view.html',
            controller: 'favorites.controller as favoritesCtrl',
            controllerAs: 'favoritesCtrl || $ctrl'
        });
})();