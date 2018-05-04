(function () {
    'use strict';
    angular
        .module('headermodule', [])
        .component('headerComponent', {
            templateUrl: 'app/common/header/view/header.view.html',
            controller: 'header.controller as headerCtrl',
            controllerAs: 'headerCtrl || $ctrl',
            bindings: {
                name: '='
            }
        });
})();