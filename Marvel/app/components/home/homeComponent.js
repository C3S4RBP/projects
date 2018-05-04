(function () {
    'use strict';
    angular
        .module('homemodule', [])
        .component('homeComponent', {
            templateUrl: 'app/components/home/view/home.view.html',
            controller: 'home.controller as homeCtrl',
            controllerAs: 'homeCtrl || $ctrl'
        });
})();