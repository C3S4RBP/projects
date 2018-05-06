(function () {
    'use strict';

    angular
        .module('favoritesmodule')
        .controller('favorites.controller', favoritesController);

    favoritesController.$inject = ['$scope', 'favorite.service'];
    function favoritesController($scope, favoriteService) {
        var vm = this,
            struct = { id: 12313, name: '', urlPicture='' },
            alldata = [];

        $scope.favorites = favoriteService.getStorage();

    }
})();