(function () {
    'use strict';

    angular
        .module('listmodule')
        .controller('list.controller', listController);

    listController.$inject = ['$scope', '$state'];
    function listController($scope, $state) {
        var vm = this;
        $scope.data = $state.params.data;
        console.log($scope.data);
    }
})();