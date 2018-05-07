(function () {
    'use strict';

    angular
        .module('favoritesmodule')
        .service('favorite.service', favoriteService);

    favoriteService.$inject = ['$localStorage', '$state'];
    function favoriteService($localStorage, $state) {
        this.getStorage = getStorage;
        this.setStorage = setStorage;
        this.removeStorage = removeStorage;
        this.getAllStorage = getAllStorage;


        function getStorage(key) {
            var favorite = $localStorage[key];
            return favorite === undefined ? favorite : JSON.parse($localStorage[key]);
        }

        function setStorage(obj) {
            $localStorage[obj.id] = JSON.stringify(obj);
            allStorage(obj.id, 1);
            $state.reload();
        }

        function removeStorage(key) {
            delete $localStorage[key];
            allStorage(key, 0);
            $state.reload();
        }

        function getAllStorage() {
            return $localStorage.favorites;
        }

        function allStorage(id, action) {
            var allfavorites = $localStorage.favorites;
            if (allfavorites === undefined) {
                allfavorites = [];
            }

            if (action === 1) {
                allfavorites.push(id);
                $localStorage.favorites = allfavorites;
            } else {
                angular.forEach(allfavorites, function (v, k) {
                    if (v === id) {
                        allfavorites.splice(k, 1);
                    }
                })
                $localStorage.favorites = allfavorites;
            }
        }

    }
})();