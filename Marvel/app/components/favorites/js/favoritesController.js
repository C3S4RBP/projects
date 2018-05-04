(function () {
    'use strict';

    angular
        .module('favoritesmodule')
        .controller('favorites.controller', favoritesController);

    favoritesController.$inject = ['$scope'];
    function favoritesController($scope) {
        var vm = this;
    }
})();