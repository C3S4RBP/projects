(function () {
    'use strict';

    angular
        .module('favoritesmodule')
        .service('favorite.service', favoriteService);

    favoriteService.$inject = ['$localStorage'];
    function favoriteService($localStorage) {
        this.getStorage = getStorage;
        this.setStorage = setStorage;


        function getStorage() {
            return $localStorage.get('favorites');
        }

        function getStorage($localStorageProvider, value) {
            $localStorageProvider.set('favorites', value);
        }

    }
})();