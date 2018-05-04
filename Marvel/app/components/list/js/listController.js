(function () {
    'use strict';

    angular
        .module('listmodule')
        .controller('list.controller', listController);

    listController.$inject = ['$scope'];
    function listController($scope) {
        var vm = this;
    }
})();