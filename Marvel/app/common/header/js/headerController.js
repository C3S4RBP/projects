(function () {
    'use strict';

    angular
        .module('headermodule')
        .controller('header.controller', headerController);

    headerController.$inject = ['$scope'];
    function headerController($scope) {
        var vm = this;
        vm = {
            search: ''
        }
    }
})();