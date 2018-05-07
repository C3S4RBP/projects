(function () {
    'use strict';

    angular
        .module('favoritesmodule')
        .controller('favorites.controller', favoritesController);

    favoritesController.$inject = ['$scope', 'favorite.service'];
    function favoritesController($scope, favoriteService) {
        var vm = this;
        var allFavorites = [];
        $scope.favorites = []
        angular.copy(favoriteService.getAllStorage(), allFavorites);
        angular.forEach(allFavorites, function (v, k) {
            var favorite = favoriteService.getStorage(v);
            $scope.favorites.push({
                urlPicture: favorite.thumbnail.path + '.' + favorite.thumbnail.extension,
                name: favorite.name
            })
        });
    }
})();