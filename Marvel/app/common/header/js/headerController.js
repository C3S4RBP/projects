(function () {
    'use strict';

    angular
        .module('headermodule')
        .controller('header.controller', headerController);

    headerController.$inject = ['$scope', '$state'];
    function headerController($scope, $state) {
        var vm = this;
        $scope.search = $state.params.name;
    }
})();